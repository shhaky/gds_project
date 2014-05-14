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
    public partial class LoginForm : Form
    {
        private string userName;
        private string password;

        private ServiceReferenceHUB.HubClient proxy;
        public LoginForm()
        {
            InitializeComponent();
            proxy = new ServiceReferenceHUB.HubClient();
        }
        //=====================show registration form=======================
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm newRe = new RegistrationForm();
            this.Hide();
            newRe.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.userName = txtUserName.Text;
            this.password = txtPassWord.Text;
            if (proxy.checkIfExistedUserName(this.userName))
            {
                if (proxy.checkPassword(this.userName, this.password))
                {
                    PersonalForm newPersonal = new PersonalForm(this.userName);
                    this.Hide();
                    newPersonal.Show();
                }
                else
                {
                    MessageBox.Show("please check your password.");
                }
            }
            else
            {
                MessageBox.Show("please check your username,or register a new account.");
            }
        }
    }
}
