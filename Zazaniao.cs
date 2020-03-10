using System;
using System.Runtime.InteropServices;
using System.Text;
using HalconDotNet;
using System.IO;


namespace Zazaniao
{
    // 错误信息
    public struct s_CheckError
    {
        public int iErrorType;					// 错误代码
        public string strErrorInfo;				// 错误描述
    }
    public class ZazaniaoDll
    {
        [DllImport("ZazaniaoHalconDll.dll")]
        //        public static extern void GetDirectoryEx(StringBuilder Path);
        //         [DllImport("ZazaniaoHalconDll.dll")]
        public static extern string GetDirectoryEx();


        // 延时time毫秒
        //        [DllImport("ZazaniaoHalconDll.dll")]
        //	    public static extern void  DelayEx(uint time);

        // 目录是否存在的检查
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool FolderExistEx(string strPath);

        //某个硬盘分区是否存在.分区必须大写
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool DiskExistEx(string stDiskName);

        //         [DllImport("ZazaniaoHalconDll.dll")]
        // 	public static extern void  CreateFolderEx(string szDirPath) ;

        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern void CreateAllDirectoryEx(string szPath);
        //Get Current Time 
        [DllImport("ZazaniaoHalconDll.dll")]
        //       public static extern void GetCurrentTimeAsStringEx(StringBuilder szTime);
        public static extern string GetCurrentTimeAsStringEx();
        // 文件存在
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool FileExistEx(string FileName);
        // 删除目录
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool DeleteDirectoryEx(string DirName);



        //save log file
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern void LogEx(string szPath, string szText, bool bWriteFirstLine, string szFirstLineText);

        // 	void  Find_Keyword_File(char * strPath, char * &PathFull,char * KeyWord);

        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern double RadEx(double dAngle);
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern double DegEx(double dAngle);
        //         [DllImport("ZazaniaoHalconDll.dll")]
        //         public static extern double GetPrivateProfileDoubleEx(
        //             string lpAppName,
        //             string lpKeyName,
        //             double dDefault,
        //             string lpFileName);
        //         [DllImport("ZazaniaoHalconDll.dll")]
        //         public static extern void GetPrivateProfileStringEx(
        //             string lpAppName,
        //             string lpKeyName,
        //             string lpDefault,
        //             string lpFileName, StringBuilder Value);
        //         //         [DllImport("ZazaniaoHalconDll.dll")]
        //         //         public static extern bool CopyDirEx(string strSrcPath, string strDstPath);
        //         //         [DllImport("ZazaniaoHalconDll.dll")]
        //         //         public static extern bool CopyFileAndFolderEx(string strSrcPath, string strDstPath);


        #region ini 文件读写函数

        /// <summary>
        /// 读取INI文件中指定的Key的值
        /// </summary>
        /// <param name="lpAppName">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔</param>
        /// <param name="lpKeyName">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔</param>
        /// <param name="lpDefault">读取失败时的默认值</param>
        /// <param name="lpReturnedString">读取的内容缓冲区，读取之后，多余的地方使用\0填充</param>
        /// <param name="nSize">内容缓冲区的长度</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>实际读取到的长度</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, uint nSize, string lpFileName);

        //另一种声明方式,使用 StringBuilder 作为缓冲区类型的缺点是不能接受\0字符，会将\0及其后的字符截断,
        //所以对于lpAppName或lpKeyName为null的情况就不适用
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        //再一种声明，使用string作为缓冲区的类型同char[]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// 将指定的键和值写到指定的节点，如果已经存在则替换
        /// </summary>
        /// <param name="lpAppName">节点名称</param>
        /// <param name="lpKeyName">键名称。如果为null，则删除指定的节点及其所有的项目</param>
        /// <param name="lpString">值内容。如果为null，则删除指定节点中指定的键。</param>
        /// <param name="lpFileName">INI文件</param>
        /// <returns>操作是否成功</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);


        #endregion

    }

    public class LineParam
    {
        //直线变量 
        public HTuple m_Line_ROI_X;			//直线ROI x坐标数组,第一个值为起点，第二个字为终点
        public HTuple m_Line_ROI_Y;			//直线ROI y坐标数组,第一个值为起点，第二个字为终点
        public int m_Line_Elements;		//rake工具卡尺数
        public int m_Line_Min_Points_Num;  //拟合直线最少点数
        public double m_Line_Sigma;			//直线边缘点滤波系数
        public string m_Line_Transition;		//直线边缘点极性
        public string m_Line_Point_Select;    //直线边缘点选择
        public int m_Line_Threshold;		//直线边缘点阈值
        public HObject m_Line_Regions;			//直线卡尺区域
        public HObject m_Line_xld;				//拟合的直线xld
        public HTuple m_Line_Edges_X;			//直线卡尺工具找到点的x坐标数组
        public HTuple m_Line_Edges_Y;			//直线卡尺工具找到点的y坐标数组	
        public HTuple m_Line_X;				//拟合直线的x坐标数组,第一个值为起点，第二个字为终点
        public HTuple m_Line_Y;				//拟合直线的y坐标数组,第一个值为起点，第二个字为终点
        public int m_Line_Caliper_Width;	//直线卡尺工具宽度
        public int m_Line_Caliper_Height;	//直线卡尺工具高度

        public LineParam()
        {
            //直线变量 
            m_Line_ROI_X = 0;			                            //直线ROI x坐标数组,第一个值为起点，第二个字为终点
            m_Line_ROI_Y = 0;			                            //直线ROI y坐标数组,第一个值为起点，第二个字为终点
            m_Line_Elements = 20;		                            //rake工具卡尺数
            m_Line_Min_Points_Num = 3;	                            //拟合直线最少点数
            m_Line_Sigma = 1;			                            //直线边缘点滤波系数
            m_Line_Transition = "all";	                            //直线边缘点极性
            m_Line_Point_Select = "max";                            //直线边缘点选择
            m_Line_Threshold = 15;		                            //直线边缘点阈值
            HOperatorSet.GenEmptyObj(out  m_Line_Regions);          //直线卡尺区域

            HOperatorSet.GenEmptyObj(out  m_Line_xld);				//拟合的直线xld

            m_Line_Caliper_Width = 15;		                        //直线卡尺工具宽度
            m_Line_Caliper_Height = 60;		                        //直线卡尺工具高度
        }

        ~LineParam()
        {
            m_Line_Regions.Dispose();
            m_Line_xld.Dispose();
        }

    }

    public class CircleParam
    {
        //圆变量
        public HTuple m_Circle_ROI_X;			    //直线ROI x坐标数组,第一个值为起点，第二个字为终点
        public HTuple m_Circle_ROI_Y;			    //直线ROI y坐标数组,第一个值为起点，第二个字为终点
        public int m_Circle_Elements;		    //rake工具卡尺数
        public int m_Circle_Min_Points_Num;	//拟合圆最少点数
        public double m_Circle_Sigma;			    //圆边缘点滤波系数
        public string m_Circle_Transition;	    //圆边缘点极性
        public string m_Circle_Point_Select;	    //圆边缘点选择
        public int m_Circle_Threshold;		    //圆边缘点阈值
        public HObject m_Circle_Regions;		    //圆卡尺区域
        public HObject m_Circle_xld;			    //拟合的圆xld
        public HTuple m_Circle_Edges_X;		    //圆卡尺工具找到点的x坐标数组
        public HTuple m_Circle_Edges_Y;		    //圆卡尺工具找到点的y坐标数组	
        public HTuple m_Circle_Center_X;		    //拟合圆的圆心x
        public HTuple m_Circle_Center_Y;		    //拟合圆的圆心y
        public HTuple m_Circle_Radius;		    //拟合圆的半径
        public HTuple m_Circle_Direct;		    //圆边缘点搜索方向
        public int m_Circle_Caliper_Width;	    //圆卡尺工具宽度
        public int m_Circle_Caliper_Height;	//圆卡尺工具高度
        public HTuple m_Circle_ArcType;		    //拟合圆还是圆弧

        public CircleParam()
        {
            //圆变量
            m_Circle_ROI_X = 0;			                        //直线ROI x坐标数组,第一个值为起点，第二个字为终点
            m_Circle_ROI_Y = 0;			                        //直线ROI y坐标数组,第一个值为起点，第二个字为终点
            m_Circle_Elements = 60;		                        //rake工具卡尺数
            m_Circle_Min_Points_Num = 5;	                        //拟合圆最少点数
            m_Circle_Sigma = 1;			                        //圆边缘点滤波系数
            m_Circle_Transition = "all";	                        //圆边缘点极性
            m_Circle_Point_Select = "max";	                    //圆边缘点选择
            m_Circle_Threshold = 15;		                        //圆边缘点阈值
            m_Circle_Caliper_Width = 15;	                        //圆卡尺工具宽度
            m_Circle_Caliper_Height = 60;	                    //圆卡尺工具高度
            m_Circle_ArcType = "circle";		                    //拟合圆还是圆弧
            HOperatorSet.GenEmptyObj(out m_Circle_Regions);
            HOperatorSet.GenEmptyObj(out m_Circle_xld);
        }
        ~CircleParam()
        {
            m_Circle_Regions.Dispose();
            m_Circle_xld.Dispose();
        }
    }

    public class Model
    {
        //模板参数
        public HTuple m_ModelID;				//定位模板
        public HObject m_ModelRegion;			//模板区域
        public Model()
        {
            m_ModelID = -1;
            HOperatorSet.GenEmptyObj(out m_ModelRegion);
        }
        ~Model()
        {
            ClearShapeModel(ref m_ModelID);
            m_ModelRegion.Dispose();
        }
        public void ClearShapeModel(ref HTuple ModelID)
        {
            if (ModelID > -1)
            {
                HOperatorSet.ClearShapeModel(ModelID);
                ModelID = -1;
            }
        }
    }
    public class SysParam
    {


        //参数
        //距离变量
        public double m_Dis_Min;				//距离下限
        public double m_Dis_Max;				//距离上限
        public HTuple m_Dis;					//测量距离

        //类型名
        public string m_Type;					//类型名
        public string m_OldType;                //旧类型名



        //标定参数
        //	    HObject m_Map;					//畸变校正映射图像
        public double m_Scale;					//畸变校正后的像素单量
        public double m_StdDist;
        //	    bool m_bCalibrated;				//是否标定

        //统计
        public int m_nTotal;					//物料总数
        public int m_nOK;						//OK的数量

        public bool m_bSaveImage;				//保存图像

