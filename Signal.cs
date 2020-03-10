using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisionSetUp
{
    class Signal
    {
        public static Signal instance;
        private static object _lock = new object();
        private Signal()
        {

        }
        public static Signal GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Signal();

                    }
                }
            }
            return instance;
        }
        public bool TestBegin = false;//通知软件开始测试摄像头
        public bool TestOver = false;//通知plc摄像头检测完成
        public bool InputParameter = false;//控制是否选择好了参数
        public bool print = false;//通知打印机开始打印条码
        public bool printControl=true;//主页打印控制键
    }
}
