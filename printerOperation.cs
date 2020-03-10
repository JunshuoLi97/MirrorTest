using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisionSetUp
{
    class printerOperation
    {
        public string printerName = "";//打印机名称
        public string modelPath = Environment.CurrentDirectory.ToString()+"\\模板.btw";
        BarCode barcode = BarCode.GetInstance();
        public  void printBarcode()
        {
            try
            {
                BarTender.Format btFormat;
                BarTender.Application btApp = new BarTender.Application();
                btFormat = btApp.Formats.Open(modelPath, false, "");
                btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;//单词执行打印一共需要打印几份一样的标签
                btFormat.PrintSetup.NumberSerializedLabels = 1;//set the number of the sequenced
                btFormat.PrintOut(false, false);
                btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);//save or not save  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
   
}
