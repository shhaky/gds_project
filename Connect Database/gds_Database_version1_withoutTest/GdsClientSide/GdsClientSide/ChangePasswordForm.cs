using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GdsClientSide
{
    public partial class ChangePasswordForm : Form
    {
        private string oldPass;
        private string newPass;
        private string confirmPass;
        private string username;
        private ServiceReferenceHUB.HubClient proxy;

        public ChangePasswordForm(string userName)
        {
            InitializeComponent();
            proxy = new ServiceReferenceHUB.HubClient();
            this.username = userName;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.oldPass = txtOldPass.Text;
            this.newPass = txtNewPass.Text;
            this.confirmPass = txtConPass.Text;
            if (proxy.checkPassword(this.username, this.oldPass))
            {
                if (this.newPass == this.confirmPass)
                {
                    if (proxy.changePassword(this.username, this.newPass))
                    {
                        MessageBox.Show("success!!");
                        PersonalForm newPersonal = new PersonalForm(this.username);
                        this.Hide();
                        newPersonal.Show();
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
    }
}
