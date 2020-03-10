using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisionSetUp
{
    public partial class HistoryDataFind : Form
    {

        DataBaseOperate tempdataoperate = new DataBaseOperate();

        public static DataTable temptable;
        public static string onesql = "日期" ;

        public HistoryDataFind()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string anothersql = "'" + dateTimePicker1.Value.ToLongDateString()+ "'";
            string tableName = "打印过程记录";
            temptable = tempdataoperate.FindData( tableName,anothersql, onesql);
            if (temptable != null)
            {
                dataGridView1.DataSource =temptable;
            }
        }
    }
}
