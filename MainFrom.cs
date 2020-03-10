using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;//for using unmanaged DLL
using Microsoft.Win32;//for using sendmessage
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;
using BarTender;
using Seagull.BarTender.Print;
using HalconDotNet;
using Zazaniao;

namespace VisionSetUp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 所有的定义
        /// </summary>
        DataBaseOperate databaseOperate = new DataBaseOperate();
        printerOperation printer = new printerOperation();
        public static MainForm staticForm;
        public const ushort MaxPort = 4;
        Thread mythread = null;
        ManualResetEvent hEvent = new ManualResetEvent(false); //event for thread
        IntPtr Event;//event for dll
        CallBack mycallback;
        static IntPtr handle;//for sendmessage
        ushort PortNo = 0;
        ushort Channel;
        uint Status;
        static uint width, height;
        byte Video_Format, Color_Format;
        static byte Byte_Pixel;
        static System.Drawing.Imaging.PixelFormat color;//color format, index of Bitmap
        bool ISR_ON = false;//key of the while loop in thread
        BarCode barcode = BarCode.GetInstance();
        DataBaseOperate tempFix = new DataBaseOperate();
        Signal signal = Signal.GetInstance();
        Vision Vision = Vision.Instance();
        private Thread threadInBack;



        public HTuple m_AcqHandle;
        public HObject ho_Image;
        public HObject m_Image;
        public HObject m_objDisp;				//用于显示图形的对象
        public HTuple m_hWindowHandle;			//显示图形窗口句柄
        public HTuple m_ImageRow0;			//当前在窗口显示的图像的左上角坐标y(图像坐标系)
        public HTuple m_ImageCol0;			//当前在窗口显示的图像的左上角坐标x(图像坐标系)
        public HTuple m_ImageRow1;			//当前在窗口显示的图像的右下角坐标y(图像坐标系)
        public HTuple m_ImageCol1;			//当前在窗口显示的图像的右下角坐标x(图像坐标系)
        public HTuple hv_ModelID;
        public Thread m_GrabThread;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public byte[] plcCameraTestBegin = new byte[18];//读CIO1100.00位的数据命令********摄像头检测开始
        public byte[] plcPrinterBegin = new byte[18];//读CIO1102.00位的数据命令********条码打印开始
        public byte[] plcCameraTestReset = new byte[19];//写CIO1100.00位的数据命令********复位摄像头检测开始位
        public byte[] plcPrinterReset = new byte[19];//写CIO1102.00位的数据命令********复位条码打印开始位
        public byte[] plcCameraTestOK = new byte[19];//写CIO1101.00位的数据命令********摄像头OK信号

        public static string IPF = "192.168.250.1";
        public static string IPP = "9600";
        //80 00 02 00 01 00 00 0A 00 00 01 01 30 04 4c 00 00 01
        public int step = 0;
        public int step_print = 0;


        private void monitorTest(bool tempSignal)
        {
            if (tempSignal)
            {
                //测试部分
                HTuple HomMat2D;
                s_CheckError Error;
                HObject objDisp;
                HOperatorSet.GenEmptyObj(out objDisp);
                //几何定位
                Vision.Find_Shape_Model(ho_Image, ref objDisp, Vision.Model.m_ModelID, Vision.Model.m_ModelRegion, out HomMat2D, out Error);
                if (Error.iErrorType == 0)
                {
                    Vision.UpdateImage(ho_Image, ref m_objDisp, m_hWindowHandle, true);
                    Vision.Concat_Obj(ref m_objDisp, ref objDisp, ref m_objDisp);
                    Vision.UpdateImage(ho_Image, ref m_objDisp, m_hWindowHandle);
                    Vision.disp_message(m_hWindowHandle, "定位成功!", "window", 20, 20, "green", "false");
                    resultTextBox.Text = "摄像头测试OK!!!!!!!!!!";
                    signal.TestOver = true;
                }
                else
                {
                    Vision.UpdateImage(ho_Image, ref m_objDisp, m_hWindowHandle, true);
                    Vision.Concat_Obj(ref m_objDisp, ref m_objDisp, ref m_objDisp);
                    Vision.UpdateImage(ho_Image, ref m_objDisp, m_hWindowHandle);
                    Vision.disp_message(m_hWindowHandle, (Error.strErrorInfo), "window", 20, 20, "red", "false");
                    resultTextBox.Text = "摄像头测试NG!!!!!!!!!!";
                    signal.TestOver = false;
                }
                tempSignal = false;
                signal.TestBegin = false;
            }

        }
        private void CallBackProc(IntPtr BufferAddress, ushort PortNo)
        {
            uint StrAddr = 0;
            uint Size_Byte = 0;
            Angelo.AngeloRTV_Get_Frame(PortNo, ref StrAddr, ref width, ref height, ref Size_Byte);

            HOperatorSet.GenEmptyObj(out ho_Image);
            ho_Image.Dispose();
            HTuple Width1, Height1;
            HOperatorSet.GenImageInterleaved(out ho_Image, (int)StrAddr, "bgr", width, height, 0, "byte", width, height, 0, 0, -1, 0);
            //获取图像大小
            HOperatorSet.GetImageSize(ho_Image, out Width1, out Height1);
            //显示全图
            //以适应窗口方式显示图像
            HOperatorSet.SetPart(this.hWindowControl1.HalconID, 0, 0, Height1 - 1, Width1 - 1);
            HOperatorSet.DispObj(ho_Image, this.hWindowControl1.HalconWindow);
            monitorTest(signal.TestBegin);
        }

        private void ThreadProc()
        {
            uint StrAddr = 0;
            uint Size_Byte = 0;
            hEvent.Handle = Event; // Set the Handle to the event from
            while (true)
            {
                hEvent.WaitOne();
                hEvent.Reset();
                if (ISR_ON == false)//don't use "while(ISR_ON)" 
                    break;         //because it will capture 2 pictures in one_shot mode by disconstruct
                Angelo.AngeloRTV_Get_Frame(PortNo, ref StrAddr, ref width, ref height, ref Size_Byte);
                HOperatorSet.GenEmptyObj(out ho_Image);
                ho_Image.Dispose();
                //  HOperatorSet.GenImage1(out ho_Image, "byte", (int)width, (int)height, (int)StrAddr);
                HTuple Width1, Height1;
                HOperatorSet.GenImageInterleaved(out ho_Image, (int)StrAddr, "bgr", width, height, 0, "byte", width, height, 0, 0, -1, 0);
                //获取图像大小
                HOperatorSet.GetImageSize(ho_Image, out Width1, out Height1);
                //显示全图
                //以适应窗口方式显示图像
                HOperatorSet.SetPart(this.hWindowControl1.HalconID, 0, 0, Height1 - 1, Width1 - 1);
                HOperatorSet.DispObj(ho_Image, this.hWindowControl1.HalconWindow);
                monitorTest(signal.TestBegin);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.resultTextBox.ForeColor = System.Drawing.Color.Red;
            selectCameraVersion.Items.Add("全景");
            selectCameraVersion.Items.Add("其他");
            signal.printControl = true;
            signal.InputParameter = false;
            staticForm = this;
            this.groupBox2.Hide();
            mycallback = new CallBack(CallBackProc);
            handle = this.Handle;

            HOperatorSet.GenEmptyObj(out m_Image);
            HOperatorSet.GenEmptyObj(out m_objDisp);
            m_hWindowHandle = hWindowControl1.HalconID;
            m_AcqHandle = Vision.CamParam.m_AcqHandle;
            HOperatorSet.SetDraw(m_hWindowHandle, "margin");
            HOperatorSet.SetColored(m_hWindowHandle, 12);
            HOperatorSet.SetColor(m_hWindowHandle, "red");
            //设置halcon内部处理的图像的宽度和高度
            HOperatorSet.SetSystem("tsp_width", 3000);
            HOperatorSet.SetSystem("tsp_height", 3000);
            try
            {
                DataBaseOperate.OpenConnection();//打开数据库
                DataBaseOperate.CloseConnection();//关闭数据库
            }
            catch
            {
                MessageBox.Show("数据库连接失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Windows.Forms.Application.Exit();
            }

            Control.CheckForIllegalCrossThreadCalls = false;
            #region      对plc连接信号赋值
            //读CIO1100.00位的数据命令********摄像头检测开始
            plcCameraTestBegin[0] = 0x80;
            plcCameraTestBegin[1] = 0x00;
            plcCameraTestBegin[2] = 0x02;
            plcCameraTestBegin[3] = 0x00;
            plcCameraTestBegin[4] = 0x01;
            plcCameraTestBegin[5] = 0x00;
            plcCameraTestBegin[6] = 0x00;
            plcCameraTestBegin[7] = 0x0A;
            plcCameraTestBegin[8] = 0x00;
            plcCameraTestBegin[9] = 0x00;
            plcCameraTestBegin[10] = 0x01;
            plcCameraTestBegin[11] = 0x01;
            plcCameraTestBegin[12] = 0x30;
            plcCameraTestBegin[13] = 0x04;
            plcCameraTestBegin[14] = 0x4C;
            plcCameraTestBegin[15] = 0x00;
            plcCameraTestBegin[16] = 0x00;
            plcCameraTestBegin[17] = 0x01;
            //写CIO1100.00位的数据命令********复位摄像头检测开始位
            plcCameraTestReset[0] = 0x80;
            plcCameraTestReset[1] = 0x00;
            plcCameraTestReset[2] = 0x02;
            plcCameraTestReset[3] = 0x00;
            plcCameraTestReset[4] = 0x01;
            plcCameraTestReset[5] = 0x00;
            plcCameraTestReset[6] = 0x00;
            plcCameraTestReset[7] = 0x0A;
            plcCameraTestReset[8] = 0x00;
            plcCameraTestReset[9] = 0x00;
            plcCameraTestReset[10] = 0x01;
            plcCameraTestReset[11] = 0x02;
            plcCameraTestReset[12] = 0x30;
            plcCameraTestReset[13] = 0x04;
            plcCameraTestReset[14] = 0x4C;
            plcCameraTestReset[15] = 0x00;
            plcCameraTestReset[16] = 0x00;
            plcCameraTestReset[17] = 0x01;
            plcCameraTestReset[18] = 0x00;

            //读CIO1102.00位的数据命令********条码打印开始
            plcPrinterBegin[0] = 0x80;
            plcPrinterBegin[1] = 0x00;
            plcPrinterBegin[2] = 0x02;
            plcPrinterBegin[3] = 0x00;
            plcPrinterBegin[4] = 0x01;
            plcPrinterBegin[5] = 0x00;
            plcPrinterBegin[6] = 0x00;
            plcPrinterBegin[7] = 0x0A;
            plcPrinterBegin[8] = 0x00;
            plcPrinterBegin[9] = 0x00;
            plcPrinterBegin[10] = 0x01;
            plcPrinterBegin[11] = 0x01;
            plcPrinterBegin[12] = 0x30;
            plcPrinterBegin[13] = 0x04;
            plcPrinterBegin[14] = 0x4E;
            plcPrinterBegin[15] = 0x00;
            plcPrinterBegin[16] = 0x00;
            plcPrinterBegin[17] = 0x01;

            //写CIO1102.00位的数据命令********复位条码打印开始位
            plcPrinterReset[0] = 0x80;
            plcPrinterReset[1] = 0x00;
            plcPrinterReset[2] = 0x02;
            plcPrinterReset[3] = 0x00;
            plcPrinterReset[4] = 0x01;
            plcPrinterReset[5] = 0x00;
            plcPrinterReset[6] = 0x00;
            plcPrinterReset[7] = 0x0A;
            plcPrinterReset[8] = 0x00;
            plcPrinterReset[9] = 0x00;
            plcPrinterReset[10] = 0x01;
            plcPrinterReset[11] = 0x02;
            plcPrinterReset[12] = 0x30;
            plcPrinterReset[13] = 0x04;
            plcPrinterReset[14] = 0x4E;
            plcPrinterReset[15] = 0x00;
            plcPrinterReset[16] = 0x00;
            plcPrinterReset[17] = 0x01;
            plcPrinterReset[18] = 0x00;

            //写CIO1101.00位的数据命令********摄像头OK信号
            plcCameraTestOK[0] = 0x80;
            plcCameraTestOK[1] = 0x00;
            plcCameraTestOK[2] = 0x02;
            plcCameraTestOK[3] = 0x00;
            plcCameraTestOK[4] = 0x01;
            plcCameraTestOK[5] = 0x00;
            plcCameraTestOK[6] = 0x00;
            plcCameraTestOK[7] = 0x0A;
            plcCameraTestOK[8] = 0x00;
            plcCameraTestOK[9] = 0x00;
            plcCameraTestOK[10] = 0x01;
            plcCameraTestOK[11] = 0x02;
            plcCameraTestOK[12] = 0x30;
            plcCameraTestOK[13] = 0x04;
            plcCameraTestOK[14] = 0x4D;
            plcCameraTestOK[15] = 0x00;
            plcCameraTestOK[16] = 0x00;
            plcCameraTestOK[17] = 0x01;
            plcCameraTestOK[18] = 0x01;


            #endregion
            //创建(实例化)线程，将需要执行的函数(方法-过程)传入线程中
            this.threadInBack = new Thread(new ThreadStart(PLCConnection));   //3
            //设置线程为后台线程（随着主线程(窗体线程)的退出而退出）
            this.threadInBack.IsBackground = true;
            this.threadInBack.Start();
            comboBox_color.SelectedIndex = 3;
            comboBox_port.SelectedIndex = 1;
            comboBox_format.SelectedIndex = 0;
            comboBox_channel.SelectedIndex = 0;
            comboBox_interrupt.SelectedIndex = 1;
            step = 1;
            step_print = 1;

            for (ushort i = 0; i < MaxPort; i++)//initialize each port
            {
                if (Angelo.AngeloRTV_Initial(i) != 0)
                {
                    MessageBox.Show("Total No. of AngeloRTV Port = " + i.ToString());
                    break;
                }
            }
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            capture();
            Angelo.AngeloRTV_Capture_Start(PortNo, 0xFFFFFFFF);
        }

        private void PrintFormButton_Click(object sender, EventArgs e)
        {
            Form test = System.Windows.Forms.Application.OpenForms["PrintForm"];  //查找是否打开过about窗体 
            if ((test == null) || (test.IsDisposed)) //如果没有打开过
            {
                PrintForm tt = new PrintForm();
                tt.Show();
            }
            else
            {
                test.Activate(); //如果已经打开过就让其获得焦点  
                test.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (signal.print == true && signal.InputParameter == true && signal.printControl==true)
            {
                resultTextBox.Text = "条码打印开始~~~";
                PrintForm tempForm = new PrintForm();
                tempForm.dealBarcode();
                barcodeTextBox.Text = barcode.bar;
                nameTextBox.Text = barcode.name;

                string delete = "DELETE * FROM 需打印数据";
                string insert1 = "INSERT INTO 需打印数据(零部件编号,产品名称,型号,班次,颜色,配置,条码信息) values('" + barcode.number + "','" + barcode.name + "','" + barcode.version + "','" + barcode.team + "','" + barcode.colour + "','" + barcode.deploy + "','" + barcode.bar + "')";
                ///清空需打印数据中的所有数据
                tempFix.FixDataBase(delete);
                //将要打印的一条条码写入到需打印数据中
                tempFix.FixDataBase(insert1);

                printer.printBarcode();
                //将这个打印过程写入到打印记录表中
                string tempdate = DateTime.Now.ToLongDateString();
                string temptime = DateTime.Now.ToLongTimeString();
                string insert2 = "INSERT INTO 打印过程记录(零部件编号,产品名称,型号,班次,颜色,配置,条码信息,条码计数,日期,时间) values('" + barcode.number + "','" + barcode.name + "','" + barcode.version + "','" + barcode.team + "','" + barcode.colour + "','" + barcode.deploy + "','" + barcode.bar + "','" + barcode.count + "','" + tempdate + "','" + temptime + "')";
                tempFix.FixDataBase(insert2);
                signal.print = false;
                resultTextBox.Text = "条码打印结束~~~~";
               
            }
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (mythread != null)
                {
                    ISR_ON = false;
                    hEvent.Set();
                    mythread.Join();
                    mythread = null;
                }
                for (ushort i = 0; i < MaxPort; i++)
                {
                    Angelo.AngeloRTV_Set_Callback(i, null);
                    Angelo.AngeloRTV_Capture_Stop(i);
                    Angelo.AngeloRTV_Close(i);
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
         
        }

        private void AddBarcodeButton_Click(object sender, EventArgs e)
        {
            Form test = System.Windows.Forms.Application.OpenForms["inputInfoForm"];  //查找是否打开过about窗体 
            if ((test == null) || (test.IsDisposed)) //如果没有打开过
            {
                inputInfoForm tempForm = new inputInfoForm();
                tempForm.Show();
            }
            else
            {
                test.Activate(); //如果已经打开过就让其获得焦点  
                test.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }
          
        }

        private void ModelSetUpButton_Click(object sender, EventArgs e)
        {
            Form test = System.Windows.Forms.Application.OpenForms["ModelSetUp"];  //查找是否打开过about窗体 
            if ((test == null) || (test.IsDisposed)) //如果没有打开过
            {
                ModelSetUp tempForm = new ModelSetUp();
                tempForm.Show();
            }
            else
            {
                test.Activate(); //如果已经打开过就让其获得焦点  
                test.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            for (ushort i = 0; i < MaxPort; i++)
            {
                Angelo.AngeloRTV_Capture_Stop(i);
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Form test = System.Windows.Forms.Application.OpenForms["ConfirmForm"];  //查找是否打开过about窗体 
            if ((test == null) || (test.IsDisposed)) //如果没有打开过
            {
                ConfirmForm tempForm = new ConfirmForm();
                tempForm.Show();
            }
            else
            {
                test.Activate(); //如果已经打开过就让其获得焦点  
                test.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }
         
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form test = System.Windows.Forms.Application.OpenForms["HistoryDataFind"];  //查找是否打开过about窗体 
            if ((test == null) || (test.IsDisposed)) //如果没有打开过
            {
                HistoryDataFind tempForm = new HistoryDataFind();
                tempForm.Show();
            }
            else
            {
                test.Activate(); //如果已经打开过就让其获得焦点  
                test.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }
        
        }



        private void selectCameraVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string versionFind = "";
            string modelFind = "模板名称";
            string sql = "";
            if (selectCameraVersion.Text == "全景")
            {
                versionFind = "全景";
                PortNo = 1;
                sql = "SELECT * FROM 摄像头模板 WHERE" + versionFind;
                modelTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, modelFind);
                modelTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                modelTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (selectCameraVersion.Text == "其它")
            {
                versionFind = "其它";
                PortNo = 0;
                sql = "SELECT * FROM 摄像头模板 WHERE" + versionFind;
                modelTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, modelFind);
                modelTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                modelTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void begionButton_Click(object sender, EventArgs e)
        {
            if (modelTextBox.Text != "" && selectCameraVersion.Text != "")
            {
                this.begionButton.Enabled = false;
                this.stopTestButton.Enabled = true;
                DataTable tempTable = databaseOperate.FindData("摄像头模板", "'" + modelTextBox.Text + "'", "模板名称");
                string path = tempTable.Rows[0]["模板保存路径"].ToString();
                HOperatorSet.ReadShapeModel(path, out Vision.Model.m_ModelID);
                if (comboBox_port.Text != "" && comboBox_interrupt.Text != "" && comboBox_format.Text != "" && comboBox_color.Text != "")
                {
                    capture();
                    Angelo.AngeloRTV_Capture_Start(PortNo, 0xFFFFFFFF);
                }
                else
                {
                    MessageBox.Show("参数输入不全！！！！");
                }
            }
            else
            {
                MessageBox.Show("未选择模板！！！");
            }
        }



        private void capture()
        {

            for (ushort i = 0; i < MaxPort; i++)
            {
                Angelo.AngeloRTV_Capture_Stop(i);
            }
            ushort Multi;

            PortNo = ushort.Parse(comboBox_port.SelectedItem.ToString());//selected port
            Channel = ushort.Parse(comboBox_channel.SelectedItem.ToString());//selected channel
            Multi = (ushort)System.Math.Pow(2, Channel);
            Video_Format = (byte)(comboBox_format.SelectedIndex);//selected Video format

            switch (comboBox_color.SelectedIndex)//selected color format
            {
                default:
                case 0://gray
                    Color_Format = 1;
                    Byte_Pixel = 1;
                    color = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                    break;
                case 1://rgb15
                    Color_Format = 2;
                    Byte_Pixel = 2;
                    color = System.Drawing.Imaging.PixelFormat.Format16bppRgb555;
                    break;
                case 2://rgb16
                    Color_Format = 0;
                    Byte_Pixel = 2;
                    color = System.Drawing.Imaging.PixelFormat.Format16bppRgb565;
                    break;
                case 3://rgb24
                    Color_Format = 3;
                    Byte_Pixel = 3;
                    color = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                    break;
                case 4://rgb32
                    Color_Format = 4;
                    Byte_Pixel = 4;
                    color = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
                    break;
            }

            #region disconstruct



            Angelo.AngeloRTV_Set_Callback(PortNo, null);
            if (mythread != null)
            {
                ISR_ON = false;//let ThreadProc go out the loop
                hEvent.Set();
                mythread.Join();//mainthread will continue afer other threads ending
                mythread = null;
            }
            #endregion

            if (comboBox_interrupt.SelectedIndex == 1)//selected callback or thread
            {
                ISR_ON = true;
                Angelo.AngeloRTV_Set_Int_Event(PortNo, ref Event);//set dll event 
                mythread = new Thread(new ThreadStart(ThreadProc));//create thread
                mythread.Start();//start thread
            }
            else
                Angelo.AngeloRTV_Set_Callback(PortNo, mycallback);//connect CallBackProc Function though mycallback
            Angelo.AngeloRTV_Set_Color_Format(PortNo, Color_Format);
            Angelo.AngeloRTV_Set_Video_Format(PortNo, Video_Format);
            Angelo.AngeloRTV_Select_Channel(PortNo, Multi);

        }

        /// <summary>
        /// 后台线程中要执行的方法（过程）
        /// </summary>
        private void PLCConnection()  //2
        {
            UdpClient udpclient = new UdpClient(Convert.ToInt32(IPP));
            //调用UdpClient对象的Connect建立默认远程主机
            udpclient.Connect(IPF, Convert.ToInt32(IPP));
            //第一步，读取CIO1100.00位的数据命令********摄像头检测开始
            do
            {
                try
                {
                    if (step == 1)
                    {
                        //定义一个字节数组，用来存放发送到远程主机的信息
                        Byte[] sendBytes = new byte[18];
                        sendBytes = plcCameraTestBegin;
                        //调用UdpClient对象的Send方法将Udp数据报发送到远程主机
                        udpclient.Send(sendBytes, sendBytes.Length);
                        //实例化IPEndPoint对象，用来显示响应主机的标识
                        IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 0);
                        //调用UdpClient对象的Receive方法获得从远程主机返回的Udp数据报
                        Byte[] receiveBytes = udpclient.Receive(ref ipendpoint);
                        int but = receiveBytes.Length;
                        if (but == 15)
                        {
                            if (receiveBytes[14] == 1)
                            {
                                signal.TestBegin = true;
                                step = 2;
                            }
                        }
                    }
                    //第二步，写CIO1100.00位的数据命令********复位摄像头检测开始
                    if (step == 2)
                    {
                        Byte[] sendBytes = new byte[19];
                        sendBytes = plcCameraTestReset;
                        udpclient.Send(sendBytes, sendBytes.Length);
                        Thread.Sleep(50);
                        step = 3;
                    }
                    //第三步，写CIO1101.00位的数据命令********摄像头OK信号
                    if (step == 3 && signal.TestOver == true)
                    {
                        Byte[] sendBytes = new byte[19];
                        sendBytes = plcCameraTestOK;
                        udpclient.Send(sendBytes, sendBytes.Length);
                        step = 1;
                    }//摄像头检测不合格则直接回位step=1
                    else if (step == 3)
                    {
                        step = 1;
                    }
                    signal.TestOver = false;
                    signal.TestBegin = false;
                }
                catch
                {
                    MessageBox.Show("PLC通讯失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //关闭UdpClient连接
                    udpclient.Close();
                    Thread.Sleep(200);
                    break;
                }
                ///
                ///处理打印信号
                ///
                if (step_print == 1)
                {
                    Byte[] sendBytes = new byte[18];
                    sendBytes = plcPrinterBegin;
                    udpclient.Send(sendBytes, sendBytes.Length);
                    //实例化IPEndPoint对象，用来显示响应主机的标识
                    IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 0);
                    //调用UdpClient对象的Receive方法获得从远程主机返回的Udp数据报
                    Byte[] receiveBytes = udpclient.Receive(ref ipendpoint);
                    int but = receiveBytes.Length;
                    if (but == 15)
                    {
                        if (receiveBytes[14] == 1)
                        {
                            signal.print = true;
                            step_print = 2;
                        }
                    }
                }
                if (step_print == 2)
                {
                    Byte[] sendBytes = new byte[19];
                    sendBytes = plcPrinterReset;
                    udpclient.Send(sendBytes, sendBytes.Length);
                    step_print = 1;
                    Thread.Sleep(2000);
                }
                ////关闭UdpClient连接
                //udpclient.Close();
                //Thread.Sleep(200);
            } while (true); //当为true时执行do里面的内容


        }

        private void continuePrintButton_Click(object sender, EventArgs e)
        {
            signal.printControl = true;
            this.continuePrintButton.Enabled = false;
            this.stopPrintButton.Enabled = true;
            this.resultTextBox.Text = "暂停状态取消，继续打印！！";
        }

        private void stopTestButton_Click(object sender, EventArgs e)
        {
            this.begionButton.Enabled = true;
            this.stopTestButton.Enabled = false;
            for (ushort i = 0; i < MaxPort; i++)
            {
                Angelo.AngeloRTV_Capture_Stop(i);
            }
        }

        private void stopPrintButton_Click(object sender, EventArgs e)
        {

            signal.printControl = false;
            this.stopPrintButton.Enabled = false;
            this.continuePrintButton.Enabled = true;
            this.resultTextBox.Text = "打印被手动停止！！";
        }
    }
}
