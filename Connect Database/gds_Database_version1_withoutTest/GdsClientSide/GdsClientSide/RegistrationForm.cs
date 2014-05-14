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
    public partial class RegistrationForm : Form
    {
        private string userName;
        private string password;
        private string conPass;
        private string firstName;
        private string lastName;
        private string email;
        private string joinDate;
        private ServiceReferenceHUB.HubClient proxy;

        public RegistrationForm()
        {
            InitializeComponent();
            proxy = new ServiceReferenceHUB.HubClient();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.userName = txtUserName.Text;
            this.password = txtPassWord.Text;
            this.conPass = txtConPass.Text;
            this.firstName = txtFN.Text;
            this.lastName = txtLN.Text;
            this.email = txtEmail.Text;
            this.joinDate = Convert.ToString(System.DateTime.Now);
            if (proxy.checkIfExistedUserName(this.userName))
            {
                MessageBox.Show("Please choose another username.");
            }
            else
            {
                //MessageBox.Show("success");
                if (this.password == this.conPass)
                {
                    if(proxy.addNewUser(this.userName,this.password,this.firstName,this .lastName,this.email,this.joinDate))
                    {
                        PersonalForm newPersonal = new PersonalForm(this.userName);
                        this.Hide();
                        newPersonal.Show();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm newLogin = new LoginForm();
            this.Hide();
            newLogin.Show();
        }
    }
}
