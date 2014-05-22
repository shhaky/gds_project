using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoin
{
    public partial class Register : Form
    {
        private string userName;
        private string password;
        private string conPass;
        private string firstName;
        private string lastName;
        private string email;
        private string joinDate;
        private string lastLoginTime;

        private ServiceReferenceHub.HubClient proxy;
        public Register()
        {
            InitializeComponent();
            proxy = new ServiceReferenceHub.HubClient();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.userName = txtUserName.Text;
            this.password = txtPassword.Text;
            this.conPass = txtConfirmPass.Text;
            this.firstName = txtFirstName.Text;
            this.lastName = txtLastName.Text;
            this.email = txtEmail.Text;
            this.joinDate = Convert.ToString(System.DateTime.Now);
            this.lastLoginTime = Convert.ToString(System.DateTime.Now);
            if (proxy.checkIsExistedUserName(this.userName))
            {
                MessageBox.Show("Please choose another username.");
            }
            else
            {
                if (this.password == this.conPass)
                {
                    if (proxy.addNewUser(this.userName, this.password, this.firstName, this.lastName, this.email, this.joinDate,this.lastLoginTime))
                    {
                        Main newMain = new Main();
                        this.Hide();
                        newMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("failed!");
                    }
                }
                else
                {
                    MessageBox.Show("please check your password again.");
                }
            }
        }
    }
}
