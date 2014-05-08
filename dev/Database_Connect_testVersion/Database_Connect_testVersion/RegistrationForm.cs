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
    public partial class RegistrationForm : Form
    {
        private long userId;
        private string userName;
        private string passWord;
        private string firstName;
        private string lastName;
        private string email;
        private string joinDate;

        private DataHelper dataHelper;
        

        public RegistrationForm()
        {
            InitializeComponent();
            dataHelper = new DataHelper();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.userName = txtUserName.Text;
            this.passWord = txtPassWord.Text;
            this.firstName = txtFN.Text;
            this.lastName = txtLN.Text;
            this.email = txtEmail.Text;
            this.joinDate = Convert.ToString(System.DateTime.Now);

            if (dataHelper.checkIfExistedUserName(this.userName))
            {
                MessageBox.Show("This name is existed, please choose another name.");
            }
            else
            {
                userId = dataHelper.getLastestExistedUserId() + 1;
                if (dataHelper.addNewUser(this.userId, this.userName, this.passWord, this.firstName, this.lastName, this.email, this.joinDate))
                {
                    AccountManagementForm newAccForm = new AccountManagementForm(this.userName);
                    newAccForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("failed!!!!!!");
                }
            }

 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm newLogin = new LoginForm();
            newLogin.Show();
            this.Hide();
        }
    }
}
