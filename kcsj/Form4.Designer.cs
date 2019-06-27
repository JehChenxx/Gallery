namespace kcsj
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.downbutton = new System.Windows.Forms.Button();
            this.autobutton = new System.Windows.Forms.Button();
            this.modebutton = new System.Windows.Forms.Button();
            this.upbutton = new System.Windows.Forms.Button();
            this.speedlabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(682, 364);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // downbutton
            // 
            this.downbutton.Location = new System.Drawing.Point(0, 107);
            this.downbutton.Name = "downbutton";
            this.downbutton.Size = new System.Drawing.Size(75, 23);
            this.downbutton.TabIndex = 9;
            this.downbutton.Text = "下一张";
            this.downbutton.UseVisualStyleBackColor = true;
            // 
            // autobutton
            // 
            this.autobutton.Location = new System.Drawing.Point(0, 57);
            this.autobutton.Name = "autobutton";
            this.autobutton.Size = new System.Drawing.Size(75, 23);
            this.autobutton.TabIndex = 8;
            this.autobutton.Text = "自动播放";
            this.autobutton.UseVisualStyleBackColor = true;
            // 
            // modebutton
            // 
            this.modebutton.Location = new System.Drawing.Point(0, 155);
            this.modebutton.Name = "modebutton";
            this.modebutton.Size = new System.Drawing.Size(75, 23);
            this.modebutton.TabIndex = 10;
            this.modebutton.Text = "顺序";
            this.modebutton.UseVisualStyleBackColor = true;
            // 
            // upbutton
            // 
            this.upbutton.Location = new System.Drawing.Point(0, 12);
            this.upbutton.Name = "upbutton";
            this.upbutton.Size = new System.Drawing.Size(75, 23);
            this.upbutton.TabIndex = 7;
            this.upbutton.Text = "上一张";
            this.upbutton.UseVisualStyleBackColor = true;
            // 
            // speedlabel
            // 
            this.speedlabel.AutoSize = true;
            this.speedlabel.ForeColor = System.Drawing.Color.Black;
            this.speedlabel.Location = new System.Drawing.Point(3, 197);
            this.speedlabel.Name = "speedlabel";
            this.speedlabel.Size = new System.Drawing.Size(29, 12);
            this.speedlabel.TabIndex = 11;
            this.speedlabel.Text = "速度";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.vScrollBar1);
            this.panel2.Controls.Add(this.speedlabel);
            this.panel2.Controls.Add(this.upbutton);
            this.panel2.Controls.Add(this.modebutton);
            this.panel2.Controls.Add(this.autobutton);
            this.panel2.Controls.Add(this.downbutton);
            this.panel2.Location = new System.Drawing.Point(710, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 446);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(58, 197);
            this.vScrollBar1.Maximum = 5000;
            this.vScrollBar1.Minimum = 500;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 232);
            this.vScrollBar1.TabIndex = 12;
            this.vScrollBar1.Value = 500;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 399);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(682, 48);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "说明：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.vScrollBar2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(721, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 364);
            this.panel1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "剪辑";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 86);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "←";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "→";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "旋转";
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(38, 143);
            this.vScrollBar2.Maximum = 5000;
            this.vScrollBar2.Minimum = 500;
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 221);
            this.vScrollBar2.TabIndex = 20;
            this.vScrollBar2.Value = 500;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "缩放";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 377);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 52);
            this.button3.TabIndex = 13;
            this.button3.Text = "编辑";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button downbutton;
        private System.Windows.Forms.Button autobutton;
        private System.Windows.Forms.Button modebutton;
        private System.Windows.Forms.Button upbutton;
        private System.Windows.Forms.Label speedlabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}