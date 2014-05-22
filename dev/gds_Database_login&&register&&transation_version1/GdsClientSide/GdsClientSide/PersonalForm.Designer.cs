namespace GdsClientSide
{
    partial class PersonalForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonLitecoin = new System.Windows.Forms.RadioButton();
            this.radioButtonBitcoin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSell = new System.Windows.Forms.RadioButton();
            this.radioButtonBuy = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTrans = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labJoinDate = new System.Windows.Forms.Label();
            this.labEmail = new System.Windows.Forms.Label();
            this.labLN = new System.Windows.Forms.Label();
            this.labFN = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.labUserId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonLitecoin);
            this.groupBox2.Controls.Add(this.radioButtonBitcoin);
            this.groupBox2.Location = new System.Drawing.Point(29, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 51);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Coins type:";
            // 
            // radioButtonLitecoin
            // 
            this.radioButtonLitecoin.AutoSize = true;
            this.radioButtonLitecoin.Location = new System.Drawing.Point(109, 19);
            this.radioButtonLitecoin.Name = "radioButtonLitecoin";
            this.radioButtonLitecoin.Size = new System.Drawing.Size(62, 17);
            this.radioButtonLitecoin.TabIndex = 43;
            this.radioButtonLitecoin.TabStop = true;
            this.radioButtonLitecoin.Text = "Litecoin";
            this.radioButtonLitecoin.UseVisualStyleBackColor = true;
            // 
            // radioButtonBitcoin
            // 
            this.radioButtonBitcoin.AutoSize = true;
            this.radioButtonBitcoin.Location = new System.Drawing.Point(6, 19);
            this.radioButtonBitcoin.Name = "radioButtonBitcoin";
            this.radioButtonBitcoin.Size = new System.Drawing.Size(57, 17);
            this.radioButtonBitcoin.TabIndex = 42;
            this.radioButtonBitcoin.TabStop = true;
            this.radioButtonBitcoin.Text = "Bitcoin";
            this.radioButtonBitcoin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSell);
            this.groupBox1.Controls.Add(this.radioButtonBuy);
            this.groupBox1.Location = new System.Drawing.Point(29, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 51);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trans type:";
            // 
            // radioButtonSell
            // 
            this.radioButtonSell.AutoSize = true;
            this.radioButtonSell.Location = new System.Drawing.Point(109, 19);
            this.radioButtonSell.Name = "radioButtonSell";
            this.radioButtonSell.Size = new System.Drawing.Size(42, 17);
            this.radioButtonSell.TabIndex = 1;
            this.radioButtonSell.TabStop = true;
            this.radioButtonSell.Text = "Sell";
            this.radioButtonSell.UseVisualStyleBackColor = true;
            // 
            // radioButtonBuy
            // 
            this.radioButtonBuy.AutoSize = true;
            this.radioButtonBuy.Location = new System.Drawing.Point(6, 19);
            this.radioButtonBuy.Name = "radioButtonBuy";
            this.radioButtonBuy.Size = new System.Drawing.Size(43, 17);
            this.radioButtonBuy.TabIndex = 0;
            this.radioButtonBuy.TabStop = true;
            this.radioButtonBuy.Text = "Buy";
            this.radioButtonBuy.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(249, 325);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 64;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTrans
            // 
            this.btnTrans.Location = new System.Drawing.Point(249, 370);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(75, 23);
            this.btnTrans.TabIndex = 63;
            this.btnTrans.Text = "Trans";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 380);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "Address:";
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(104, 373);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(100, 20);
            this.txtAdd.TabIndex = 61;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(104, 328);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 60;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 335);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "amount:";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(339, 150);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(387, 186);
            this.listBox.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "transaction part:";
            // 
            // labJoinDate
            // 
            this.labJoinDate.AutoSize = true;
            this.labJoinDate.Location = new System.Drawing.Point(567, 59);
            this.labJoinDate.Name = "labJoinDate";
            this.labJoinDate.Size = new System.Drawing.Size(10, 13);
            this.labJoinDate.TabIndex = 56;
            this.labJoinDate.Text = "-";
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.Location = new System.Drawing.Point(567, 24);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(10, 13);
            this.labEmail.TabIndex = 55;
            this.labEmail.Text = "-";
            // 
            // labLN
            // 
            this.labLN.AutoSize = true;
            this.labLN.Location = new System.Drawing.Point(336, 59);
            this.labLN.Name = "labLN";
            this.labLN.Size = new System.Drawing.Size(10, 13);
            this.labLN.TabIndex = 54;
            this.labLN.Text = "-";
            // 
            // labFN
            // 
            this.labFN.AutoSize = true;
            this.labFN.Location = new System.Drawing.Point(336, 24);
            this.labFN.Name = "labFN";
            this.labFN.Size = new System.Drawing.Size(10, 13);
            this.labFN.TabIndex = 53;
            this.labFN.Text = "-";
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(95, 59);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(10, 13);
            this.labUserName.TabIndex = 52;
            this.labUserName.Text = "-";
            // 
            // labUserId
            // 
            this.labUserId.AutoSize = true;
            this.labUserId.Location = new System.Drawing.Point(95, 24);
            this.labUserId.Name = "labUserId";
            this.labUserId.Size = new System.Drawing.Size(10, 13);
            this.labUserId.TabIndex = 51;
            this.labUserId.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "join date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "last name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "first name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "user id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "user name: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(588, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 67;
            this.button1.Text = "change password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PersonalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 435);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnTrans);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labJoinDate);
            this.Controls.Add(this.labEmail);
            this.Controls.Add(this.labLN);
            this.Controls.Add(this.labFN);
            this.Controls.Add(this.labUserName);
            this.Controls.Add(this.labUserId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PersonalForm";
            this.Text = "PersonalForm";
            this.Load += new System.EventHandler(this.PersonalForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonLitecoin;
        private System.Windows.Forms.RadioButton radioButtonBitcoin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSell;
        private System.Windows.Forms.RadioButton radioButtonBuy;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labJoinDate;
        private System.Windows.Forms.Label labEmail;
        private System.Windows.Forms.Label labLN;
        private System.Windows.Forms.Label labFN;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labUserId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}