using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kcsj
{
    class database
    {
        public string datasource = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\user.mdb";
        public void InsertOrDeleteOrUpdate(string str)
        {
            using (OleDbConnection con = new OleDbConnection(datasource))
            {
                con.Open();//打开连接
                OleDbCommand cmd = new OleDbCommand(str, con);
                try
                {
                    cmd.ExecuteNonQuery();//执行命令
                }
                catch (Exception)
                {
                    MessageBox.Show("操作失败", "提示");
                    return;
                }
                MessageBox.Show("操作成功", "提示");
                con.Close();
            }
        }
        private int cmd_num = 0;
        public int Cmd_num { get => cmd_num; set => cmd_num = value; }

        public void numInsertOrDeleteOrUpdate(string str)//多项操作
        {
            using (OleDbConnection con = new OleDbConnection(datasource))
            {
                con.Open();//打开连接
                OleDbCommand cmd = new OleDbCommand(str, con);
                try
                {
                    cmd.ExecuteNonQuery();//执行命令
                }
                catch (Exception)
                {
                    return;
                }
                Cmd_num++;
                con.Close();
            }
        }
        public database() { }
        public database(string str)
        {
            datasource = str;
        }
    }
}