        //开始检测标志位
        public bool m_bStart;
        public SysParam()
        {


            //参数
            //距离变量
            m_Dis_Min = 0;				//距离下限
            m_Dis_Max = 9999;				//距离上限
            m_Dis = -9999;					//测量距离

            //类型名
            m_Type = "";					//类型名
            m_OldType = "";



            //标定参数
            //	    HObject m_Map;					//畸变校正映射图像
            m_Scale = 1;					//畸变校正后的像素单量
            m_StdDist = 10;
            //	    bool m_bCalibrated;				//是否标定

            //统计
            m_nTotal = 0;					//物料总数
            m_nOK = 0;						//OK的数量

            m_bSaveImage = false;				//保存图像

            //开始检测标志位
            m_bStart = false;
        }



    }
    public class ComParam
    {
        //串口参数
        public string m_Com;			//串口对象
        public int m_iComPort;					//串口号
        public int m_iComBatery;				//波特率
        public int m_iComDDV;					//校验位
        public int m_iComBits;					//数据位
        public int m_iComStopBit;				//停止位

        public ComParam()
        {
            //串口参数
            m_Com = "COM1";			//串口对象
            m_iComPort = 1;					//串口号
            m_iComBatery = 9600; ;				//波特率
            m_iComDDV = 0;					//校验位
            m_iComBits = 8;					//数据位
            m_iComStopBit = 1;				//停止位
        }
    }
    public class CamParam
    {
        public HTuple m_AcqHandle;			//相机类的对象指针
        public HTuple m_CamSN;	        //相机SN号，可以根据相机上的SN填写
        public bool m_bExternalTrigger;	//1为外触发，0为软触发
        public double m_Shutter;				//相机快门
        public double m_Gain;				//相机增益
        public HTuple m_CamNum;				//相机数量
        public bool m_bCamIsOK;//相机是否存在
        //        public HObject m_Image;
        //        public HObject m_objDisplay;
        public CamParam()
        {
            //            HOperatorSet.GenEmptyObj(out m_Image);
            //            HOperatorSet.GenEmptyObj(out m_objDisplay);

            m_AcqHandle = -1;
            m_CamSN = -1;
            m_bExternalTrigger = false;
            m_Shutter = 100;
            m_Gain = 0;
            m_CamNum = 0;

        }

    }

//     public class Vision
//     {
// 
//         public CamParam CamParam1;
//         public LineParam LineParam;
//         public CircleParam CircleParam;
//         public Model Model1;
//         public SysParam SysParam1;
//         public ComParam ComParam1;
// 
//         public Vision()
//         {
//             CamParam1 = new CamParam();
//             LineParam = new LineParam();
//             CircleParam = new CircleParam();
//             Model1 = new Model();
//             SysParam1 = new SysParam();
//             ComParam1 = new ComParam();
//         }
// 
// 
//     }

    public class Vision
    {
        /// <summary>
        /// 单例实例
        /// </summary>
        private static Vision _instance = null;
        public bool ChangeText;
        public bool OKStar;
        public bool OKStar_off;
        public bool OKStar_0n;
        public bool OKStar_0n_btn=false;
        public bool print;
        public string name;
        public Int32[] dada_shuju=new Int32[11];
        
        public static Vision Instance()
        {
            if (_instance == null)
            {
                _instance = new Vision();
            }

            return _instance;
        }
  //      Vision Vision = new Vision();

