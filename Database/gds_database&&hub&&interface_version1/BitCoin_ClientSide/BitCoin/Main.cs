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
        private string userName;
        private string password;

        private ServiceReferenceHUB.HubClient proxy;
        public Main()
        {
            InitializeComponent();
            proxy = new ServiceReferenceHUB.HubClient();
        }

        private void linkBtnRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)//done
        {
            Form reg = new RegistrationForm();
            reg.Show();
            this.Hide();
        }

        private void linkBtnLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.userName = txtUserName.Text;
            this.password = txtPassWord.Text;
            if (proxy.checkIfExistedUserName(this.userName))
            {
                if (proxy.checkPassword(this.userName, this.password))
                {
                    Profile newProfile = new Profile(this.userName);
                    this.Hide();
                    newProfile.Show();
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
        
        ////public FatToAccM.FatC_to_AccMClient F_A_proxy; // Fat client to Account Management Proxy
        ////InstanceContext context;

        //public Main()
        //{
        //    InitializeComponent();

        //    //Acc_Mgnt_CallbackService callback1 = new Acc_Mgnt_CallbackService();
        //    //context = new InstanceContext(callback1);
        //    //F_A_proxy = new FatToAccM.FatC_to_AccMClient(context);
        //}

        //private void tb_Email_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void tb_Email_Enter(object sender, EventArgs e)
        //{
        //    if (txtUserName.Text == "E-mail")
        //    {
        //        txtUserName.Text = string.Empty;
        //        txtUserName.ForeColor = Color.Black;
        //    }
        //}

        //private void tb_Email_Leave(object sender, EventArgs e)
        //{
        //    if (txtUserName.Text == string.Empty )
        //    {
        //        txtUserName.Text = "E-mail";
        //        txtUserName.ForeColor = Color.LightGray;
        //    }
        //}

        //private void tb_password_Enter(object sender, EventArgs e)
        //{
        //    if (txtPassWord.Text == "Password")
        //    {
        //        txtPassWord.Text = string.Empty;
        //        txtPassWord.ForeColor = Color.Black;
        //        txtPassWord.PasswordChar = '*';
        //    }
        //}

        //private void tb_password_Leave(object sender, EventArgs e)
        //{
        //    if (txtPassWord.Text == string.Empty)
        //    {
        //        txtPassWord.Text = "Password";
        //        txtPassWord.ForeColor = Color.LightGray;
        //        txtPassWord.PasswordChar = '\0' ;
        //    }
        //}

        //private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Form profile = new Profile();
        //    profile.Show();
        //}

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    int severLogInfo;

        //    if ((this.txtUserName.Text == "") || (this.txtPassWord.Text == ""))
        //    {
        //        this.lblInfo.Visible = true;
        //        this.lblInfo.Text = "Please Fill all the Field first!";
        //    }
        //    else
        //    {
        //        try
        //        {
        //            severLogInfo = F_A_proxy.logIn(this.txtUserName.Text, this.txtPassWord.Text);
        //        }catch(Exception)
        //        {
        //           severLogInfo = 3;
        //        }
        //        if (severLogInfo == 1)
        //        {
        //            this.lblInfo.Visible = true;
        //            this.lblInfo.Text = "The username doesnt exist! please Register first!";
        //        }
        //        else if (severLogInfo == 2)
        //        {
        //            this.lblInfo.Visible = true;
        //            this.lblInfo.Text = "Wrong Passwork! Check it and try again";
        //        }
        //        else if (severLogInfo == 3)
        //        {
        //            this.lblInfo.Visible = true;
        //            this.lblInfo.Text = "Server problem! try again later";
        //        }
        //        else
        //        {
        //            Profile profileForm = new Profile();
        //            this.Hide();
        //            profileForm.Show();

        //        }
            
        //    }

        }
    }

