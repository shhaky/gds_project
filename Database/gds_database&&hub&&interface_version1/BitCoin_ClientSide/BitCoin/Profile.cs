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
    public partial class Profile : Form
    {       
        private ServiceReferenceHUB.HubClient proxy;
        private string username;
        private long userId;

        private string oldPass;
        private string newPass;
        private string confirmPass;
        private string lastLoginTime;

        public Profile(string userName)
        {
            InitializeComponent();
            proxy = new ServiceReferenceHUB.HubClient();
            this.username = userName;
            this.userId = proxy.getUserId(this.username);
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            this.txtShowUserName.Text = this.username;
            this.txtShowEmail.Text = proxy.getEmail(this.username);
            this.txtBTC.Text = Convert.ToString(proxy.getBalance(this.userId, "BTC"));
            this.txtLTC.Text = Convert.ToString(proxy.getBalance(this.userId, "LTC"));
            this.txtPPC.Text = Convert.ToString(proxy.getBalance(this.userId, "PPC"));
            this.txtXPM.Text = Convert.ToString(proxy.getBalance(this.userId, "XPM"));
            this.txtDOGE.Text = Convert.ToString(proxy.getBalance(this.userId, "DOGE"));
            //this.labLastLoginTime.Text = proxy.getLastLoginTime(this.username);
            //proxy.updateLoginTime(this.username, Convert.ToString(System.DateTime.Now));

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.oldPass = txtOldPass.Text;
            this.newPass = txtNewPass.Text;
            this.confirmPass = txtConNewPass.Text;
            if (proxy.checkPassword(this.username, this.oldPass))
            {
                if (this.newPass == this.confirmPass)
                {
                    if (proxy.changePassword(this.username, this.newPass))
                    {
                        MessageBox.Show("success!!");
                        this.txtOldPass.Clear();
                        this.txtNewPass.Clear();
                        this.txtConNewPass.Clear();
                    }
                    else
                    {
                        MessageBox.Show("failed.");
                    }
                }
                else
                {
                    MessageBox.Show("please check your confirm password");
                }
            }
            else
            {
                MessageBox.Show("please check your password, it is not correct.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtOldPass.Clear();
            this.txtNewPass.Clear();
            this.txtConNewPass.Clear();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form home = new Main();
            home.Show();
        }

        private void btnDepositGenerate_Click(object sender, EventArgs e)
        {

        }

        private void btnDepositClear_Click(object sender, EventArgs e)
        {

        }

        private void btnWithdrawGenerate_Click(object sender, EventArgs e)
        {

        }

        private void btnWithdrawClear_Click(object sender, EventArgs e)
        {

        }

        

            //try
            //{
            //    if (F_A_proxy.logOut())
            //    {
            //        Main mainForm = new Main();
            //        this.Dispose();
            //        mainForm.Show();
            //    }
            //}catch(Exception)
            //{
            //    this.lbllogOutInfo.Visible = true;
            //    this.lbllogOutInfo.Text = "Try again! Server Problem!";
            //}
            
    }
}
