using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace VisionSetUp
{
    class DataBaseOperate
    {
        public static OleDbConnection staticConn;//全局连接参数
        public static string key = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=标签.mdb";//连接access数据库的字符串
        BarCode barcode = BarCode.GetInstance();

        /// <summary>
        /// 打开名为标签的数据库的链接
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection OpenConnection()
        {
            staticConn = new OleDbConnection(key);
            staticConn.Open();
            return staticConn;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void CloseConnection()
        {
            staticConn.Close();//关闭数据库连接
            staticConn.Dispose();//释放所占用资源
        }

        /// <summary>
        /// 执行fixstring字符串所包含的命令
        /// </summary>////此函数由于函数本身的限制仅适用于插入删除，并不适用于查询~~
        /// <param name="fixstring"></param>
        public void FixDataBase(string fixstring)
        {
            OpenConnection();
            OleDbCommand com = new OleDbCommand(fixstring, staticConn);
            com.ExecuteNonQuery();
            CloseConnection();
        }
        /// <summary>
        /// 查找到需要的结果并返回值
        /// </summary>
        /// <param name="findString"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public System.Data.DataTable FindData(string tableName,string findString, string property)/////findstring2是寻找数据的属性，findstring1是要寻找的数据
        {
            OpenConnection();
            string find = "SELECT * FROM "+tableName+" WHERE " + property + "=" + findString;
            OleDbDataAdapter adapter = new OleDbDataAdapter(find,staticConn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            CloseConnection();
            return ds.Tables[0];
        }
        /// <summary>
        ///下拉框实现快速查找搜索
        /// </summary>
        /// <param name="find"></param>
        /// <returns></returns>
        public AutoCompleteStringCollection fuzzyquery(string sql, string modeFind)
        {
            OpenConnection();
            OleDbCommand com = staticConn.CreateCommand();
            com.CommandText = sql;
            OleDbDataReader reader = com.ExecuteReader();

            var sourse = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                sourse.AddRange(new string[] { reader[modeFind].ToString() });
            }

            CloseConnection();
            return sourse;
        }
        /// <summary>
        /// 返回当前产品的编号
        /// </summary>
        /// <param name="name">通过在打印过的数据中寻找名称来确定下一个打印的产品的名称</param>
        public void count(string name)
        {
            OpenConnection();
            string data =DateTime.Now.ToLongDateString() ;
            OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM 打印过程记录 WHERE 产品名称=" + "'" + name + "'"+"AND 日期 =" + "'" + DateTime.Now.ToLongDateString() + "'", staticConn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0) barcode.count = 10001;
            else
            {
                int tempcount = ds.Tables[0].Rows.Count;
                int max = 0;
                for (int i = 0; i < tempcount; i++)
                {
                    if (int.Parse(ds.Tables[0].Rows[i]["条码计数"].ToString()) > max)
                    {
                        max = int.Parse(ds.Tables[0].Rows[i]["条码计数"].ToString());
                    }
                }
                if (max != 0) barcode.count = max + 1;
            }
            CloseConnection();
        }
      
        public bool AddBarcode(string findString,string addString)//findString是查重的语句，addstring是添加数据的语句
        {
            OpenConnection();
            OleDbDataAdapter adapter = new OleDbDataAdapter(findString, staticConn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if(ds.Tables[0].Rows.Count == 0)
            {
                OleDbCommand command = new OleDbCommand(addString, staticConn);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Operate dataBase failed!! Please connact to JunshuoLi");
                    CloseConnection();
                    return false;
                }       
            }
            else
            {
                CloseConnection();
                return false;
            }
         
        }
    }
}
