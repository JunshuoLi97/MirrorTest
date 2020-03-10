using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VisionSetUp
{
    public partial class inputInfoForm : Form
    {
        public inputInfoForm()
        {
            InitializeComponent();
        }
        DataBaseOperate databseoperate = new DataBaseOperate();

        private void button1_Click(object sender, EventArgs e)
        {
            if (numTextBox.Text != "" && nameTextBox.Text != "" && FIDTextBox.Text != "" && IDTextBox.Text != "" && colourTextBox.Text != "" && versionTextBox.Text != "" && deployTextBox.Text != "")
            {
                string find = "SELECT * FROM 源数据 WHERE  零部件代码=" + "'" + IDTextBox.Text.Trim().ToString().ToUpper() + "'";
                string ID = IDTextBox.Text.ToString().Trim().ToUpper();//零部件代码
                string number = numTextBox.Text.ToString().Trim().ToUpper();//零部件编号
                string name = nameTextBox.Text.ToString().Trim().ToUpper();//产品名称
                string version = versionTextBox.Text.ToString().Trim().ToUpper();//型号
                string factory = FIDTextBox.Text.ToString().Trim().ToUpper();//工厂代码
                string colour = colourTextBox.Text.ToString().Trim().ToUpper();//颜色
                string deploy = deployTextBox.Text.ToString().Trim().ToUpper();//配置
                string nameAndDeploy = name + "-" + deploy;//名称和配置

                string insert = "INSERT INTO 源数据(产品名称,颜色,零部件编号,型号,工厂代码,零部件代码,产品名称配置,配置) values('" + name + "','" + colour + "','" + number + "','" + version + "','" + factory + "','" + ID + "','" + nameAndDeploy + "','" + deploy + "')";
                bool flag = databseoperate.AddBarcode(find, insert);
                if (flag == true)
                {
                    this.groupBox1.Show();
                    groupBox1.Text = "添加成功！！";
                    groupBox1.ForeColor = Color.Blue;
                }
                else
                {
                    this.groupBox1.Show();
                    groupBox1.Text = "添加失败~~";
                    groupBox1.ForeColor = Color.Red;
                }
            }
            else
            {
                this.groupBox1.Show();
                groupBox1.Text = "数据输入不全,添加失败~~";
                groupBox1.ForeColor = Color.Red;
            }

            versionTextBox.Clear();
            colourTextBox.Clear();
            IDTextBox.Clear();
            numTextBox.Clear();
            nameTextBox.Clear();
            deployTextBox.Clear();
        }
    }
}
