namespace BitCoin
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rtb_ChatHistory = new System.Windows.Forms.RichTextBox();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.bt_SendMessage = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel_Sell = new System.Windows.Forms.Panel();
            this.Btn_Sell = new System.Windows.Forms.Button();
            this.Btn_Sel_Cal = new System.Windows.Forms.Button();
            this.panel_Buy = new System.Windows.Forms.Panel();
            this.Btn_Buy = new System.Windows.Forms.Button();
            this.Btn_Buy_cal = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.LL_Register = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_Sell.SuspendLayout();
            this.panel_Buy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradeToolStripMenuItem,
            this.newsToolStripMenuItem,
            this.supportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tradeToolStripMenuItem
            // 
            this.tradeToolStripMenuItem.Name = "tradeToolStripMenuItem";
            this.tradeToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tradeToolStripMenuItem.Text = "Profile";
            this.tradeToolStripMenuItem.Click += new System.EventHandler(this.tradeToolStripMenuItem_Click);
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.newsToolStripMenuItem.Text = "News";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.supportToolStripMenuItem.Text = "Support";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutToolStripMenuItem.Text = "About Us";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem1.Text = "About us";
            // 
            // rtb_ChatHistory
            // 
            this.rtb_ChatHistory.Location = new System.Drawing.Point(603, 111);
            this.rtb_ChatHistory.Name = "rtb_ChatHistory";
            this.rtb_ChatHistory.Size = new System.Drawing.Size(167, 408);
            this.rtb_ChatHistory.TabIndex = 7;
            this.rtb_ChatHistory.Text = "";
            // 
            // tb_Message
            // 
            this.tb_Message.Location = new System.Drawing.Point(603, 528);
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(100, 20);
            this.tb_Message.TabIndex = 8;
            // 
            // bt_SendMessage
            // 
            this.bt_SendMessage.Location = new System.Drawing.Point(709, 525);
            this.bt_SendMessage.Name = "bt_SendMessage";
            this.bt_SendMessage.Size = new System.Drawing.Size(61, 23);
            this.bt_SendMessage.TabIndex = 9;
            this.bt_SendMessage.Text = "Send";
            this.bt_SendMessage.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 463);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel_Sell);
            this.tabPage1.Controls.Add(this.panel_Buy);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BTC/USD";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel_Sell
            // 
            this.panel_Sell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Sell.Controls.Add(this.Btn_Sell);
            this.panel_Sell.Controls.Add(this.Btn_Sel_Cal);
            this.panel_Sell.Location = new System.Drawing.Point(298, 169);
            this.panel_Sell.Name = "panel_Sell";
            this.panel_Sell.Size = new System.Drawing.Size(272, 262);
            this.panel_Sell.TabIndex = 1;
            // 
            // Btn_Sell
            // 
            this.Btn_Sell.Location = new System.Drawing.Point(163, 228);
            this.Btn_Sell.Name = "Btn_Sell";
            this.Btn_Sell.Size = new System.Drawing.Size(75, 23);
            this.Btn_Sell.TabIndex = 2;
            this.Btn_Sell.Text = "Sell";
            this.Btn_Sell.UseVisualStyleBackColor = true;
            // 
            // Btn_Sel_Cal
            // 
            this.Btn_Sel_Cal.Location = new System.Drawing.Point(28, 228);
            this.Btn_Sel_Cal.Name = "Btn_Sel_Cal";
            this.Btn_Sel_Cal.Size = new System.Drawing.Size(75, 23);
            this.Btn_Sel_Cal.TabIndex = 1;
            this.Btn_Sel_Cal.Text = "Calculate";
            this.Btn_Sel_Cal.UseVisualStyleBackColor = true;
            // 
            // panel_Buy
            // 
            this.panel_Buy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Buy.Controls.Add(this.Btn_Buy);
            this.panel_Buy.Controls.Add(this.Btn_Buy_cal);
            this.panel_Buy.Location = new System.Drawing.Point(6, 169);
            this.panel_Buy.Name = "panel_Buy";
            this.panel_Buy.Size = new System.Drawing.Size(272, 262);
            this.panel_Buy.TabIndex = 0;
            // 
            // Btn_Buy
            // 
            this.Btn_Buy.Location = new System.Drawing.Point(169, 228);
            this.Btn_Buy.Name = "Btn_Buy";
            this.Btn_Buy.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buy.TabIndex = 1;
            this.Btn_Buy.Text = "Buy";
            this.Btn_Buy.UseVisualStyleBackColor = true;
            // 
            // Btn_Buy_cal
            // 
            this.Btn_Buy_cal.Location = new System.Drawing.Point(28, 228);
            this.Btn_Buy_cal.Name = "Btn_Buy_cal";
            this.Btn_Buy_cal.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buy_cal.TabIndex = 0;
            this.Btn_Buy_cal.Text = "Calculate";
            this.Btn_Buy_cal.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BTC/EUR";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(576, 437);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BTC/GBP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(576, 437);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "USD/EUR";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(576, 437);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "GBP/USD";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // LL_Register
            // 
            this.LL_Register.AutoSize = true;
            this.LL_Register.BackColor = System.Drawing.Color.Transparent;
            this.LL_Register.Location = new System.Drawing.Point(724, 56);
            this.LL_Register.Name = "LL_Register";
            this.LL_Register.Size = new System.Drawing.Size(46, 13);
            this.LL_Register.TabIndex = 16;
            this.LL_Register.TabStop = true;
            this.LL_Register.Text = "Register";
            this.LL_Register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Register_LinkClicked_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(724, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Login";
            // 
            // tb_Email
            // 
            this.tb_Email.ForeColor = System.Drawing.Color.LightGray;
            this.tb_Email.Location = new System.Drawing.Point(603, 27);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(115, 20);
            this.tb_Email.TabIndex = 13;
            this.tb_Email.Text = "E-mail";
            this.tb_Email.TextChanged += new System.EventHandler(this.tb_Email_TextChanged);
            this.tb_Email.Enter += new System.EventHandler(this.tb_Email_Enter);
            this.tb_Email.Leave += new System.EventHandler(this.tb_Email_Leave);
            // 
            // tb_password
            // 
            this.tb_password.ForeColor = System.Drawing.Color.LightGray;
            this.tb_password.Location = new System.Drawing.Point(604, 51);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(114, 20);
            this.tb_password.TabIndex = 14;
            this.tb_password.Text = "Password";
            this.tb_password.Enter += new System.EventHandler(this.tb_password_Enter);
            this.tb_password.Leave += new System.EventHandler(this.tb_password_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BitCoin.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::BitCoin.Properties.Resources.main1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(794, 557);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LL_Register);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tb_Email);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bt_SendMessage);
            this.Controls.Add(this.tb_Message);
            this.Controls.Add(this.rtb_ChatHistory);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel_Sell.ResumeLayout(false);
            this.panel_Buy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.RichTextBox rtb_ChatHistory;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Button bt_SendMessage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.LinkLabel LL_Register;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_Sell;
        private System.Windows.Forms.Button Btn_Sell;
        private System.Windows.Forms.Button Btn_Sel_Cal;
        private System.Windows.Forms.Panel panel_Buy;
        private System.Windows.Forms.Button Btn_Buy;
        private System.Windows.Forms.Button Btn_Buy_cal;
    }
}

