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

namespace kcsj
{
    public partial class Form2 : Form
    {
        String username;
        public Form2(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        database db = new database();
        private DataTable Getloginfo()
        {
            string oledb = string.Format("SELECT username AS 用户名,password AS 密码,manage AS 管理 FROM loginfo");
            using (OleDbConnection con = new OleDbConnection(db.datasource))
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter odp = new OleDbDataAdapter(oledb, con);
                odp.Fill(ds);
                con.Close();
                return ds.Tables[0];
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = label2.Text + username+"，您好！";
            dataGridView1.DataSource = Getloginfo();
            dataGridView1.ClearSelection();
            CenterToScreen();
            panel1.Top = (Height - panel1.Height) / 2;
            panel1.Left = (Width - panel1.Width) / 2;
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
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr=MessageBox.Show("此项操作将会注销您此次登陆！", "注销提示", MessageBoxButtons.OKCancel);
            if(dr==DialogResult.OK) new Form1().Show();
            else e.Cancel = true;
        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            panel1.Top = (Height - panel1.Height) / 2;
            panel1.Left = (Width - panel1.Width) / 2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3(username).Show();
        }
        private void button99_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK) System.Environment.Exit(0);
            else return;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "查询")
            {
                button5.Visible = false;
                panel2.Visible = true;
                textBox1.Focus();
                button2.Text = "开始查询";
                return;
            }
            else if (button2.Text == "开始查询")
            {
                string str = "";
                str = string.Format("SELECT username AS 用户名,manage AS 管理 FROM loginfo WHERE username LIKE '%{0}%'", textBox1.Text);
                using (OleDbConnection con = new OleDbConnection(db.datasource))
                {
                    DataSet ds = new DataSet();
                    OleDbDataAdapter odp = new OleDbDataAdapter(str, con);
                    odp.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.ClearSelection();
                    con.Close();
                }
                button5.Visible = true;
                textBox1.Clear();
                panel2.Visible = false;
                button2.Text = "查询";
                return;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("此项操作将会注销您此次登陆！", "注销提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel) return;
            else new Form1("YES").Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows.Count;
            if (index <=0)
            {
                MessageBox.Show("请先选中需要操作的用户！", "警告");
                return;
            }
            else if(index>0)
            {
                for (int i = 0;i< dataGridView1.SelectedRows.Count; i++)
                {
                    if(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()=="YES")
                    {
                        MessageBox.Show(dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + "已是管理员，无需授权！", "提示");
                        return;
                    }
                    String str = String.Format("UPDATE loginfo SET manage='YES' WHERE username ='{0}' ",
                        dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    db.numInsertOrDeleteOrUpdate(str);
                }
                MessageBox.Show("操作成功"+db.Cmd_num+"个数据！", "提示");
                db.Cmd_num = 0;
                dataGridView1.DataSource = Getloginfo();
                dataGridView1.ClearSelection();
            }
        }
        private void button4_Click(object sender, EventArgs e)
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
                    if (dataGridView1.SelectedRows[i].Cells[0].Value.ToString() == "YES")
                    {
                        MessageBox.Show(dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + 
                            "是管理员，不能在本软件中删除，如需删除管理员请获取数据库权限并从数据库删除！", "提示");
                        return;
                    }
                    String str = String.Format("DELETE FROM loginfo WHERE username ='{0}' ", 
                        dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    db.numInsertOrDeleteOrUpdate(str);
                }
                MessageBox.Show("操作成功" + db.Cmd_num + "个数据！", "提示");
                db.Cmd_num = 0;
                dataGridView1.DataSource = Getloginfo();
                dataGridView1.ClearSelection();
            }
        }
    }
}
