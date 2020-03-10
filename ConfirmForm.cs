using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisionSetUp;

namespace VisionSetUp
{
    public partial class ConfirmForm : Form
    {
        public ConfirmForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            
            string tempPassword = passwordTextBox.Text.Trim();
            int  month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            string truePassword = (month * 300 + day * 2).ToString();
            if (tempPassword == truePassword)
            {

                MainForm.staticForm.groupBox2.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("你的密码不是工程师级密码，请联系工程师索要密码～～");
                this.passwordTextBox.Clear();
            }


        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if((Char.IsNumber(e.KeyChar))&&e.KeyChar!=(char)8)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //   MessageBox.Show("请输入数字！！！！！");
            //}
        }
    }
}
