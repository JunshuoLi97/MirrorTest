using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seagull.BarTender.Print;
using System.Data.OleDb;

namespace VisionSetUp
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ini文件
        /// 如何触发打印
        /// //
        /// </summary>

        printerOperation printer = new printerOperation();
        Signal signal = Signal.GetInstance();
        BarCode barcode = BarCode.GetInstance();////声明一个全局的对象用来赋值传值
        DataBaseOperate tempFix = new DataBaseOperate();

        public void dealBarcode()
        {

            ///
            ///提前处理条码年月日
            ///
            DateTime currentTime = System.DateTime.Now;
            int tempYear = Convert.ToInt32(currentTime.Year.ToString());
            int tempMonth = Convert.ToInt32(currentTime.Month.ToString());
            int tempDay = Convert.ToInt32(currentTime.Day.ToString());

            if (tempYear == 2018) barcode.year = "J";
            else if (tempYear == 2019) barcode.year = "K";
            else if (tempYear == 2020) barcode.year = "L";
            else if (tempYear == 2021) barcode.year = "M";
            else if (tempYear == 2022) barcode.year = "N";
            else if (tempYear == 2023) barcode.year = "P";
            else if (tempYear == 2024) barcode.year = "R";
            else if (tempYear == 2025) barcode.year = "S";
            else if (tempYear == 2026) barcode.year = "T";
            else if (tempYear == 2027) barcode.year = "V";
            else if (tempYear == 2028) barcode.year = "W";
            else if (tempYear == 2029) barcode.year = "X";
            else if (tempYear == 2030) barcode.year = "Y";
            else if (tempYear == 2031) barcode.year = "1";
            else if (tempYear == 2032) barcode.year = "2";
            else if (tempYear == 2033) barcode.year = "3";
            else if (tempYear == 2034) barcode.year = "4";
            else if (tempYear == 2035) barcode.year = "5";
            else if (tempYear == 2036) barcode.year = "6";
            else if (tempYear == 2037) barcode.year = "7";
            else if (tempYear == 2038) barcode.year = "8";
            else if (tempYear == 2039) barcode.year = "9";
            else if (tempYear == 2040) barcode.year = "A";
            else MessageBox.Show("请升级系统版本~~");

            if (tempMonth < 10) barcode.month = tempMonth.ToString();
            else if (tempMonth == 10) barcode.month = "0";
            else if (tempMonth == 11) barcode.month = "A";
            else if (tempMonth == 12) barcode.month = "B";

            if (tempDay >= 10 && tempDay <= 31) barcode.day = tempDay.ToString();
            else if (tempDay == 1) barcode.day = "01";
            else if (tempDay == 2) barcode.day = "02";
            else if (tempDay == 3) barcode.day = "03";
            else if (tempDay == 4) barcode.day = "04";
            else if (tempDay == 5) barcode.day = "05";
            else if (tempDay == 6) barcode.day = "06";
            else if (tempDay == 7) barcode.day = "07";
            else if (tempDay == 8) barcode.day = "08";
            else if (tempDay == 9) barcode.day = "09";

            //计算当前条码的已打印数量
            tempFix.count(barcode.name);
            barcode.bar = barcode.FID + barcode.ID + barcode.year + barcode.month + barcode.day + barcode.count.ToString();
            barcode.bar = barcode.bar.Trim();
        }
        private void printButton_Click(object sender, EventArgs e)
        {
            if (numTextBox.Text != "" && IDTextBox.Text != "" && nameTextBox.Text != "" && FIDTextBox.Text != "" && versionTextBox.Text != "" && colourTextBox.Text != "" && deployTextBox.Text != "" && teamComboBox.Text != "")
            {
                ///
                ///捕捉配置和班次信息
                ///
                try
                {
                    barcode.team = teamComboBox.Text.Trim().ToString().Trim().ToUpper();//班次信息

                    dealBarcode();
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
                    MessageBox.Show("此项打印成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("参数输入不全，请检查！！！！！！1");
            }
        }

        private void changeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string find;
            string sql;
            this.findTextBox.Clear();
            if (changeComboBox.Text == "产品名称")
            {

                find = "产品名称";
                sql = "SELECT * FROM 源数据 WHERE" + find;
                findTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, find);
                findTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                findTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (changeComboBox.Text == "型号")
            {
                find = "型号";
                sql = "SELECT * FROM 源数据 WHERE" + find;
                findTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, find);
                findTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                findTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (changeComboBox.Text == "零部件编号")
            {
                find = "零部件编号";
                sql = "SELECT * FROM 源数据 WHERE" + find;
                findTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, find);
                findTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                findTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (changeComboBox.Text == "产品名称配置")
            {
                find = "产品名称配置";
                sql = "SELECT * FROM 源数据 WHERE" + find;
                findTextBox.AutoCompleteCustomSource = tempFix.fuzzyquery(sql, find);
                findTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                findTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void ConfimButton_Click(object sender, EventArgs e)
        {
            if (teamComboBox.Text != "")
            {
                ///
                ///捕捉班次信息
                ///
                barcode.team = teamComboBox.Text.Trim().ToString().Trim().ToUpper();//班次信息
                dealBarcode();
                this.Close();
                signal.InputParameter = true; 
            }
            else
            {
                MessageBox.Show("没有选择班次！！！！！！！");
            }

        }

        private void findDataButton_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text == "")
            {
                MessageBox.Show("未输入数据，重新输入~~");
                return;
            }
            else
            {
                string tempID = string.Empty;//零部件代码
                string tempNumber = string.Empty;//零部件编号
                string tempVersion = string.Empty;//型号
                string tempName = string.Empty;//产品名称
                string tempFactoryID = string.Empty;//工厂代码
                string tempColour = string.Empty;//颜色
                string tempDeploy = string.Empty;

                string findstring = string.Empty;
                string property = string.Empty;
                string tableName = "源数据";
                findstring = "'" + findTextBox.Text.ToString().Trim().ToUpper() + "'";//加上单引号
                DataTable tempDataTable = new DataTable();

                if (changeComboBox.Text == "零部件编号") property = "零部件编号";
                else if (changeComboBox.Text == "产品名称配置") property = "产品名称配置";
                tempDataTable = tempFix.FindData(tableName, findstring, property);
                tempID = tempDataTable.Rows[0]["零部件代码"].ToString();
                tempNumber = tempDataTable.Rows[0]["零部件编号"].ToString();
                tempVersion = tempDataTable.Rows[0]["型号"].ToString();
                tempName = tempDataTable.Rows[0]["产品名称"].ToString();
                tempFactoryID = tempDataTable.Rows[0]["工厂代码"].ToString();
                tempColour = tempDataTable.Rows[0]["颜色"].ToString();
                tempDeploy = tempDataTable.Rows[0]["配置"].ToString();

                IDTextBox.Text = tempID;
                numTextBox.Text = tempNumber;
                versionTextBox.Text = tempVersion;
                nameTextBox.Text = tempName;
                FIDTextBox.Text = tempFactoryID;
                colourTextBox.Text = tempColour;
                deployTextBox.Text = tempDeploy;

                ////////////////////////////全局传值

                barcode.ID = tempID;//零部件代码
                barcode.name = tempName;//产品名称
                barcode.number = tempNumber;//零部件编号
                barcode.version = tempVersion;//型号
                barcode.colour = tempColour;//颜色
                barcode.FID = tempFactoryID;//工厂代码
                if (tempDeploy == "不带")
                {
                    barcode.deploy = "";
                }
                else {
                    barcode.deploy = "(" + tempDeploy + ")";//配置
                }
               
            }
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            teamComboBox.SelectedIndex = 0;
        }
    }
}
