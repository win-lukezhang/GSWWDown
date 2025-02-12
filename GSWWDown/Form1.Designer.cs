namespace GSWWDown
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            LogTextBox = new TextBox();
            textBox3 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("等线", 20F);
            label1.Location = new Point(163, 39);
            label1.Name = "label1";
            label1.Size = new Size(565, 57);
            label1.TabIndex = 0;
            label1.Text = "古诗文网音频获取工具";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("等线", 15F);
            label2.Location = new Point(318, 96);
            label2.Name = "label2";
            label2.Size = new Size(273, 41);
            label2.TabIndex = 1;
            label2.Text = "by Luke Zhang";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("等线", 10F);
            label3.Location = new Point(1, 156);
            label3.Name = "label3";
            label3.Size = new Size(147, 28);
            label3.TabIndex = 2;
            label3.Text = "页面链接：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(137, 150);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "https://www.gushiwen.cn/shiwenv_df4cc5e691bd.aspx";
            textBox1.Size = new Size(790, 38);
            textBox1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.Font = new Font("微软雅黑", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1, 270);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(926, 39);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "选择一个音频来源";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("等线", 10F);
            button1.Location = new Point(1, 204);
            button1.Name = "button1";
            button1.Size = new Size(926, 50);
            button1.TabIndex = 5;
            button1.Text = "获取可用的音频来源";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("等线", 10F);
            button2.Location = new Point(1, 326);
            button2.Name = "button2";
            button2.Size = new Size(926, 50);
            button2.TabIndex = 6;
            button2.Text = "获取此音频链接";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LogTextBox
            // 
            LogTextBox.Font = new Font("等线", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LogTextBox.Location = new Point(945, 44);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.PlaceholderText = "Log";
            LogTextBox.ReadOnly = true;
            LogTextBox.ScrollBars = ScrollBars.Both;
            LogTextBox.Size = new Size(457, 454);
            LogTextBox.TabIndex = 7;
            LogTextBox.Text = "日志\r\n这里可能有重要信息！";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("等线", 9F);
            textBox3.Location = new Point(1, 395);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "得到的音频链接";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(926, 33);
            textBox3.TabIndex = 8;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.System;
            button3.Font = new Font("等线", 10F);
            button3.Location = new Point(1, 448);
            button3.Name = "button3";
            button3.Size = new Size(79, 50);
            button3.TabIndex = 9;
            button3.Text = "复制";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.System;
            button4.Font = new Font("等线", 10F);
            button4.Location = new Point(86, 448);
            button4.Name = "button4";
            button4.Size = new Size(189, 50);
            button4.TabIndex = 10;
            button4.Text = "使用 cURL 下载";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.System;
            button5.Font = new Font("等线", 10F);
            button5.Location = new Point(281, 448);
            button5.Name = "button5";
            button5.Size = new Size(189, 50);
            button5.TabIndex = 11;
            button5.Text = "使用 IDM 下载";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.System;
            button6.Font = new Font("等线", 10F);
            button6.Location = new Point(476, 448);
            button6.Name = "button6";
            button6.Size = new Size(263, 50);
            button6.TabIndex = 12;
            button6.Text = "使用 BitsAdmin 下载";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.System;
            button7.Font = new Font("等线", 10F);
            button7.Location = new Point(745, 448);
            button7.Name = "button7";
            button7.Size = new Size(182, 50);
            button7.TabIndex = 13;
            button7.Text = "内置下载";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.FlatStyle = FlatStyle.System;
            button8.Font = new Font("等线", 10F);
            button8.Location = new Point(745, 44);
            button8.Name = "button8";
            button8.Size = new Size(164, 45);
            button8.TabIndex = 14;
            button8.Text = "重启";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.FlatStyle = FlatStyle.System;
            button9.Font = new Font("等线", 10F);
            button9.Location = new Point(745, 95);
            button9.Name = "button9";
            button9.Size = new Size(164, 42);
            button9.TabIndex = 15;
            button9.Text = "关于";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.古诗文网音频获取工具_128;
            pictureBox1.Location = new Point(20, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 507);
            Controls.Add(pictureBox1);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox3);
            Controls.Add(LogTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "古诗文网音频获取工具";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private TextBox LogTextBox;
        private TextBox textBox3;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private PictureBox pictureBox1;
    }
}
