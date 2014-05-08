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
    public partial class AccountManagementForm : Form
    {
        private DataHelper dataHelper;
        
        private long userId;
        private string userName;
        //private string passWord;
        private string firstName;
        private string lastName;
        private string email;
        private string joinDate;

        private string transType;
        private string coinType;
        private decimal amount;
        private string ToAdd;
        private long transId;
        private string transTime;

        public AccountManagementForm(string userName)
        {
            InitializeComponent();
            dataHelper = new DataHelper();
            this.userName = userName;
        }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            this.userId = Convert.ToInt64(dataHelper.getUserId(this.userName));
            this.labUserId.Text = Convert.ToString(this.userId);

            this.labUserName.Text = this.userName;

            this.firstName = dataHelper.getFirstName(this.userName);
            this.labFN.Text = this.firstName;

            this.lastName = dataHelper.getLastName(this.userName);
            this.labLN.Text = this.lastName;

            this.email = dataHelper.getEmail(this.userName);
            this.labEmail.Text = this.email;

            this.joinDate = dataHelper.getJoinDate(this.userName);
            this.labJoinDate.Text = this.joinDate;

            
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            if (this.checkBoxSell.Checked == true)
            {
                this.transType = "Sell";
            }
            else if (this.checkBoxBuy.Checked == true)
            {
                this.transType = "Buy";
            }
            else
            {
                MessageBox.Show("Please choose a trans type");
            }

            if (this.checkBoxBitcoin.Checked == true)
            {
                this.coinType = "Bitcoin";
            }
            else if (this.checkBoxLitecoin.Checked == true)
            {
                this.coinType = "Litecoin";
            }
            else
            {
                MessageBox.Show("Please choose a coin type");
            }
            this.amount = Convert.ToDecimal(this.txtAmount.Text);
            this.ToAdd = this.txtToAdd.Text;
            this.transId = dataHelper.getLastestExistedTransId() + 1;
            this.transTime = Convert.ToString(System.DateTime.Now);
            if (dataHelper.addNewTransaction(this.transId, this.userId, this.transTime, this.transType, this.coinType, this.amount, this.ToAdd))
            {
                MessageBox.Show("success!!");
            }
            else
            {
                MessageBox.Show("something wrong.");
            }

        }
    }
}