        public CamParam CamParam = new CamParam();
            public LineParam LineParam = new LineParam();
            public CircleParam CircleParam = new CircleParam();
            public Model Model = new Model();
            public SysParam SysParam = new SysParam();
            public ComParam ComParam = new ComParam();
        public s_CheckError LoadConfigFile()
        {
            s_CheckError Error;

            try
            {
                string tmpstr;
                string INIStr;
                string SYSStr, INIPath;
                if (SysParam.m_Type == "")
                {
                    Error.iErrorType = 1;
                    Error.strErrorInfo = "类型为空!";
                    return Error;
                }
                INIStr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\param.ini";
                INIPath = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type;
                //直线变量 
                Read_Tuple(ref LineParam.m_Line_ROI_X, INIPath + "\\m_Line_ROI_X.tup");
                Read_Tuple(ref LineParam.m_Line_ROI_Y, INIPath + "\\m_Line_ROI_Y.tup");

                LineParam.m_Line_Sigma = GetPrivateProfileDouble("Line", "m_Line_Sigma", 1, INIStr);
                LineParam.m_Line_Elements = GetPrivateProfileInt("Line", "m_Line_Elements", 30, INIStr);
                LineParam.m_Line_Min_Points_Num = GetPrivateProfileInt("Line", "m_Line_Min_Points_Num", 5, INIStr);
                LineParam.m_Line_Transition = GetPrivateProfileString("Line", "m_Line_Transition", "all", INIStr);
                LineParam.m_Line_Point_Select = GetPrivateProfileString("Line", "m_Line_Point_Select", "first", INIStr);
                LineParam.m_Line_Threshold = GetPrivateProfileInt("Line", "m_Line_Threshold", 20, INIStr);
                LineParam.m_Line_Caliper_Width = GetPrivateProfileInt("Line", "m_Line_Caliper_Width", 15, INIStr);
                LineParam.m_Line_Caliper_Height = GetPrivateProfileInt("Line", "m_Line_Caliper_Height", 60, INIStr);

                //圆变量
                Read_Tuple(ref CircleParam.m_Circle_ROI_X,Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_Circle_ROI_X.tup");
                Read_Tuple(ref CircleParam.m_Circle_ROI_Y, Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_Circle_ROI_Y.tup");

                CircleParam.m_Circle_Elements = GetPrivateProfileInt("Circle", "m_Circle_Elements", 30, INIStr);
                CircleParam.m_Circle_Min_Points_Num = GetPrivateProfileInt("Circle", "m_Circle_Min_Points_Num", 10, INIStr);
                CircleParam.m_Circle_Sigma = GetPrivateProfileDouble("Circle", "m_Circle_Sigma", 1, INIStr);
                CircleParam.m_Circle_Transition = GetPrivateProfileString("Circle", "m_Circle_Transition", "all", INIStr);
                CircleParam.m_Circle_Point_Select = GetPrivateProfileString("Circle", "m_Circle_Point_Select", "first", INIStr);
                CircleParam.m_Circle_Threshold = GetPrivateProfileInt("Circle", "m_Circle_Threshold", 20, INIStr);
                CircleParam.m_Circle_Caliper_Width = GetPrivateProfileInt("Circle", "m_Circle_Caliper_Width", 15, INIStr);
                CircleParam.m_Circle_Caliper_Height = GetPrivateProfileInt("Circle", "m_Circle_Caliper_Height", 60, INIStr);
                CircleParam.m_Circle_Direct = GetPrivateProfileString("Circle", "m_Circle_Direct", "inner", INIStr);

                Read_Region(ref Model.m_ModelRegion, Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_ModelRegion.tif");
                Read_Model(ref Model.m_ModelID, Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_ModelID.shm");

                //距离变量
                SysParam.m_Dis_Min = GetPrivateProfileDouble("Dis", "m_Dis_Min", 0, INIStr);
                SysParam.m_Dis_Max = GetPrivateProfileDouble("Dis", "m_Dis_Max", 1000, INIStr);

                //标定参数

                //像素单量
                SysParam.m_Scale = GetPrivateProfileDouble("Calibrate", "m_Scale", 1, INIStr);
                SysParam.m_StdDist = GetPrivateProfileDouble("Calibrate", "m_StdDist", 10, INIStr);
                //相机参数
                CamParam.m_Shutter = GetPrivateProfileDouble("Cam", "m_Shutter", 100, INIStr);
                CamParam.m_Gain=GetPrivateProfileDouble("Cam", "m_Gain",10,INIStr);
               
                //统计
                string InITemp = Directory.GetCurrentDirectory() + "\\data\\" + "\\Config.ini";

                SysParam.m_nTotal = GetPrivateProfileInt("Result", "m_nTotal", 0, InITemp);				//物料总数
                SysParam.m_nOK = GetPrivateProfileInt("Result", "m_nOK", 0, InITemp);						//OK的数量


                Error.iErrorType = 0;
                Error.strErrorInfo = "读取参数成功!";
                return Error;


            }
            catch (Exception ex)
            {
                Error.iErrorType = -1;
                Error.strErrorInfo = "读取参数过程失败!";
                Log(ex.Message);
                return Error;

            }
        }
        public s_CheckError SaveConfigFile()
        {
            s_CheckError Error;
            Error.iErrorType = 0;
            Error.strErrorInfo = "";

            //保存配置文件

            try
            {
                string tmpstr;
                string INIStr;
                string SYSStr;
                if (SysParam.m_Type == "")
                {
                    Error.iErrorType = -1;
                    Error.strErrorInfo = "类型为空!";
                    return Error;
                }
                //参数ini文件路径
                INIStr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\param.ini";
                //创建文件夹
                ZazaniaoDll.CreateAllDirectoryEx(INIStr);



                //直线变量 
                tmpstr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_Line_ROI_X.tup";
                Write_Tuple(LineParam.m_Line_ROI_X, tmpstr);

                tmpstr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_Line_ROI_Y.tup";
                Write_Tuple(LineParam.m_Line_ROI_Y, tmpstr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Elements", Convert.ToString(LineParam.m_Line_Elements), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Min_Points_Num", Convert.ToString(LineParam.m_Line_Min_Points_Num), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Sigma", Convert.ToString(LineParam.m_Line_Sigma), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Transition", LineParam.m_Line_Transition, INIStr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Point_Select", LineParam.m_Line_Point_Select, INIStr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Threshold", Convert.ToString(LineParam.m_Line_Threshold), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Caliper_Width", Convert.ToString(LineParam.m_Line_Caliper_Width), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Line", "m_Line_Caliper_Height", Convert.ToString(LineParam.m_Line_Caliper_Height), INIStr);

                //圆变量
                tmpstr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_Circle_ROI_X.tup";
                Write_Tuple(CircleParam.m_Circle_ROI_X, tmpstr);
                tmpstr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_Circle_ROI_Y.tup";
                Write_Tuple(CircleParam.m_Circle_ROI_Y, tmpstr);

                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Elements", Convert.ToString(CircleParam.m_Circle_Elements), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Min_Points_Num", Convert.ToString(CircleParam.m_Circle_Min_Points_Num), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Sigma", Convert.ToString(CircleParam.m_Circle_Sigma), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Transition", CircleParam.m_Circle_Transition, INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Point_Select", CircleParam.m_Circle_Point_Select, INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Threshold", Convert.ToString(CircleParam.m_Circle_Threshold), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Caliper_Width", Convert.ToString(CircleParam.m_Circle_Caliper_Width), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Caliper_Height", Convert.ToString(CircleParam.m_Circle_Caliper_Height), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Circle", "m_Circle_Direct", CircleParam.m_Circle_Direct, INIStr);
                tmpstr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_ModelRegion.tif";
                Write_Region(Model.m_ModelRegion, tmpstr);
                tmpstr = Directory.GetCurrentDirectory() + "\\data\\" + SysParam.m_Type + "\\m_ModelID.shm";
                Write_Model(Model.m_ModelID, tmpstr);

                //距离变量
                ZazaniaoDll.WritePrivateProfileString("Dis", "m_Dis_Min", Convert.ToString(SysParam.m_Dis_Min), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Dis", "m_Dis_Max", Convert.ToString(SysParam.m_Dis_Max), INIStr);

                //标定参数

                //保存畸变校正后的像素单量
                ZazaniaoDll.WritePrivateProfileString("Calibrate", "m_Scale", Convert.ToString(SysParam.m_Scale), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Calibrate", "m_StdDist", Convert.ToString(SysParam.m_StdDist), INIStr);

                //相机参数
                ZazaniaoDll.WritePrivateProfileString("Cam", "m_Shutter", Convert.ToString(CamParam.m_Shutter), INIStr);
                ZazaniaoDll.WritePrivateProfileString("Cam", "m_Gain", Convert.ToString(CamParam.m_Gain), INIStr);
              
                Error.iErrorType = 0;
                Error.strErrorInfo = "保存参数成功!";
                return Error;

            }
            catch (Exception ex)
            {
                Error.iErrorType = -1;
                Error.strErrorInfo = "保存参数过程失败!";
                Log(ex.Message);
                return Error;

            }

        }
        public double GetPrivateProfileDouble(string lpAppName, string lpKeyName, double Default, string lpFileName)
        {
           // char[] lpReturnedString = new char[1024];
            StringBuilder lpReturnedString = new StringBuilder(1024);
            ZazaniaoDll.GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);
            return Convert.ToDouble(lpReturnedString.ToString());
            
         
        }
        public int  GetPrivateProfileInt(string lpAppName, string lpKeyName, int Default, string lpFileName)
        {
            //char[] lpReturnedString = new char[1024];
            StringBuilder lpReturnedString = new StringBuilder(1024);
            ZazaniaoDll.GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);
           
            return Convert.ToInt32(lpReturnedString.ToString());
        }

        public string GetPrivateProfileString(string lpAppName, string lpKeyName, string Default, string lpFileName)
        {
            StringBuilder lpReturnedString = new StringBuilder(1024);
            ZazaniaoDll.GetPrivateProfileString(lpAppName, lpKeyName, Default, lpReturnedString, 1024, lpFileName);
            return lpReturnedString.ToString();
        }
     

        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
      HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {


            // Local control variables 

            HTuple hv_Red, hv_Green, hv_Blue, hv_Row1Part;
            HTuple hv_Column1Part, hv_Row2Part, hv_Column2Part, hv_RowWin;
            HTuple hv_ColumnWin, hv_WidthWin, hv_HeightWin, hv_MaxAscent;
            HTuple hv_MaxDescent, hv_MaxWidth, hv_MaxHeight, hv_R1 = new HTuple();
            HTuple hv_C1 = new HTuple(), hv_FactorRow = new HTuple(), hv_FactorColumn = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple(), hv_Ascent = new HTuple();
            HTuple hv_Descent = new HTuple(), hv_W = new HTuple(), hv_H = new HTuple();
            HTuple hv_FrameHeight = new HTuple(), hv_FrameWidth = new HTuple();
            HTuple hv_R2 = new HTuple(), hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_Exception = new HTuple(), hv_CurrentColor = new HTuple();

            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 

            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If set to 'true', the text is written within a white box.
            //
            //prepare window
            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
                out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //display text box depending on text size
            if ((int)(new HTuple(hv_Box.TupleEqual("true"))) != 0)
            {
                //calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                HOperatorSet.SetColor(hv_WindowHandle, "light gray");
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 3, hv_C1 + 3, hv_R2 + 3, hv_C2 + 3);
                HOperatorSet.SetColor(hv_WindowHandle, "white");
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            else if ((int)(new HTuple(hv_Box.TupleNotEqual("false"))) != 0)
            {
                hv_Exception = "Wrong value of control parameter Box";
                throw new HalconException(hv_Exception);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }

        // Chapter: XLD / Creation
        // Short Description: Creates an arrow shaped XLD contour.
        public void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
            HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {


            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_TempArrow = null;


            // Local control variables 

            HTuple hv_Length, hv_ZeroLengthIndices, hv_DR;
            HTuple hv_DC, hv_HalfHeadWidth, hv_RowP1, hv_ColP1, hv_RowP2;
            HTuple hv_ColP2, hv_Index;

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);

            try
            {
                //This procedure generates arrow shaped XLD contours,
                //pointing from (Row1, Column1) to (Row2, Column2).
                //If starting and end point are identical, a contour consisting
                //of a single point is returned.
                //
                //input parameteres:
                //Row1, Column1: Coordinates of the arrows' starting points
                //Row2, Column2: Coordinates of the arrows' end points
                //HeadLength, HeadWidth: Size of the arrow heads in pixels
                //
                //output parameter:
                //Arrow: The resulting XLD contour
                //
                //The input tuples Row1, Column1, Row2, and Column2 have to be of
                //the same length.
                //HeadLength and HeadWidth either have to be of the same length as
                //Row1, Column1, Row2, and Column2 or have to be a single element.
                //If one of the above restrictions is violated, an error will occur.
                //
                //
                //Init
                ho_Arrow.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Arrow);
                //
                //Calculate the arrow length
                HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
                //
                //Mark arrows with identical start and end point
                //(set Length to -1 to avoid division-by-zero exception)
                hv_ZeroLengthIndices = hv_Length.TupleFind(0);
                if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
                {
                    hv_Length[hv_ZeroLengthIndices] = -1;
                }
                //
                //Calculate auxiliary variables.
                hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
                hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
                hv_HalfHeadWidth = hv_HeadWidth / 2.0;
                //
                //Calculate end points of the arrow head.
                hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
                hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
                hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
                hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
                //
                //Finally create output XLD contour for each input point pair
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                    {
                        //Create_ single points for arrows with identical start and end point
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
                            hv_Index), hv_Column1.TupleSelect(hv_Index));
                    }
                    else
                    {
                        //Create arrow contour
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                            hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                            ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                            hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                    }
                    OTemp[SP_O] = ho_Arrow.CopyObj(1, -1);
                    SP_O++;
                    ho_Arrow.Dispose();
                    HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_TempArrow, out ho_Arrow);
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;
                }
                ho_TempArrow.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_TempArrow.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void draw_rake(out HObject ho_Regions, HTuple hv_WindowHandle, HTuple hv_Elements,
            HTuple hv_DetectHeight, HTuple hv_DetectWidth, out HTuple hv_Row1, out HTuple hv_Column1,
            out HTuple hv_Row2, out HTuple hv_Column2)
        {


            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_RegionLines, ho_Rectangle = null;
            HObject ho_Arrow1 = null;


            // Local control variables 

            HTuple hv_ATan, hv_i, hv_RowC = new HTuple();
            HTuple hv_ColC = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_RegionLines);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);

            try
            {
                //提示
                disp_message(hv_WindowHandle, "点击鼠标左键画一条直线,点击右键确认", "window",
                    12, 12, "red", "false");
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //画矢量检测直线
                HOperatorSet.DrawLine(hv_WindowHandle, out hv_Row1, out hv_Column1, out hv_Row2,
                    out hv_Column2);
                //产生直线xld
                ho_RegionLines.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
                    hv_Column1.TupleConcat(hv_Column2));
                //存储到显示对象
                OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                SP_O++;
                ho_Regions.Dispose();
                HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_RegionLines, out ho_Regions);
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;
                //计算直线与x轴的夹角，逆时针方向为正向。
                HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

                //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
                hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

