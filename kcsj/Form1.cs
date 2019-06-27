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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string kind)
        {
            InitializeComponent();
            signup(kind);
        }
        database db = new database();
        String kind = "";
        void signup(string str)
        {
            kind = str;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            button2.Text = "取消";
            label3.Visible = textBox3.Visible = true;
        }
        void unsignup()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            button2.Text = "登陆";
            label3.Visible = textBox3.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            panel1.Top = Height / 2 - panel1.Height / 2;
            panel1.Left = Width / 2 - 50;
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            using (OleDbConnection con = new OleDbConnection(db.datasource))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                    toolStripStatusLabel1.Text = "Database is linked.DataSourse:" + con.DataSource;
                else
                    toolStripStatusLabel1.Text = "Database is not linked";
                string str = String.Format("SELECT * FROM loginfo");
                OleDbCommand cmd1 = new OleDbCommand(str, con);
                OleDbDataReader dr = cmd1.ExecuteReader();
                if (!dr.HasRows)
                {
                    MessageBox.Show("无管理员，请创建第一位管理员！", "无管理员提示");
                    signup("YES");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (textBox3.Visible == false)
            {
                signup("NO");
                return;
            }
            using (OleDbConnection con = new OleDbConnection(db.datasource))
            {
                con.Open();
                string str = String.Format("SELECT username FROM loginfo");
                OleDbCommand cmd1 = new OleDbCommand(str, con);
                OleDbDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    if (textBox1.Text == (String)dr["username"])
                    {
                        MessageBox.Show("用户名已被使用，请重新输入！", "错误提示");
                        i++;
                        break;
                    }
                }
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次密码不一致，请重新输入！", "错误提示");
                i++;
                textBox2.Clear();
                textBox3.Clear();
            }
            if (i == 0)
            {
                db.InsertOrDeleteOrUpdate(string.Format("INSERT INTO loginfo VALUES('{0}','{1}','{2}')", textBox1.Text, textBox2.Text, kind));
                Directory.CreateDirectory(@Application.StartupPath + "\\users\\"+textBox1.Text);
                unsignup();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "取消")
            {
                unsignup();
                return;
            }
            using (OleDbConnection con = new OleDbConnection(db.datasource))
            {
                con.Open();
                string str = String.Format("SELECT * FROM loginfo WHERE username='{0}'", textBox1.Text);
                OleDbCommand cmd1 = new OleDbCommand(str, con);
                OleDbDataReader dr = cmd1.ExecuteReader();
                if (!dr.HasRows)
                {
                    MessageBox.Show("用户名不存在！", "错误提示");
                    return;
                }
                while (dr.Read())
                    if (textBox2.Text != dr["password"].ToString())
                    {
                        MessageBox.Show("密码错误！", "错误提示");
                        dr.Close();
                        return;
                    }
                dr.Close();
                dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["manage"].ToString() == "YES")
                    {

                        DialogResult result = MessageBox.Show("是否进入管理界面?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)  new Form2(dr["username"].ToString()).Show();
                        else if(result==DialogResult.No) new Form3(dr["username"].ToString()).Show();
                    }
                    else
                        new Form3(dr["username"].ToString()).Show();
                }
            }
            AcceptButton = null;
            unsignup();
            this.Hide();
        }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
                textBox2.PasswordChar = textBox3.PasswordChar = new char();
            else if (textBox2.PasswordChar == new char())
                textBox2.PasswordChar = textBox3.PasswordChar = '*';
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Top = Height / 2 - panel1.Height / 2;
            panel1.Left = Width / 2 - 20;
            if (Height < panel1.Height * 2) Height = panel1.Height * 2;
            if (Width < panel1.Width * 2) Width = panel1.Width * 2;
        }
        int x1 = 1, y1 = 1;
        int x2 = 1, y2 = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Left += x1;
            label4.Top += y1;
            label5.Left += x2;
            label5.Top += y2;
            if (label4.Top == panel2.Top) y1 = 1;
            if (label4.Top == panel2.Top +panel2.Height - label4.Height) y1 = -1;
            if (label4.Left == panel2.Left+panel1.Width - label4.Width) x1 = -1;
            if (label5.Top == panel2.Top) y2 = 1;
            if (label5.Top == panel2.Top +panel2.Height - label5.Height) y2 = -1;
            if (label5.Left == panel2.Left) x2 = 1;
            if (label4.Left<=label5.Left+label5.Width)
            {
                x1 = 1;
                x2 = -1;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(result==DialogResult.OK) System.Environment.Exit(0);
            else e.Cancel = true;
        }
    }
}
