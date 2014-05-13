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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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
            // passing the user name and password

        }
    }
}
