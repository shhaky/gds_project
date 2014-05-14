using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace BitCoin
{
    public partial class Main : Form
    {
        public FatToAccM.FatC_to_AccMClient F_A_proxy; // Fat client to Account Management Proxy
        InstanceContext context;

        public Main()
        {
            InitializeComponent();

            Acc_Mgnt_CallbackService callback1 = new Acc_Mgnt_CallbackService();
            context = new InstanceContext(callback1);
            F_A_proxy = new FatToAccM.FatC_to_AccMClient(context);
        }

        private void LL_Register_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form reg = new Register();
            reg.Show();
        }

        private void tb_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Email_Enter(object sender, EventArgs e)
        {
            if (tb_Email.Text == "E-mail")
            {
                tb_Email.Text = string.Empty;
                tb_Email.ForeColor = Color.Black;
            }
        }

        private void tb_Email_Leave(object sender, EventArgs e)
        {
            if (tb_Email.Text == string.Empty )
            {
                tb_Email.Text = "E-mail";
                tb_Email.ForeColor = Color.LightGray;
            }
        }

        private void tb_password_Enter(object sender, EventArgs e)
        {
            if (tb_password.Text == "Password")
            {
                tb_password.Text = string.Empty;
                tb_password.ForeColor = Color.Black;
                tb_password.PasswordChar = '*';
            }
        }

        private void tb_password_Leave(object sender, EventArgs e)
        {
            if (tb_password.Text == string.Empty)
            {
                tb_password.Text = "Password";
                tb_password.ForeColor = Color.LightGray;
                tb_password.PasswordChar = '\0' ;
            }
        }

        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form profile = new Profile();
            profile.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int severLogInfo;

            if ((this.tb_Email.Text == "") || (this.tb_password.Text == ""))
            {
                this.lblInfo.Visible = true;
                this.lblInfo.Text = "Please Fill all the Field first!";
            }
            else
            {
                try
                {
                    severLogInfo = F_A_proxy.logIn(this.tb_Email.Text, this.tb_password.Text);
                }catch(Exception)
                {
                   severLogInfo = 3;
                }
                if (severLogInfo == 1)
                {
                    this.lblInfo.Visible = true;
                    this.lblInfo.Text = "The username doesnt exist! please Register first!";
                }
                else if (severLogInfo == 2)
                {
                    this.lblInfo.Visible = true;
                    this.lblInfo.Text = "Wrong Passwork! Check it and try again";
                }
                else if (severLogInfo == 3)
                {
                    this.lblInfo.Visible = true;
                    this.lblInfo.Text = "Server problem! try again later";
                }
                else
                {
                    Profile profileForm = new Profile();
                    this.Hide();
                    profileForm.Show();

                }
            
            }

        }
    }
}
