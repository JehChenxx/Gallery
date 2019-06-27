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
using System.IO;

namespace kcsj
{
    public partial class Form3 : Form
    {
        string username;
        database db = new database();
        public Form3(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private DataTable Getalbum()
        {
            string oledb = string.Format("SELECT albumname AS 相册路径 FROM album WHERE username = '{0}'",username);
            using (OleDbConnection con = new OleDbConnection(db.datasource))
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter odp = new OleDbDataAdapter(oledb, con);
                odp.Fill(ds);
                con.Close();
                return ds.Tables[0];
            }
        }
        private void Form3_Load(object sender, EventArgs e) 
        {
            label3.Text = username + "，您好！";
            CenterToScreen();
            dataGridView1.DataSource = Getalbum();
            dataGridView1.ClearSelection();
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            using (OleDbConnection con = new OleDbConnection(db.datasource))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                    toolStripStatusLabel1.Text = "Database is linked.DataSourse:" + con.DataSource;
                else
                    toolStripStatusLabel1.Text = "Database is not linked";
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text=="新建相册")
            {
                textBox1.Visible = true;
                button1.Text = "开始新建";
                return;
            }
            else if(button1.Text=="开始新建")
            {
                if(Directory.Exists(@Application.StartupPath + "\\users\\" + "\\" + username + "\\" + textBox1.Text))
                {
                    MessageBox.Show("您已存在同名相册，请重新输入！", "错误提示");
                    textBox1.Visible = false;
                    button1.Text = "新建相册";
                    return;
                }
                Directory.CreateDirectory(@Application.StartupPath + "\\users\\" + "\\" + username + "\\" + textBox1.Text);
                string str = "INSERT INTO album VALUES ('"+ Application.StartupPath + "\\users\\" 
                    + username + "\\" + textBox1.Text+"','"+username+"','"+textBox1.Text+"')";
                db.InsertOrDeleteOrUpdate(str);
                dataGridView1.DataSource = Getalbum();
                dataGridView1.ClearSelection();
                textBox1.Visible = false;
                button1.Text = "新建相册";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows.Count;
            if (index <= 0)
            {
                MessageBox.Show("请先选中需要操作的用户！", "警告");
                return;
            }
            else if (index > 0)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    String str = String.Format("DELETE FROM album WHERE path ='{0}' ",
                        Application.StartupPath + "\\users\\" + username + "\\" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    try
                    {
                        Directory.Delete(Application.StartupPath + "\\users\\" + username + "\\" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), false);
                    }
                    catch(Exception)
                    {
                        DialogResult dr = MessageBox.Show("相册内存在文件，确认删除？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.Cancel) return;
                        else if(dr==DialogResult.OK)
                        {
                            Directory.Delete(Application.StartupPath + "\\users\\" + username + "\\" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), true);
                            db.numInsertOrDeleteOrUpdate(str);
                        }
                    }
                    db.numInsertOrDeleteOrUpdate(str);
                }
                MessageBox.Show("操作成功" + db.Cmd_num + "个数据！", "提示");
                db.Cmd_num = 0;
            }
            dataGridView1.DataSource = Getalbum();
            dataGridView1.ClearSelection();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "修改名称")
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("请先选中且仅可选中一位需要操作的用户！", "警告");
                    return;
                }
                textBox1.Visible = true;
                button3.Text = "确认修改";
                return;
            }
            else if (button3.Text == "确认修改")
            {
                if (Directory.Exists(Application.StartupPath + "\\users\\" + "\\" + username + "\\" + textBox1.Text))
                {
                    MessageBox.Show("您已存在同名相册，请重新输入！", "错误提示");
                    textBox1.Visible = false;
                    button3.Text = "修改名称";
                    return;
                }
                Directory.CreateDirectory(Application.StartupPath + "\\users\\" + "\\" + username + "\\" + textBox1.Text);
                Directory.Move(Application.StartupPath + "\\users\\" + "\\" + username + "\\" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                        Application.StartupPath + "\\users\\" + "\\" + username + "\\" + textBox1.Text);
                string str =string.Format( "UPDATE album SET path='{0}' WHERE path ='{1}' ",
                        Application.StartupPath + "\\users\\" + "\\" + username + "\\" + textBox1.Text,
                        Application.StartupPath + "\\users\\" + "\\" + username + "\\" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString()); 
                db.InsertOrDeleteOrUpdate(str);
                dataGridView1.DataSource = Getalbum();
                dataGridView1.ClearSelection();
                textBox1.Visible = false;
                button3.Text = "修改名称";
            }
            




            
        
        dataGridView1.DataSource = Getalbum();
        dataGridView1.ClearSelection();
        }
    }
}
