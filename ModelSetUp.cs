using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zazaniao;
using HalconDotNet;
using System.Threading;
using System.Data.SqlClient;
using System.IO;

namespace VisionSetUp
{
    public partial class ModelSetUp : Form
    {
        uint StrAddr = 0;
        uint Size_Byte = 0;
        ushort PortNo = 0;
        static uint width, height;
        public ushort MaxPort = 4;
        byte Video_Format, Color_Format;
        static byte Byte_Pixel;
        ushort Channel;
        DataBaseOperate tempFix = new DataBaseOperate();
        static System.Drawing.Imaging.PixelFormat color;//color format, index of Bitmap
        CallBack mycallback = null;
        DataBaseOperate databaseoperate = new DataBaseOperate();






        public HTuple m_AcqHandle;
        public HObject m_Image;				//图像
        public HObject m_objDisp;				//用于显示图形的对象
        public HTuple m_hWindowHandle;			//显示图形窗口句柄
        public HTuple m_ImageRow0;			//当前在窗口显示的图像的左上角坐标y(图像坐标系)
        public HTuple m_ImageCol0;			//当前在窗口显示的图像的左上角坐标x(图像坐标系)
        public HTuple m_ImageRow1;			//当前在窗口显示的图像的右下角坐标y(图像坐标系)
        public HTuple m_ImageCol1;			//当前在窗口显示的图像的右下角坐标x(图像坐标系)
        Vision vision = Vision.Instance();

        public ModelSetUp()
        {
            InitializeComponent();
        }

        private void ModelSetUp_Load(object sender, EventArgs e)
        {
            mycallback = new CallBack(CallBackProc);
            comboBox_channel.SelectedIndex = 0;
            comboBox_port.SelectedIndex = 1;
            comboBox_format.SelectedIndex = 0;
            comboBox_color.SelectedIndex = 3;

            HOperatorSet.GenEmptyObj(out m_Image);
            HOperatorSet.GenEmptyObj(out m_objDisp);
            m_hWindowHandle = hWindowControl1.HalconID;
            m_AcqHandle = vision.CamParam.m_AcqHandle;
            HOperatorSet.SetDraw(m_hWindowHandle, "margin");
            HOperatorSet.SetColored(m_hWindowHandle, 12);
            HOperatorSet.SetColor(m_hWindowHandle, "red");
            //设置halcon内部处理的图像的宽度和高度
            HOperatorSet.SetSystem("tsp_width", 3000);
            HOperatorSet.SetSystem("tsp_height", 3000);
            for (ushort i = 0; i < MaxPort; i++)//initialize each port
            {
                if (Angelo.AngeloRTV_Initial(i) != 0)
                {
                    MessageBox.Show("Total No. of AngeloRTV Port = " + i.ToString());
                    break;
                }
            }
        }

