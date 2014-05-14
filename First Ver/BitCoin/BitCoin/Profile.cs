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
        public FatToAccM.FatC_to_AccMClient F_A_proxy; // Fat client to Account Management Proxy
        InstanceContext context;

        public Profile()
        {
            InitializeComponent();

            Acc_Mgnt_CallbackService callback1 = new Acc_Mgnt_CallbackService();
            context = new InstanceContext(callback1);
            F_A_proxy = new FatToAccM.FatC_to_AccMClient(context);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form home = new Main();
            home.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (F_A_proxy.logOut())
                {
                    Main mainForm = new Main();
                    this.Dispose();
                    mainForm.Show();
                }
            }catch(Exception)
            {
                this.lbllogOutInfo.Visible = true;
                this.lbllogOutInfo.Text = "Try again! Server Problem!";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
