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
    public partial class PersonalForm : Form
    {
        private string username;
        private ServiceReferenceHUB.HubClient proxy;

        private string transType;
        private string coinType;
        private decimal amount;
        private string add;
        private long transId;
        private string transTime;
        private List<string> transInfo;
        private long userId;

        public PersonalForm(string userName)
        {
            InitializeComponent();
            proxy = new ServiceReferenceHUB.HubClient();
            this.username = userName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePasswordForm newChangePass = new ChangePasswordForm(username);
            this.Hide();
            newChangePass.Show();
        }

        private void PersonalForm_Load(object sender, EventArgs e)
        {
            this.labUserId.Text = Convert.ToString(proxy.getUserId(this.username));
            this.userId = proxy.getUserId(this.username);
            this.labUserName.Text = this.username;
            this.labFN.Text = proxy.getFirstName(this.username);
            this.labLN.Text = proxy.getLastName(this.username);
            this.labEmail.Text = proxy.getEmail(this.username);
            this.labJoinDate.Text = proxy.getJoinDate(this.username);
            listBox.Items.Clear();
            foreach (string a in proxy.getTransInfo(this.userId))
            {
                this.listBox.Items.Add(a);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (string a in proxy.getTransInfo(this.userId))
            {
                this.listBox.Items.Add(a);
            }
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            if (this.radioButtonSell.Checked == true)
            {
                this.transType = "sold";
            }
            else if (this.radioButtonBuy.Checked == true)
            {
                this.transType = "bought";
            }
            else
            {
                MessageBox.Show("Please choose a trans type");
            }

            if (this.radioButtonBitcoin.Checked == true)
            {
                this.coinType = "Bitcoin";
            }
            else if (this.radioButtonLitecoin.Checked == true)
            {
                this.coinType = "Litecoin";
            }
            else
            {
                MessageBox.Show("Please choose a coin type");
            }
            this.amount = Convert.ToDecimal(this.txtAmount.Text);
            this.add = this.txtAdd.Text;
            this.transTime = Convert.ToString(System.DateTime.Now);

            if (proxy.addNewTransaction(this.userId, this.transTime, this.transType, this.coinType, this.amount, this.add))
            {
                MessageBox.Show("success!!");
            }
            else
            {
                MessageBox.Show("failed.");
            }
            listBox.Items.Clear();
            foreach (string a in proxy.getTransInfo(this.userId))
            {
                this.listBox.Items.Add(a);
            }

        }
    }
}