        private void saveModel_Click(object sender, EventArgs e)
        {

            if (nametextBox.Text != "")
            {
                string name = nametextBox.Text.Trim();
                string path = Environment.CurrentDirectory.ToString() + "\\模板";
                string version = "全景";
                if(PortNo==1)
                {
                    version = "全景";
                }
                else if(PortNo == 0)
                {
                    version = "其它";
                }

                DataTable tempTable = tempFix.FindData("摄像头模板", "'" + nametextBox.Text + "'", "模板名称");
                if (tempTable.Rows.Count == 0)
                {
                    if (false == Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    path = path + "\\" + name + ".shm";
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);  //创建文件对象
                    HOperatorSet.WriteShapeModel(vision.Model.m_ModelID, path);
                    ///
                    ///写入数据库
                    ///
                    string fixstring = "INSERT INTO 摄像头模板(摄像头型号,模板保存路径,模板名称) values('" + version + "','" + path + "','" + name + "')";
                    databaseoperate.FixDataBase(fixstring);
                    MessageBox.Show("添加成功！！！");
                }
                else
                {
                    MessageBox.Show("已经存在相同的名称！！！！");
                    this.nametextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("未输入文件名！！");
            }

        }

        private void collectModelToolStripButton_Click(object sender, EventArgs e)
        {

            capture();
            Angelo.AngeloRTV_Capture_Start(PortNo, 0x01);
          
        }

        private void ModelTestToolStripButton_Click(object sender, EventArgs e)
        {

            DataTable tempTable = tempFix.FindData("摄像头模板", "'" + modelTextBox.Text + "'", "模板名称");
            string path = tempTable.Rows[0]["模板保存路径"].ToString();
            HOperatorSet.ReadShapeModel(path, out vision.Model.m_ModelID);
            try
            {
                HTuple HomMat2D;
                s_CheckError Error;
                HObject objDisp;
                HOperatorSet.GenEmptyObj(out objDisp);
                //Vision.Model.m_ModelID = hv_ModelID;
                //几何定位
                vision.Find_Shape_Model(m_Image, ref objDisp, vision.Model.m_ModelID, vision.Model.m_ModelRegion, out HomMat2D, out Error);
                //根据返回错误类型判断是否成功
                if (Error.iErrorType == 0)
                {
                    vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle, true);
                    vision.Concat_Obj(ref m_objDisp, ref objDisp, ref m_objDisp);
                    vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle);
                    vision.disp_message(m_hWindowHandle, "定位成功!", "window", 20, 20, "green", "false");
                }
                else
                {
                    vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle, true);
                    vision.Concat_Obj(ref m_objDisp, ref m_objDisp, ref m_objDisp);
                    vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle);
                    vision.disp_message(m_hWindowHandle, (Error.strErrorInfo), "window", 20, 20, "red", "false");
                }

            }


            catch (HalconException HDevExpDefaultException)
            {
                vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle);
                vision.disp_message(m_hWindowHandle, "定位过程失败!", "window", 20, 20, "red", "false");
                //               throw HDevExpDefaultException;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (modelTextBox.Text != "")
            {
                DataTable tempTable = tempFix.FindData("摄像头模板", "'" + modelTextBox.Text + "'", "模板名称");
                if (tempTable.Rows.Count == 0)
                {
                    MessageBox.Show("该数据不存在");
                    this.modelTextBox.Clear();
                    return;
                }
                else
                {
                    string path = tempTable.Rows[0]["模板保存路径"].ToString();
                    string fixstring = "DELETE FROM 摄像头模板 WHERE 模板名称=" + "'" + modelTextBox.Text + "'";
                    tempFix.FixDataBase(fixstring);
                    File.Delete(path);
                    this.modelTextBox.Clear();
                    MessageBox.Show("删除成功！！！！！");
                }
            }
            else
            {
                MessageBox.Show("没有选择模板参数！！！！！");
                return;
            }
           
          
        }

        private void ModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string versionFind = "";
            string modelFind = "模板名称";
            string sql = "";
            if (selectCameraVersion.Text == "全景")
            {
                versionFind = "全景";
                sql = "SELECT * FROM 摄像头模板 WHERE 摄像头型号 =" +"'"+ versionFind+"'";
                modelTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, modelFind);
                modelTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                modelTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (selectCameraVersion.Text == "其它")
            {
                versionFind = "其它";
                sql = "SELECT * FROM 摄像头模板 WHERE 摄像头型号 =" + "'" + versionFind + "'";
                modelTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, modelFind);
                modelTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                modelTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void modelShow_Click(object sender, EventArgs e)
        {
            DataTable tempTable = tempFix.FindData("摄像头模板", "'" + modelTextBox.Text + "'", "模板名称");
            string path = tempTable.Rows[0]["模板保存路径"].ToString();
            HOperatorSet.ReadShapeModel(path, out vision.Model.m_ModelID);
        }

        private void ModelWrite_Click(object sender, EventArgs e)
        {
            HObject ImageReduced;
            HOperatorSet.GenEmptyObj(out ImageReduced);
            try
            {
                hWindowControl1.Focus();
                HOperatorSet.DispObj(m_Image, m_hWindowHandle);
                HTuple Row, Column, Phi, Length1, Length2;
                HOperatorSet.GenEmptyObj(out ImageReduced);
                //判断图像是否为空
                if (!m_Image.IsInitialized())
                {
                    return;
                }

                //Model = Vision.Model;
                //模板不为空，释放掉
                vision.Model.ClearShapeModel(ref vision.Model.m_ModelID);

                //刷新图形
                vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle, true);
                //提示信息
                vision.disp_message(m_hWindowHandle, "画模板区域，点击鼠标右键确认", "window", 20, 20, "red", "false");
                //画并产生模板区域
                HOperatorSet.DrawRectangle2(m_hWindowHandle, out Row, out Column, out Phi, out Length1, out Length2);

                vision.Model.m_ModelRegion.Dispose();
                HOperatorSet.GenRectangle2(out vision.Model.m_ModelRegion, Row, Column, Phi, Length1, Length2);
                ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(m_Image, vision.Model.m_ModelRegion, out ImageReduced);
                vision.Concat_Obj(ref m_objDisp, ref vision.Model.m_ModelRegion, ref m_objDisp);
                // m_objDisp.ConcatObj(Vision.Model.m_ModelRegion);
                //裁剪模板区域图像
                //       reduce_domain(m_Image,theApp.m_ModelRegion,&ImageReduced);
                //添加模板区域到显示图形
                //  concat_obj(m_objDisp,theApp.m_ModelRegion,&m_objDisp);
                //创建模板
                vision.Model.ClearShapeModel(ref vision.Model.m_ModelID);
                HOperatorSet.CreateShapeModel(ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "auto",
                        "use_polarity", "auto", "auto", out vision.Model.m_ModelID);
                HOperatorSet.DispObj(m_objDisp, m_hWindowHandle);

                //刷新图形
                vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle, false);
                //提示信息
                if (vision.Model.m_ModelID > -1)
                {
                    vision.disp_message(m_hWindowHandle, "创建模板成功!", "window", 20, 20, "green", "false");
                }
                else
                {
                    vision.disp_message(m_hWindowHandle, "创建模板失败!", "window", 20, 20, "red", "false");

                }
            }
            catch (HalconException HDevExpDefaultException)
            {
                ImageReduced.Dispose();
                vision.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle, true);
                vision.disp_message(m_hWindowHandle, "创建模板过程失败!", "window", 20, 20, "red", "false");
                //               throw HDevExpDefaultException;
            }
            ImageReduced.Dispose();
        }

        private void capture()
        {

            for (ushort i = 0; i < MaxPort; i++)
            {
                Angelo.AngeloRTV_Capture_Stop(i);
            }
            ushort Multi;
            PortNo = ushort.Parse(comboBox_port.SelectedItem.ToString());//selected port
            Channel = ushort.Parse(comboBox_channel.SelectedItem.ToString());
            Multi = (ushort)System.Math.Pow(2, Channel);
            Video_Format = (byte)(comboBox_format.SelectedIndex);
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
            Angelo.AngeloRTV_Set_Callback(PortNo, null);
            Angelo.AngeloRTV_Set_Callback(PortNo, mycallback);//connect CallBackProc Function though mycallback
            Angelo.AngeloRTV_Set_Color_Format(PortNo, Color_Format);
            Angelo.AngeloRTV_Set_Video_Format(PortNo, Video_Format);
            Angelo.AngeloRTV_Select_Channel(PortNo, Multi);

        }
        private void CallBackProc(IntPtr BufferAddress, ushort PortNo)
        {
            uint StrAddr = 0;
            uint Size_Byte = 0;
            Angelo.AngeloRTV_Get_Frame(PortNo, ref StrAddr, ref width, ref height, ref Size_Byte);

            HOperatorSet.GenEmptyObj(out m_Image);
            m_Image.Dispose();
            HTuple Width1, Height1;
            HOperatorSet.GenImageInterleaved(out m_Image, (int)StrAddr, "bgr", width, height, 0, "byte", width, height, 0, 0, -1, 0);
            //获取图像大小
            HOperatorSet.GetImageSize(m_Image, out Width1, out Height1);
            //显示全图
            //以适应窗口方式显示图像
            HOperatorSet.SetPart(this.hWindowControl1.HalconID, 0, 0, Height1 - 1, Width1 - 1);
            HOperatorSet.DispObj(m_Image, this.hWindowControl1.HalconWindow);
        }
    }
}
