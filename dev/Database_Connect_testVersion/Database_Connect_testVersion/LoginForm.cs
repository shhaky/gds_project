using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Connect_testVersion
{
    public partial class LoginForm : Form
    {
        private string userName;
        private string passWord;

        private DataHelper dataHelper;

        public LoginForm()
        {
            InitializeComponent();
            dataHelper = new DataHelper();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.userName = txtUserName.Text;
            this.passWord = txtPassWord.Text;
            if (dataHelper.checkIfExistedUserName(this.userName))
            {
                if (dataHelper.checkPassword(this.userName, this.passWord))
                {
                    AccountManagementForm newAccount = new AccountManagementForm(this.userName);
                    newAccount.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please check your password again.");
                }
            }
            else
            {
                MessageBox.Show("The user name is not existed, please check again.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm newRegis = new RegistrationForm();
            newRegis.Show();
            this.Hide();
        }
    }
}