                //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
                for (hv_i = 1; hv_i.Continue(hv_Elements, 1); hv_i = hv_i.TupleAdd(1))
                {
                    //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
                    if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
                    {
                        hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
                        hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
                        HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
                    }
                    else
                    {
                        //如果有多个测量矩形，产生该测量矩形xld
                        hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
                        hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
                    }
                    //把测量矩形xld存储到显示对象
                    OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                    SP_O++;
                    ho_Regions.Dispose();
                    HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Rectangle, out ho_Regions);
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;
                    if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
                    {
                        //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
                        hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        //把xld存储到显示对象
                        OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                        SP_O++;
                        ho_Regions.Dispose();
                        HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Arrow1, out ho_Regions);
                        OTemp[SP_O - 1].Dispose();
                        SP_O = 0;
                    }
                }

                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void draw_spoke(HObject ho_Image, out HObject ho_Regions, HTuple hv_WindowHandle,
            HTuple hv_Elements, HTuple hv_DetectHeight, HTuple hv_DetectWidth, out HTuple hv_ROIRows,
            out HTuple hv_ROICols, out HTuple hv_Direct)
        {



            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_ContOut1, ho_Contour, ho_ContCircle;
            HObject ho_Cross, ho_Rectangle1 = null, ho_Arrow1 = null;


            // Local control variables 

            HTuple hv_Rows, hv_Cols, hv_Weights, hv_Length1;
            HTuple hv_RowC, hv_ColumnC, hv_Radius, hv_StartPhi, hv_EndPhi;
            HTuple hv_PointOrder, hv_RowXLD, hv_ColXLD, hv_Row1, hv_Column1;
            HTuple hv_Row2, hv_Column2, hv_DistanceStart, hv_DistanceEnd;
            HTuple hv_Length2, hv_i, hv_j = new HTuple(), hv_RowE = new HTuple();
            HTuple hv_ColE = new HTuple(), hv_ATan = new HTuple(), hv_RowL2 = new HTuple();
            HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple(), hv_ColL1 = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_ContOut1);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);

            hv_ROIRows = new HTuple();
            hv_ROICols = new HTuple();
            hv_Direct = new HTuple();
            try
            {
                //提示
                disp_message(hv_WindowHandle, "1、画4个以上点确定一个圆弧,点击右键确认", "window",
                    12, 12, "red", "false");
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //沿着圆弧或圆的边缘画点
                ho_ContOut1.Dispose();
                HOperatorSet.DrawNurbs(out ho_ContOut1, hv_WindowHandle, "true", "true", "true",
                    "true", 3, out hv_Rows, out hv_Cols, out hv_Weights);
                //至少要4个点
                HOperatorSet.TupleLength(hv_Weights, out hv_Length1);
                if ((int)(new HTuple(hv_Length1.TupleLess(4))) != 0)
                {
                    disp_message(hv_WindowHandle, "提示：点数太少，请重画", "window", 32, 12,
                        "red", "false");
                    hv_ROIRows = new HTuple();
                    hv_ROICols = new HTuple();
                    ho_ContOut1.Dispose();
                    ho_Contour.Dispose();
                    ho_ContCircle.Dispose();
                    ho_Cross.Dispose();
                    ho_Rectangle1.Dispose();
                    ho_Arrow1.Dispose();

                    return;
                }
                //获取点
                hv_ROIRows = hv_Rows.Clone();
                hv_ROICols = hv_Cols.Clone();
                //产生xld
                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_ROIRows, hv_ROICols);
                //用回归线法（不抛出异常点，所有点权重一样）拟合圆
                HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 3, 2, out hv_RowC,
                    out hv_ColumnC, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);
                //根据拟合结果产生xld，并保持到显示对象
                ho_ContCircle.Dispose();
                HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_RowC, hv_ColumnC, hv_Radius,
                    hv_StartPhi, hv_EndPhi, hv_PointOrder, 3);
                OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                SP_O++;
                ho_Regions.Dispose();
                HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_ContCircle, out ho_Regions);
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;

                //获取圆或圆弧xld上的点坐标
                HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);
                //显示图像和圆弧
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                }
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_ContCircle, HDevWindowStack.GetActive());
                }
                //产生并显示圆心
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_RowC, hv_ColumnC, 60, 0.785398);
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_Cross, HDevWindowStack.GetActive());
                }
                //提示
                disp_message(hv_WindowHandle, "2、远离圆心，画箭头确定边缘检测方向，点击右键确认",
                    "window", 32, 12, "red", "false");
                //画线，确定检测方向
                HOperatorSet.DrawLine(hv_WindowHandle, out hv_Row1, out hv_Column1, out hv_Row2,
                    out hv_Column2);
                //求圆心到检测方向直线起点的距离
                HOperatorSet.DistancePp(hv_RowC, hv_ColumnC, hv_Row1, hv_Column1, out hv_DistanceStart);
                //求圆心到检测方向直线终点的距离
                HOperatorSet.DistancePp(hv_RowC, hv_ColumnC, hv_Row2, hv_Column2, out hv_DistanceEnd);

                //求圆或圆弧xld上的点的数量
                HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);
                //判断检测的边缘数量是否过少
                if ((int)(new HTuple(hv_Elements.TupleLess(3))) != 0)
                {
                    hv_ROIRows = new HTuple();
                    hv_ROICols = new HTuple();
                    disp_message(hv_WindowHandle, "检测的边缘数量太少，请重新设置!", "window",
                        52, 12, "red", "false");
                    ho_ContOut1.Dispose();
                    ho_Contour.Dispose();
                    ho_ContCircle.Dispose();
                    ho_Cross.Dispose();
                    ho_Rectangle1.Dispose();
                    ho_Arrow1.Dispose();

                    return;
                }
                //如果xld是圆弧，有Length2个点，从起点开始，等间距（间距为Length2/(Elements-1)）取Elements个点，作为卡尺工具的中点
                //如果xld是圆，有Length2个点，以0°为起点，从起点开始，等间距（间距为Length2/(Elements)）取Elements个点，作为卡尺工具的中点
                for (hv_i = 0; hv_i.Continue(hv_Elements - 1, 1); hv_i = hv_i.TupleAdd(1))
                {

                    if ((int)(new HTuple(((hv_RowXLD.TupleSelect(0))).TupleEqual(hv_RowXLD.TupleSelect(
                        hv_Length2 - 1)))) != 0)
                    {
                        //xld的起点和终点坐标相对，为圆
                        HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);

                    }
                    else
                    {
                        //否则为圆弧
                        HOperatorSet.TupleInt(((1.0 * hv_Length2) / (hv_Elements - 1)) * hv_i, out hv_j);
                    }
                    //索引越界，强制赋值为最后一个索引
                    if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
                    {
                        hv_j = hv_Length2 - 1;
                        //continue
                    }
                    //获取卡尺工具中心
                    hv_RowE = hv_RowXLD.TupleSelect(hv_j);
                    hv_ColE = hv_ColXLD.TupleSelect(hv_j);

                    //如果圆心到检测方向直线的起点的距离大于圆心到检测方向直线的终点的距离，搜索方向由圆外指向圆心
                    //如果圆心到检测方向直线的起点的距离不大于圆心到检测方向直线的终点的距离，搜索方向由圆心指向圆外
                    if ((int)(new HTuple(hv_DistanceStart.TupleGreater(hv_DistanceEnd))) != 0)
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
                        //角度反向
                        hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
                        //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
                        hv_Direct = "inner";
                    }
                    else
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
                        //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
                        hv_Direct = "outer";
                    }

                    //产生卡尺xld，并保持到显示对象
                    ho_Rectangle1.Dispose();
                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
                        hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
                    OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                    SP_O++;
                    ho_Regions.Dispose();
                    HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Rectangle1, out ho_Regions);
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;

                    //用箭头xld指示边缘搜索方向，并保持到显示对象
                    if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
                    {
                        hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                        SP_O++;
                        ho_Regions.Dispose();
                        HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Arrow1, out ho_Regions);
                        OTemp[SP_O - 1].Dispose();
                        SP_O = 0;
                    }
                }

                ho_ContOut1.Dispose();
                ho_Contour.Dispose();
                ho_ContCircle.Dispose();
                ho_Cross.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ContOut1.Dispose();
                ho_Contour.Dispose();
                ho_ContCircle.Dispose();
                ho_Cross.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void pts_to_best_circle(out HObject ho_Circle, HTuple hv_Rows, HTuple hv_Cols,
            HTuple hv_ActiveNum, HTuple hv_ArcType, out HTuple hv_RowCenter, out HTuple hv_ColCenter,
            out HTuple hv_Radius, out HTuple hv_StartPhi, out HTuple hv_EndPhi, out HTuple hv_PointOrder,
            out HTuple hv_ArcAngle)
        {


            // Local iconic variables 

            HObject ho_Contour = null;


            // Local control variables 

            HTuple hv_Length, hv_Length1 = new HTuple();
            HTuple hv_CircleLength = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_Contour);

            hv_StartPhi = new HTuple();
            hv_EndPhi = new HTuple();
            hv_PointOrder = new HTuple();
            hv_ArcAngle = new HTuple();
            try
            {
                //初始化
                hv_RowCenter = 0;
                hv_ColCenter = 0;
                hv_Radius = 0;
                //产生一个空的直线对象，用于保存拟合后的圆
                ho_Circle.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Circle);
                //计算边缘数量
                HOperatorSet.TupleLength(hv_Cols, out hv_Length);
                //当边缘数量不小于有效点数时进行拟合
                if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
                    new HTuple(hv_ActiveNum.TupleGreater(2)))) != 0)
                {
                    //halcon的拟合是基于xld的，需要把边缘连接成xld
                    if ((int)(new HTuple(hv_ArcType.TupleEqual("circle"))) != 0)
                    {
                        //如果是闭合的圆，轮廓需要首尾相连
                        ho_Contour.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows.TupleConcat(hv_Rows.TupleSelect(
                            0)), hv_Cols.TupleConcat(hv_Cols.TupleSelect(0)));
                    }
                    else
                    {
                        ho_Contour.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                    }
                    //拟合圆。使用的算法是''geotukey''，其他算法请参考fit_circle_contour_xld的描述部分。
                    HOperatorSet.FitCircleContourXld(ho_Contour, "geotukey", -1, 0, 0, 3, 2,
                        out hv_RowCenter, out hv_ColCenter, out hv_Radius, out hv_StartPhi, out hv_EndPhi,
                        out hv_PointOrder);
                    //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
                    HOperatorSet.TupleLength(hv_StartPhi, out hv_Length1);
                    if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                    {
                        ho_Contour.Dispose();

                        return;
                    }
                    //根据拟合结果，产生直线xld
                    if ((int)(new HTuple(hv_ArcType.TupleEqual("arc"))) != 0)
                    {
                        //判断圆弧的方向：顺时针还是逆时针
                        //halcon求圆弧会出现方向混乱的问题
                        //tuple_mean (Rows, RowsMean)
                        //tuple_mean (Cols, ColsMean)
                        //gen_cross_contour_xld (Cross, RowsMean, ColsMean, 6, 0.785398)
                        //gen_circle_contour_xld (Circle1, RowCenter, ColCenter, Radius, StartPhi, EndPhi, 'positive', 1)
                        //求轮廓1中心
                        //area_center_points_xld (Circle1, Area, Row1, Column1)
                        //gen_circle_contour_xld (Circle2, RowCenter, ColCenter, Radius, StartPhi, EndPhi, 'negative', 1)
                        //求轮廓2中心
                        //area_center_points_xld (Circle2, Area, Row2, Column2)
                        //distance_pp (RowsMean, ColsMean, Row1, Column1, Distance1)
                        //distance_pp (RowsMean, ColsMean, Row2, Column2, Distance2)
                        //ArcAngle := EndPhi-StartPhi
                        //if (Distance1<Distance2)

                        //PointOrder := 'positive'
                        //copy_obj (Circle1, Circle, 1, 1)
                        //else

                        //PointOrder := 'negative'
                        //if (abs(ArcAngle)>3.1415926)
                        //ArcAngle := ArcAngle-2.0*3.1415926
                        //endif
                        //copy_obj (Circle2, Circle, 1, 1)
                        //endif
                        ho_Circle.Dispose();
                        HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
                            hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, 1);

                        HOperatorSet.LengthXld(ho_Circle, out hv_CircleLength);
                        hv_ArcAngle = hv_EndPhi - hv_StartPhi;
                        if ((int)(new HTuple(hv_CircleLength.TupleGreater(((new HTuple(180)).TupleRad()
                            ) * hv_Radius))) != 0)
                        {
                            if ((int)(new HTuple(((hv_ArcAngle.TupleAbs())).TupleLess((new HTuple(180)).TupleRad()
                                ))) != 0)
                            {
                                if ((int)(new HTuple(hv_ArcAngle.TupleGreater(0))) != 0)
                                {
                                    hv_ArcAngle = ((new HTuple(360)).TupleRad()) - hv_ArcAngle;
                                }
                                else
                                {

                                    hv_ArcAngle = ((new HTuple(360)).TupleRad()) + hv_ArcAngle;
                                }
                            }
                        }
                        else
                        {
                            if ((int)(new HTuple(hv_CircleLength.TupleLess(((new HTuple(180)).TupleRad()
                                ) * hv_Radius))) != 0)
                            {
                                if ((int)(new HTuple(((hv_ArcAngle.TupleAbs())).TupleGreater((new HTuple(180)).TupleRad()
                                    ))) != 0)
                                {
                                    if ((int)(new HTuple(hv_ArcAngle.TupleGreater(0))) != 0)
                                    {
                                        hv_ArcAngle = hv_ArcAngle - ((new HTuple(360)).TupleRad());

                                    }
                                    else
                                    {
                                        hv_ArcAngle = ((new HTuple(360)).TupleRad()) + hv_ArcAngle;
                                    }
                                }
                            }

                        }

                    }
                    else
                    {
                        hv_StartPhi = 0;
                        hv_EndPhi = (new HTuple(360)).TupleRad();
                        hv_ArcAngle = (new HTuple(360)).TupleRad();
                        ho_Circle.Dispose();
                        HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
                            hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, 1);
                    }
                }

                ho_Contour.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Contour.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void pts_to_best_line(out HObject ho_Line, HTuple hv_Rows, HTuple hv_Cols,
            HTuple hv_ActiveNum, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2,
            out HTuple hv_Column2)
        {


            // Local iconic variables 

            HObject ho_Contour = null;


            // Local control variables 

            HTuple hv_Length, hv_Nr = new HTuple(), hv_Nc = new HTuple();
            HTuple hv_Dist = new HTuple(), hv_Length1 = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.GenEmptyObj(out ho_Contour);

            try
            {
                //初始化
                hv_Row1 = 0;
                hv_Column1 = 0;
                hv_Row2 = 0;
                hv_Column2 = 0;
                //产生一个空的直线对象，用于保存拟合后的直线
                ho_Line.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Line);
                //计算边缘数量
                HOperatorSet.TupleLength(hv_Cols, out hv_Length);
                //当边缘数量不小于有效点数时进行拟合
                if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
                    new HTuple(hv_ActiveNum.TupleGreater(1)))) != 0)
                {
                    //halcon的拟合是基于xld的，需要把边缘连接成xld
                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                    //拟合直线。使用的算法是'tukey'，其他算法请参考fit_line_contour_xld的描述部分。
                    HOperatorSet.FitLineContourXld(ho_Contour, "tukey", -1, 0, 5, 2, out hv_Row1,
                        out hv_Column1, out hv_Row2, out hv_Column2, out hv_Nr, out hv_Nc, out hv_Dist);
                    //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
                    HOperatorSet.TupleLength(hv_Dist, out hv_Length1);
                    if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                    {
                        ho_Contour.Dispose();

                        return;
                    }
                    //根据拟合结果，产生直线xld
                    ho_Line.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Line, hv_Row1.TupleConcat(hv_Row2),
                        hv_Column1.TupleConcat(hv_Column2));
                }

                ho_Contour.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Contour.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void rake(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
            HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
            HTuple hv_Transition, HTuple hv_Select, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
            HTuple hv_Column2, out HTuple hv_ResultRow, out HTuple hv_ResultColumn)
        {



            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_RegionLines, ho_Rectangle = null;
            HObject ho_Arrow1 = null;


            // Local control variables 

            HTuple hv_Width, hv_Height, hv_ATan, hv_i;
            HTuple hv_RowC = new HTuple(), hv_ColC = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            HTuple hv_Amplitude = new HTuple(), hv_tRow = new HTuple();
            HTuple hv_tCol = new HTuple(), hv_t = new HTuple(), hv_Number = new HTuple();
            HTuple hv_j = new HTuple();

            HTuple hv_DetectWidth_COPY_INP_TMP = hv_DetectWidth.Clone();
            HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
            HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_RegionLines);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);

            try
            {
                //获取图像尺寸
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //初始化边缘坐标数组
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();
                //产生直线xld
                ho_RegionLines.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
                    hv_Column1.TupleConcat(hv_Column2));
                //存储到显示对象
                OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                SP_O++;
                ho_Regions.Dispose();
                HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_RegionLines, out ho_Regions);
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;
                //计算直线与x轴的夹角，逆时针方向为正向。
                HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

                //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
                hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

                //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
                for (hv_i = 1; hv_i.Continue(hv_Elements, 1); hv_i = hv_i.TupleAdd(1))
                {
                    //RowC := Row1+(((Row2-Row1)*i)/(Elements+1))
                    //ColC := Column1+(Column2-Column1)*i/(Elements+1)
                    //if (RowC>Height-1 or RowC<0 or ColC>Width-1 or ColC<0)
                    //continue
                    //endif
                    //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
                    if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
                    {
                        hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
                        hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
                        hv_DetectWidth_COPY_INP_TMP = hv_Distance.Clone();
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
                    }
                    else
                    {
                        //如果有多个测量矩形，产生该测量矩形xld
                        hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
                        hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_DetectWidth_COPY_INP_TMP / 2);
                    }

                    //把测量矩形xld存储到显示对象
                    OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                    SP_O++;
                    ho_Regions.Dispose();
                    HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Rectangle, out ho_Regions);
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;
                    if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
                    {
                        //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
                        hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        //把xld存储到显示对象
                        OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                        SP_O++;
                        ho_Regions.Dispose();
                        HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Arrow1, out ho_Regions);
                        OTemp[SP_O - 1].Dispose();
                        SP_O = 0;
                    }
                    //产生测量对象句柄
                    HOperatorSet.GenMeasureRectangle2(hv_RowC, hv_ColC, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth_COPY_INP_TMP / 2, hv_Width, hv_Height, "nearest_neighbor",
                        out hv_MsrHandle_Measure);

                    //设置极性
                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
                    {
                        hv_Transition_COPY_INP_TMP = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
                        {

                            hv_Transition_COPY_INP_TMP = "positive";
                        }
                        else
                        {
                            hv_Transition_COPY_INP_TMP = "all";
                        }
                    }
                    //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
                    {
                        hv_Select_COPY_INP_TMP = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
                        {

                            hv_Select_COPY_INP_TMP = "last";
                        }
                        else
                        {
                            hv_Select_COPY_INP_TMP = "all";
                        }
                    }
                    //检测边缘
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
                        out hv_Amplitude, out hv_Distance);
                    //清除测量对象句柄
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);

                    //临时变量初始化
                    //tRow，tCol保存找到指定边缘的坐标
                    hv_tRow = 0;
                    hv_tCol = 0;
                    //t保存边缘的幅度绝对值
                    hv_t = 0;
                    //找到的边缘必须至少为1个
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    //有多个边缘时，选择幅度绝对值最大的边缘
                    for (hv_j = 0; hv_j.Continue(hv_Number - 1, 1); hv_j = hv_j.TupleAdd(1))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_j))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_j);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_j);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_j))).TupleAbs();
                        }
                    }
                    //把找到的边缘保存在输出数组
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {
                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }
                }

                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void spoke(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
            HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
            HTuple hv_Transition, HTuple hv_Select, HTuple hv_ROIRows, HTuple hv_ROICols,
            HTuple hv_Direct, out HTuple hv_ResultRow, out HTuple hv_ResultColumn, out HTuple hv_ArcType)
        {



            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_Contour, ho_ContCircle, ho_Rectangle1 = null;
            HObject ho_Arrow1 = null;


            // Local control variables 

            HTuple hv_Width, hv_Height, hv_RowC, hv_ColumnC;
            HTuple hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder;
            HTuple hv_RowXLD, hv_ColXLD, hv_Length2, hv_WindowHandle = new HTuple();
            HTuple hv_i, hv_j = new HTuple(), hv_RowE = new HTuple(), hv_ColE = new HTuple();
            HTuple hv_ATan = new HTuple(), hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple();
            HTuple hv_ColL2 = new HTuple(), hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            HTuple hv_Amplitude = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_tRow = new HTuple(), hv_tCol = new HTuple(), hv_t = new HTuple();
            HTuple hv_Number = new HTuple(), hv_k = new HTuple();

            HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
            HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);

            hv_ArcType = new HTuple();
            try
            {
                //获取图像尺寸
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //初始化边缘坐标数组
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();

                //产生xld
                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_ROIRows, hv_ROICols);
                //用回归线法（不抛出异常点，所有点权重一样）拟合圆
                HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 3, 2, out hv_RowC,
                    out hv_ColumnC, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);
                //根据拟合结果产生xld，并保持到显示对象
                ho_ContCircle.Dispose();
                HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_RowC, hv_ColumnC, hv_Radius,
                    hv_StartPhi, hv_EndPhi, hv_PointOrder, 3);
                OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                SP_O++;
                ho_Regions.Dispose();
                HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_ContCircle, out ho_Regions);
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;

                //获取圆或圆弧xld上的点坐标
                HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);

                //求圆或圆弧xld上的点的数量
                HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);
                if ((int)(new HTuple(hv_Elements.TupleLess(3))) != 0)
                {
                    disp_message(hv_WindowHandle, "检测的边缘数量太少，请重新设置!", "window",
                        52, 12, "red", "false");
                    ho_Contour.Dispose();
                    ho_ContCircle.Dispose();
                    ho_Rectangle1.Dispose();
                    ho_Arrow1.Dispose();

                    return;
                }
                //如果xld是圆弧，有Length2个点，从起点开始，等间距（间距为Length2/(Elements-1)）取Elements个点，作为卡尺工具的中点
                //如果xld是圆，有Length2个点，以0°为起点，从起点开始，等间距（间距为Length2/(Elements)）取Elements个点，作为卡尺工具的中点
                for (hv_i = 0; hv_i.Continue(hv_Elements - 1, 1); hv_i = hv_i.TupleAdd(1))
                {

                    if ((int)(new HTuple(((hv_RowXLD.TupleSelect(0))).TupleEqual(hv_RowXLD.TupleSelect(
                        hv_Length2 - 1)))) != 0)
                    {
                        //xld的起点和终点坐标相对，为圆
                        HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);
                        hv_ArcType = "circle";
                    }
                    else
                    {
                        //否则为圆弧
                        HOperatorSet.TupleInt(((1.0 * hv_Length2) / (hv_Elements - 1)) * hv_i, out hv_j);
                        hv_ArcType = "arc";
                    }
                    //索引越界，强制赋值为最后一个索引
                    if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
                    {
                        hv_j = hv_Length2 - 1;
                        //continue
                    }
                    //获取卡尺工具中心
                    hv_RowE = hv_RowXLD.TupleSelect(hv_j);
                    hv_ColE = hv_ColXLD.TupleSelect(hv_j);

                    //超出图像区域，不检测，否则容易报异常
                    if ((int)((new HTuple((new HTuple((new HTuple(hv_RowE.TupleGreater(hv_Height - 1))).TupleOr(
                        new HTuple(hv_RowE.TupleLess(0))))).TupleOr(new HTuple(hv_ColE.TupleGreater(
                        hv_Width - 1))))).TupleOr(new HTuple(hv_ColE.TupleLess(0)))) != 0)
                    {
                        continue;
                    }
                    //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
                    if ((int)(new HTuple(hv_Direct.TupleEqual("inner"))) != 0)
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
                        //角度反向
                        hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
                    }
                    else
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
                    }


                    //产生卡尺xld，并保持到显示对象
                    ho_Rectangle1.Dispose();
                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
                        hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
                    OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                    SP_O++;
                    ho_Regions.Dispose();
                    HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Rectangle1, out ho_Regions);
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;
                    //用箭头xld指示边缘搜索方向，并保持到显示对象
                    if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
                    {
                        hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                        SP_O++;
                        ho_Regions.Dispose();
                        HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Arrow1, out ho_Regions);
                        OTemp[SP_O - 1].Dispose();
                        SP_O = 0;
                    }


                    //产生测量对象句柄
                    HOperatorSet.GenMeasureRectangle2(hv_RowE, hv_ColE, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);

                    //设置极性
                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
                    {
                        hv_Transition_COPY_INP_TMP = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
                        {

                            hv_Transition_COPY_INP_TMP = "positive";
                        }
                        else
                        {
                            hv_Transition_COPY_INP_TMP = "all";
                        }
                    }
                    //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
                    {
                        hv_Select_COPY_INP_TMP = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
                        {

                            hv_Select_COPY_INP_TMP = "last";
                        }
                        else
                        {
                            hv_Select_COPY_INP_TMP = "all";
                        }
                    }
                    //检测边缘
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
                        out hv_Amplitude, out hv_Distance);
                    //清除测量对象句柄
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
                    //临时变量初始化
                    //tRow，tCol保存找到指定边缘的坐标
                    hv_tRow = 0;
                    hv_tCol = 0;
                    //t保存边缘的幅度绝对值
                    hv_t = 0;
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    //找到的边缘必须至少为1个
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    //有多个边缘时，选择幅度绝对值最大的边缘
                    for (hv_k = 0; hv_k.Continue(hv_Number - 1, 1); hv_k = hv_k.TupleAdd(1))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_k))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_k);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_k);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_k))).TupleAbs();
                        }
                    }
                    //把找到的边缘保存在输出数组
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {

                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }
                }


                ho_Contour.Dispose();
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Contour.Dispose();
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }


        public void Write_Image(HObject Image, string Path)
        {
            //图像为空，不保存
            if (Image.IsInitialized() == false)
            {
                return;
            }
            int nPos;
            string ImageType;
            //创建路径
            ZazaniaoDll.CreateAllDirectoryEx(Path);

            //通常保存文件的路径格式为xxxx.xxx，最后一个.后的字符为图像的扩展名，获取扩展名，作为write_image的输入参数
            //从右边开始，查询.的位置

            nPos = Path.LastIndexOf('.');
            if (nPos > -1)
            {
                //获取图像扩展名
                ImageType = Path.Substring(nPos + 1, Path.Length - nPos - 1);
            }
            else
                ImageType = "bmp";
            //保存图像
            HOperatorSet.WriteImage(Image, ImageType, 0, Path);
        }
        public bool Read_Image(ref HObject Image, string Path)
        {
            //文件是否存在
            if (!ZazaniaoDll.FileExistEx(Path))
            {
                return false;
            }
            Image.Dispose();
            HOperatorSet.ReadImage(out Image, Path);
            return true;
        }

        public void Write_Tuple(HTuple Tuple, string Path)
        {
            //数组为空，不保存
            if (Tuple.Length == 0)
            {
                return;
            }
            ZazaniaoDll.CreateAllDirectoryEx(Path);
            HOperatorSet.WriteTuple(Tuple, Path);
        }

        public bool Read_Tuple(ref  HTuple Tuple, string Path)
        {
            //文件是否存在
            if (!ZazaniaoDll.FileExistEx(Path))
            {
                return false;
            }
            Tuple = new HTuple();
            HOperatorSet.ReadTuple(Path, out Tuple);
            return true;
        }

        public void Write_Region(HObject Region, string Path)
        {
            //区域为空，不保存
            if (!Region.IsInitialized())
            {
                return;
            }
            ZazaniaoDll.CreateAllDirectoryEx(Path);
            HOperatorSet.WriteRegion(Region, Path);
        }

        public bool Read_Region(ref  HObject Region, string Path)
        {
         
            //文件是否存在
            if (!ZazaniaoDll.FileExistEx(Path))
            { 
                return false;
            }
          Region.Dispose();
            HOperatorSet.ReadRegion(out Region, Path);
            return true;
        }

        public void Write_Model(HTuple ModelID, string Path)
        {
            //模板为空，不保存
            if (ModelID < 0)
            {
                return;
            }
            ZazaniaoDll.CreateAllDirectoryEx(Path);
            HOperatorSet.WriteShapeModel(ModelID, Path);
        }

        public bool Read_Model(ref HTuple ModelID, string Path)
        {
           
            //文件是否存在
            if (!ZazaniaoDll.FileExistEx(Path))
            {
                return false;
            }
            if (ModelID > -1)
            {
                HOperatorSet.ClearShapeModel(ModelID);
                ModelID = -1;
            }
            HOperatorSet.ReadShapeModel(Path, out ModelID);
            return true;
        }

        public void UpdateImage(HObject Image,			//图像
                                ref  HObject objDisp,		//显示图形
                                 HTuple hWindowHandle,	//窗口句柄
                                 bool bInitial = false			//是否对图形进行初始化操作
                                 )
        {
            //复位显示图形
            if (bInitial == true)
            {
               // objDisp.Dispose();
                HOperatorSet.GenEmptyObj(out objDisp);
            }
            //清楚显示窗口
            //	HOperatorSet.ClearWindow(hWindowHandle);
            //显示图像
            HOperatorSet.DispObj(Image, hWindowHandle);
            //显示图形
            if (objDisp.IsInitialized() && !bInitial)
            {
                HOperatorSet.DispObj(objDisp, hWindowHandle);
            }


        }
        public void Concat_Obj(ref HObject Obj1, ref HObject Obj2, ref  HObject Obj3)
        {
            if (!Obj1.IsInitialized())
            {
                HOperatorSet.GenEmptyObj(out  Obj1);
            }
            if (!Obj2.IsInitialized())
            {
                HOperatorSet.GenEmptyObj(out Obj2);
            }
            //             if (!(Obj1.IsInitialized()) || (Obj1.CountObj() < 1))
            //             {
            //                 HOperatorSet.CopyObj(Obj1,out Obj3,1,-1);
            //             }
            //             else
            {
                HOperatorSet.ConcatObj(Obj1, Obj2, out Obj3);
                HTuple Count = Obj3.CountObj();

            }
        }

        public void Find_Shape_Model(HObject Image,		//图形
                                             ref  HObject objDisp,		//显示图形
                                              HTuple ModelID,		//模板
                                              HObject ModelRegion,	//模板区域
                                              out HTuple HomMat2D,		//ROI仿射变换矩阵
                                               out s_CheckError Error
                                              )
        {

            HomMat2D = 0;
            HTuple Row, Column, Angle, Score, Area, Row0, Col0, HomMat2D_T;

            HObject Contour, Cross;
            HOperatorSet.GenEmptyObj(out Contour);
            HOperatorSet.GenEmptyObj(out Cross);
            try
            {
                //判断图像是否为空
                if (!ObjectValided(Image))
                {
                    Error.iErrorType = 1;
                    Error.strErrorInfo = "图像为空!";
                    return;
                }
                //判断模板是否为空
                if (ModelID < 0)
                {
                    Error.iErrorType = 2;
                    Error.strErrorInfo = "定位模板为空!";
                    return;
                }
             
                //仿射变换矩阵复位
                HomMat2D = new HTuple();

                //几何定位
                HOperatorSet.FindShapeModel(Image, ModelID, (new HTuple(-10)).TupleRad(), (new HTuple(60)).TupleRad(), 0.4, 1, 0.5, "least_squares", 0, 0.9, out Row, out Column, out Angle, out Score);
          //      HOperatorSet.FindShapeModel(Image, ModelID, (new HTuple(-180)).TupleRad(), (new HTuple(360)).TupleRad(), 0.5, 1, 0.5, "least_squares", 0, 0.9, out Row, out Column, out Angle, out Score);

                HTuple Angle_PI = Angle * 180 / 3.14;
                //如果定位到有物体，跳转到if里面。注：定位后，一定要进行此判断
                if (Angle_PI >-10)
                {
                    //显示模板轮廓和模板中心
                    //产生模板轮廓仿射变换矩阵
                    HOperatorSet.VectorAngleToRigid(0, 0, 0, Row, Column, Angle, out HomMat2D_T);
                    //获取模板轮廓
                    Contour.Dispose();
                    HOperatorSet.GetShapeModelContours(out Contour, ModelID, 1);
                    //对模板轮廓进行仿射变换
                    HOperatorSet.AffineTransContourXld(Contour, out Contour, HomMat2D_T);
                    //把模板轮廓添加到显示图形
                    Concat_Obj(ref objDisp, ref Contour, ref objDisp);
                    //在模板中心产生一个x，表示模板中心
                    Cross.Dispose();
                    HOperatorSet.GenCrossContourXld(out Cross, Row, Column, 20, (new HTuple(45)).TupleRad());
                    //把模板中心x添加到显示图形
                    Concat_Obj(ref objDisp, ref Cross, ref objDisp);

                    //产生ROI仿射变换矩阵
                    //计算模板区域中心
                    //HOperatorSet.AreaCenter(ModelRegion, out Area, out Row0, out Col0);
                    //产生ROI仿射变换矩阵
                    //HOperatorSet.VectorAngleToRigid(Row0, Col0, 0, Row, Column, Angle, out HomMat2D);
                    //0表示OK，非0表示异常
                    Error.iErrorType = 0;
                    Error.strErrorInfo = "定位成功!";
                }
                else
                {
                    Error.iErrorType = 3;
                    Error.strErrorInfo = "定位失败!";
                }

            }

          //  catch (HalconException HDevExpDefaultException)
            catch(Exception ex)
            {
                Error.iErrorType = -1;
                Error.strErrorInfo = "定位过程失败!";
                Log(ex.Message);
   //             throw HDevExpDefaultException;

            }
             Contour.Dispose();
             Cross.Dispose();
        }

        public bool ObjectValided(HObject Obj)
        {

            if (!Obj.IsInitialized())
            {
                return false;
            }
            if (Obj.CountObj() < 1)
            {
                return false;
            }
            return true;
        }

        public void Fit_Line(HObject Image,			//图像
                                     ref HObject objDisp,			//显示图形
                                      HTuple HomMat2D,			//ROI仿射变换矩阵
                                      int Elements,				//找边缘点的数量，即卡尺工具的数量
                                      int Threshold,			//边缘阈值
                                      double Sigma,				//边缘滤波系数
                                      string Transition,		//边缘极性
                                      string Point_Select,		//边缘点的选择
                                      HTuple ROI_X,				//rake工具x数组
                                      HTuple ROI_Y,				//rake工具y数组
                                      int Caliper_Height,		//卡尺工具高度
                                      int Caliper_Width,		//卡尺工具宽度
                                      int Min_Points_Num,		//最小有效点数，即边缘点数要大于等于该值
                                      out HObject Caliper_Regions,	//产生的卡尺工具图形
                                      out HTuple Edges_X,			//找到的边缘点x数据
                                      out HTuple Edges_Y,			//找到的边缘点y数据
                                      out HObject Result_xld,		//拟合得到的直线
                                      out HTuple Result_X,			//拟合得到的直线的点的x数组
                                      out HTuple Result_Y,			//拟合得到的直线的点的y数组
                                      out  s_CheckError Error
                                      )
        {
            HObject Cross;
            HOperatorSet.GenEmptyObj(out Cross);
            HOperatorSet.GenEmptyObj(out Caliper_Regions);
            HOperatorSet.GenEmptyObj(out Result_xld);
            Edges_X = new HTuple();
            Edges_Y = new HTuple();
            Result_X = new HTuple();
            Result_Y = new HTuple();
    
            try
            {
                //判断图像是否为空
                if (!ObjectValided(Image))
                {
                    Error.iErrorType = 1;
                    Error.strErrorInfo = "图像为空!";
                    return;
                }
                HTuple Row0, Row1, Col0, Col1;

                //判断rake工具的ROI是否有效
                if (ROI_Y.Length < 2)
                {
                    Error.iErrorType = 4;
                    Error.strErrorInfo = "直线ROI不正确!";
                    Cross.Dispose();
                    return;
                }
                //判断ROI仿射变换矩阵是否有效，有效的时候，有6个数据 
                if (HomMat2D.Length < 6)
                {
                    //矩阵无效，直接用原始ROI执行rake工具找边缘点
                    Result_xld.Dispose();
                    rake(Image, out Caliper_Regions, Elements, Caliper_Height, Caliper_Width, Sigma, Threshold,
                    Transition, Point_Select, ROI_Y[0], ROI_X[0],
                    ROI_Y[1], ROI_X[1], out Edges_Y, out Edges_X);
                }
                else
                {
                    HTuple New_ROI_Y, New_ROI_X;
                    //矩阵有效，先产生新的ROI,用新的ROI执行rake工具找边缘点
                    HOperatorSet.AffineTransPoint2d(HomMat2D, ROI_Y, ROI_X, out New_ROI_Y, out New_ROI_X);
                    rake(Image, out Caliper_Regions, Elements, Caliper_Height, Caliper_Width, Sigma, Threshold,
                    Transition, Point_Select, New_ROI_Y[0], New_ROI_X[0], New_ROI_Y[1], New_ROI_X[1], out Edges_Y, out Edges_X);
                }
                //把产生的卡尺工具图像添加到显示图形
                Concat_Obj(ref objDisp, ref Caliper_Regions, ref objDisp);

                //判断是否找到有边缘点，如果有，产生边缘点x图形，并添加到显示图形
                if (Edges_Y.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out Cross, Edges_Y, Edges_X, 20, (new HTuple(45)).TupleRad());
                    Concat_Obj(ref objDisp, ref Cross, ref objDisp);
                }
                //如果边缘点数大于等于最小点数，进行直线拟合；否则返回错误信息
                if (Edges_Y.Length >= Min_Points_Num)
                {
                    //拟合直线
                    pts_to_best_line(out Result_xld, Edges_Y, Edges_X, Min_Points_Num, out Row0, out Col0, out Row1, out Col1);
                    //把直线的点添加到结果数组
                    Result_Y = Row0.TupleConcat(Row1);
                    Result_X = Col0.TupleConcat(Col1);
                    //把拟合的直线图形添加到显示图形
                    Concat_Obj(ref objDisp, ref Result_xld, ref objDisp);
                    Error.iErrorType = 0;
                    Error.strErrorInfo = "拟合直线成功!";
                }
                else
                {
                    Error.iErrorType = 5;
                    Error.strErrorInfo = "拟合直线找到的边缘点太少!";
                }

            }
            catch (HalconException HDevExpDefaultException)
            {

                Cross.Dispose();
                Error.iErrorType = -1;
                Error.strErrorInfo = "拟合直线过程失败!";
                Log(HDevExpDefaultException.Message);
 //               throw HDevExpDefaultException;
            }
            Cross.Dispose();

        }

        public void Fit_Circle(HObject Image,				//图像
                                        ref HObject objDisp,			//显示图形
                                        HTuple HomMat2D,			//ROI仿射变换矩阵
                                        int Elements,				//找边缘点的数量，即卡尺工具的数量
                                        int Threshold,				//边缘阈值
                                        double Sigma,				//边缘滤波系数
                                        string Transition,			//边缘极性
                                        string Point_Select,		//边缘点的选择
                                        string Direct,				//边缘点搜索方向,inner指向圆心，outer远离圆心
                                        HTuple ROI_X,				//spoke工具x数组
                                        HTuple ROI_Y,				//spoke工具y数组
                                        int Caliper_Height,			//卡尺工具高度
                                        int Caliper_Width,			//卡尺工具宽度
                                        int Min_Points_Num,			///最小有效点数，即边缘点数要大于等于该值
                                        out HObject Caliper_Regions,	//产生的卡尺工具图形
                                        out HTuple Edges_X,			//找到的边缘点x数据
                                        out HTuple Edges_Y,			//找到的边缘点y数据
                                        out HObject Result_xld,		//拟合得到的圆的图形
                                        out HTuple Result_Center_X,	//拟合得到的圆心x坐标
                                        out HTuple Result_Center_Y,	//拟合得到的圆心y坐标
                                        out HTuple Result_Radius,		//拟合得到的圆的半径
                                        out s_CheckError Error
                                        )
        {
            HObject Cross;
            HOperatorSet.GenEmptyObj(out Cross);
            HOperatorSet.GenEmptyObj(out Caliper_Regions);
            HOperatorSet.GenEmptyObj(out Result_xld);
            Edges_X = new HTuple();
            Edges_Y = new HTuple();
            Result_Center_X = new HTuple();
            Result_Center_Y = new HTuple();
            Result_Radius = new HTuple();

            try
            {
                //判断图像是否为空
                if (!ObjectValided(Image))
                {
                    Error.iErrorType = 1;
                    Error.strErrorInfo = "图像为空!";
                    return;
                }
                HTuple Row0, Row1, Col0, Col1, ArcType;


                //判断spoke的ROI是否正确
                if (ROI_Y.Length < 4)
                {
                    Error.iErrorType = 2;
                    Error.strErrorInfo = "圆ROI不正确!";
                    return;
                }
                //判断ROI仿射矩阵是否有效
                if (HomMat2D.Length < 6)
                {
                    //矩阵无效，用原来的ROI执行spoke工具找点
                    spoke(Image, out Caliper_Regions, Elements, Caliper_Height, Caliper_Width,
                    Sigma, Threshold, (Transition), (Point_Select),
                    ROI_Y, ROI_X, (Direct), out Edges_Y, out Edges_X, out ArcType);
                }
                else
                {
                    HTuple New_ROI_Y, New_ROI_X;
                    //矩阵有效，仿射变换产生新的ROI
                    HOperatorSet.AffineTransPoint2d(HomMat2D, ROI_Y, ROI_X, out New_ROI_Y, out New_ROI_X);
                    //用新的ROI执行spoke工具找点
                    spoke(Image, out Caliper_Regions, Elements, Caliper_Height, Caliper_Width,
                    Sigma, Threshold, (Transition), (Point_Select),
                    New_ROI_Y, New_ROI_X, (Direct), out Edges_Y, out Edges_X, out ArcType);

                }
                //把卡尺工具图形添加到显示图形
                Concat_Obj(ref objDisp, ref Caliper_Regions, ref objDisp);
                //判断找到的边缘点是否有效
                if (Edges_Y.Length > 0)
                {
                    //有效，产生边缘点x图形，并添加到显示图形
                    HOperatorSet.GenCrossContourXld(out Cross, Edges_Y, Edges_X, 20, (new HTuple(45)).TupleRad());
                    Concat_Obj(ref objDisp, ref Cross, ref objDisp);
                }
                //判断边缘点数是否大于等于最小有效点数
                if (Edges_Y.Length >= Min_Points_Num)
                {
                    Result_xld.Dispose();
                    //如果是，拟合圆
                    HTuple ArcAngle;
                    HTuple StartPhi, EndPhi, PointOrder;
                    pts_to_best_circle(out Result_xld, Edges_Y, Edges_X, Min_Points_Num, ArcType,
                        out Result_Center_Y, out Result_Center_X, out Result_Radius, out StartPhi, out EndPhi, out PointOrder, out ArcAngle);
                    //拟合得到的圆图形添加到显示图形
                    Concat_Obj(ref objDisp, ref Result_xld, ref objDisp);

                    //返回错误信息
                    Error.iErrorType = 0;
                    Error.strErrorInfo = "拟合圆成功";
                }
                else
                {
                    Error.iErrorType = 2;
                    Error.strErrorInfo = "拟合圆找到的边缘点太少!";
                }


            }

            catch (HalconException HDevExpDefaultException)
            {
                Cross.Dispose();

                Error.iErrorType = -1;
                Error.strErrorInfo = "拟合圆过程失败!";
               // throw HDevExpDefaultException;
                Log(HDevExpDefaultException.Message);
            }
            Cross.Dispose();

        }

        public void Measure(HObject Image,				//图像
                                     ref HObject objResultDisp,	//显示图形
                                     HTuple hWindowHandle,		//窗口句柄
                                     out HTuple ResultString,		//结果字符串数组
                                     out s_CheckError Error
                                     )
        {
            HTuple t1, t2;
            HOperatorSet.CountSeconds(out t1);
            ResultString = new HTuple();
            HObject objDisp;
            HOperatorSet.GenEmptyObj(out objDisp);
            try
            {

//                SysParam SysParam = this.SysParam;
                //判断类型是否为空
                if (SysParam.m_Type == "")
                {
                    Error.iErrorType = 1;
                    Error.strErrorInfo = "类型为空";
                    disp_message(hWindowHandle, (Error.strErrorInfo), "window", 20, 20, "red", "false");

                    return;
                }
                if (SysParam.m_bStart)
                {
                    //物料的数量加1
                    SysParam.m_nTotal++;
                }
                //初始化图形并显示图像
                 UpdateImage(Image, ref objResultDisp, hWindowHandle, true);
                HTuple HomMat2D;
               
                //距离数值初始化
                SysParam.m_Dis = -10000;
                //集合定位，产生ROI仿射变换矩阵
//                Model Model = Vision.Model;
                objDisp.Dispose();
                Find_Shape_Model(Image, ref objDisp, Model.m_ModelID, Model.m_ModelRegion, out HomMat2D, out Error);
                HOperatorSet.CountSeconds(out t2);
                ZazaniaoDll.LogEx(Directory.GetCurrentDirectory() + "\\Log\\proc.csv", "findshape," + Convert.ToString(Math.Abs(t2[0].D - t1[0].D) * 1000.0), false, "");
                
                //添加显示图形
                Concat_Obj(ref objDisp, ref objResultDisp, ref objResultDisp);
                //添加结果字符串
                ResultString = (Error.strErrorInfo);

                //判断定位是否出错
                if (Error.iErrorType != 0)
                {
                    //显示图形和图像
                    UpdateImage(Image, ref objResultDisp, hWindowHandle);
                    //在图像窗口显示提示信息
                    disp_message(hWindowHandle, ResultString, "window", 20, 20, "red", "false");
                    Log(Error.strErrorInfo);
                    objDisp.Dispose();
                    return;
                }

                //拟合直线
 //               LineParam LineParam = Vision.LineParam;
                objDisp.Dispose();
                Fit_Line(Image, ref objDisp, HomMat2D, LineParam.m_Line_Elements, LineParam.m_Line_Threshold, LineParam.m_Line_Sigma,
                                              LineParam.m_Line_Transition, LineParam.m_Line_Point_Select, LineParam.m_Line_ROI_X, LineParam.m_Line_ROI_Y, LineParam.m_Line_Caliper_Height, LineParam.m_Line_Caliper_Width,
                                              LineParam.m_Line_Min_Points_Num, out LineParam.m_Line_Regions, out LineParam.m_Line_Edges_X, out LineParam.m_Line_Edges_Y,
                                              out LineParam.m_Line_xld, out LineParam.m_Line_X, out LineParam.m_Line_Y, out Error);
                HOperatorSet.CountSeconds(out t1);
                 ZazaniaoDll.LogEx(Directory.GetCurrentDirectory() + "\\Log\\proc.csv","fitline,"+ Convert.ToString(Math.Abs(t2[0].D - t1[0].D) * 1000.0), false, "");
     
                //添加图形
                Concat_Obj(ref objResultDisp, ref objDisp, ref objResultDisp);
                //添加结果字符串
                ResultString.TupleConcat(Error.strErrorInfo);

                //判断拟合直线是否出错
                if (Error.iErrorType != 0)
                {
                    UpdateImage(Image, ref objResultDisp, hWindowHandle);
                    disp_message(hWindowHandle, ResultString, "window", 20, 20, "red", "false");
                    objDisp.Dispose();
                    return;
                }

                //拟合圆
//                CircleParam CircleParam = Vision.CircleParam;
                objDisp.Dispose();
                Fit_Circle(Image, ref objDisp, HomMat2D, CircleParam.m_Circle_Elements, CircleParam.m_Circle_Threshold, CircleParam.m_Circle_Sigma,
                                              CircleParam.m_Circle_Transition, CircleParam.m_Circle_Point_Select, CircleParam.m_Circle_Direct, CircleParam.m_Circle_ROI_X, CircleParam.m_Circle_ROI_Y, CircleParam.m_Circle_Caliper_Height, CircleParam.m_Circle_Caliper_Width,
                                              CircleParam.m_Circle_Min_Points_Num, out CircleParam.m_Circle_Regions, out CircleParam.m_Circle_Edges_X, out CircleParam.m_Circle_Edges_Y,
                                              out CircleParam.m_Circle_xld, out CircleParam.m_Circle_Center_X, out CircleParam.m_Circle_Center_Y, out CircleParam.m_Circle_Radius, out Error);
                HOperatorSet.CountSeconds(out t2);
                 ZazaniaoDll.LogEx(Directory.GetCurrentDirectory() + "\\Log\\proc.csv", "fitcircle," + Convert.ToString(Math.Abs(t2[0].D - t1[0].D) * 1000.0), false, "");
     
                //添加图形
                Concat_Obj(ref objResultDisp, ref objDisp, ref objResultDisp);
                //添加结果字符串
                ResultString.TupleConcat(Error.strErrorInfo);

                //判断拟合圆是否出错
                if (Error.iErrorType != 0)
                {
                    UpdateImage(Image, ref objResultDisp, hWindowHandle);
                    disp_message(hWindowHandle, ResultString, "window", 20, 20, "red", "false");
                    objDisp.Dispose();
                    return;
                }
                //求圆心到直线的距离
                HOperatorSet.DistancePl(CircleParam.m_Circle_Center_Y, CircleParam.m_Circle_Center_X, LineParam.m_Line_Y[0],
                    LineParam.m_Line_X[0], LineParam.m_Line_Y[1], LineParam.m_Line_X[1], out SysParam.m_Dis);



                //把距离由图像坐标系转化到世界坐标系

                SysParam.m_Dis = SysParam.m_Dis * SysParam.m_Scale;

                HTuple ProjRow, ProjCol;
                //求圆心到直线的垂足，用于产生圆心到直线的垂线
                HOperatorSet.ProjectionPl(CircleParam.m_Circle_Center_Y, CircleParam.m_Circle_Center_X, LineParam.m_Line_Y[0], LineParam.m_Line_X[0], LineParam.m_Line_Y[1], LineParam.m_Line_X[1], out ProjRow, out ProjCol);
                HObject Line;
                HOperatorSet.GenEmptyObj(out Line);
                //产生垂足到直线起点的连线
                HOperatorSet.GenRegionLine(out Line, ProjRow, ProjCol, LineParam.m_Line_Y[0], LineParam.m_Line_X[0]);
                Concat_Obj(ref objResultDisp, ref Line, ref objResultDisp);
                //产生垂足到直线终点的连线
                Line.Dispose();
                HOperatorSet.GenRegionLine(out Line, ProjRow, ProjCol, LineParam.m_Line_Y[1], LineParam.m_Line_X[1]);
                Concat_Obj(ref objResultDisp, ref Line, ref objResultDisp);

                //产生垂足到圆心的连线
                Line.Dispose();
                HOperatorSet.GenRegionLine(out Line, ProjRow, ProjCol, CircleParam.m_Circle_Center_Y, CircleParam.m_Circle_Center_X);
                Concat_Obj(ref objResultDisp, ref Line, ref objResultDisp);
                Line.Dispose();
                //显示图像和图形
                HOperatorSet.SetColor(hWindowHandle, "green");
                UpdateImage(Image, ref objResultDisp, hWindowHandle);

                
                bool bResult;
                ResultString = ResultString.TupleConcat("测量距离成功");
                ResultString = ResultString.TupleConcat("Dis=" + SysParam.m_Dis + " mm");
                //显示结果字符串。包含了每步的执行结果，距离的数字，和NG还是OK
                if (SysParam.m_Dis >= SysParam.m_Dis_Min && SysParam.m_Dis <= SysParam.m_Dis_Max)
                {
                    if (SysParam.m_bStart)
                    {
                        //ok物料的数量加1
                        SysParam.m_nOK++;
                    }
                    // 		         ResultString=ResultString.TupleConcat("测量距离成功");
                    //             ResultString=ResultString.TupleConcat("Dis="+theApp.m_Dis+" mm");
                    ResultString = ResultString.TupleConcat("OK");
                    disp_message(hWindowHandle, ResultString, "window", 20, 20, "green", "false");



                    bResult = true;
                }
                else
                {

                    ResultString = ResultString.TupleConcat("NG");
                    disp_message(hWindowHandle, ResultString, "window", 20, 20, "red", "false");

                    bResult = false;
                }
                HOperatorSet.CountSeconds(out t1);
               ZazaniaoDll.LogEx(Directory.GetCurrentDirectory() + "\\Log\\proc.csv", "cal," + Convert.ToString(Math.Abs(t2[0].D - t1[0].D) * 1000.0)+"\r\n", false, "");
     
                Error.iErrorType = 0;
                Error.strErrorInfo = "测量结束";


            }
            catch (Exception ex)
            {
                Error.iErrorType = 1;
                Error.strErrorInfo = "测量过程失败";
                UpdateImage(Image, ref objResultDisp, hWindowHandle);
                disp_message(hWindowHandle, ResultString.TupleConcat("测量过程失败!"), "window", 20, 20, "red", "false");
                Log(ex.Message);
            }
            objDisp.Dispose();

        }

        public void Log(string str)
        {
            ZazaniaoDll.LogEx(Directory.GetCurrentDirectory() + "\\Log\\ErrorLog.csv", str, true, "描述");
        }

        internal static void Write_Model(ref HTuple hTuple, string p)
        {
            throw new NotImplementedException();
        }
    }
}
