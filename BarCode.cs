using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisionSetUp
{
    class BarCode
    {
        /// <summary>
        /// 声明了一个单例类用于全局传值
        /// </summary>
        public static BarCode instance;
        private static object _lock = new object();
        private BarCode()
        {

        }
        public static BarCode GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new BarCode();

                    }
                }
            }
            return instance;
        }

        public string ID = "";//零部件代码
        public string number = "";//零部件编号//////条码
        public string version = "";//型号//////条码
        public string name = "";//产品名称///////条码
        public string FID = "";//工厂代码
        public string colour = "";//颜色////////条码
        public string team = "";//班次/////////条码
        public string bar = "";//一维码信息/////////条码
        public string deploy = "";//括号（配置字母）////////////条码

        public string year = "";//条码上的年代码
        public string month = "";//条码上的月代码
        public string day = "";//条码上的日代码
        public int count = 10000;//条码计数
    }
}
