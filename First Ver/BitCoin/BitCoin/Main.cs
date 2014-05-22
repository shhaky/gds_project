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
using System.Windows.Forms.DataVisualization.Charting;


namespace BitCoin
{
    public partial class Main : Form
    {
        private int TimeSplit = 5;
        public FatToAccM.FatC_to_AccMClient F_A_proxy; // Fat client to Account Management Proxy
        InstanceContext context;

        public Main()
        {
            InitializeComponent();

            Acc_Mgnt_CallbackService callback1 = new Acc_Mgnt_CallbackService();
            context = new InstanceContext(callback1);
            F_A_proxy = new FatToAccM.FatC_to_AccMClient(context);
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
            int severLogInfo;

            if ((this.tb_Email.Text == "") || (this.tb_password.Text == ""))
            {
                this.lblInfo.Visible = true;
                this.lblInfo.Text = "Please Fill all the Field first!";
            }
            else
            {
                try
                {
                    severLogInfo = F_A_proxy.logIn(this.tb_Email.Text, this.tb_password.Text);
                }catch(Exception)
                {
                   severLogInfo = 3;
                }
                if (severLogInfo == 1)
                {
                    this.lblInfo.Visible = true;
                    this.lblInfo.Text = "The username doesnt exist! please Register first!";
                }
                else if (severLogInfo == 2)
                {
                    this.lblInfo.Visible = true;
                    this.lblInfo.Text = "Wrong Password! Check it and try again";
                }
                else if (severLogInfo == 3)
                {
                    this.lblInfo.Visible = true;
                    this.lblInfo.Text = "Server problem! try again later";
                }
                else
                {
                    Profile profileForm = new Profile();
                    this.Hide();
                    profileForm.Show();

                }
            
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
       // fake the DB data with a simple list
        List<dbdata> k = new List<dbdata> { 
            new dbdata("1/1/2014", 10f, 8f, 9f, 9.5f),
            new dbdata("2/1/2014", 15F, 10F, 12F, 13F),
            new dbdata("3/1/2014", 5F, 10F, 8F, 6F),
            new dbdata("4/1/2014", 25F, 10F, 18F, 16F)
        };

        // remove all previous series
        chart1.Series.Clear();

        Series price = new Series("price"); // <<== make sure to name the series "price"
        chart1.Series.Add(price);

        // Set series chart type
        chart1.Series["price"].ChartType = SeriesChartType.Candlestick;

        // Set the style of the open-close marks
        chart1.Series["price"]["OpenCloseStyle"] = "Triangle";

        // Show both open and close marks
        chart1.Series["price"]["ShowOpenClose"] = "Both";

        // Set point width
        chart1.Series["price"]["PointWidth"] = "0.5";

        // Set colors bars
        chart1.Series["price"]["PriceUpColor"] = "Green"; // <<== use text indexer for series
        chart1.Series["price"]["PriceDownColor"] = "Red"; // <<== use text indexer for series

        for (int i = 0; i < k.Count; i++)
        {
            // adding date and high
            chart1.Series["price"].Points.AddXY(DateTime.Parse(k[i].date), k[i].up);
            // adding low
            chart1.Series["price"].Points[i].YValues[1] = k[i].down;
            //adding open
            chart1.Series["price"].Points[i].YValues[2] = k[i].PriceOpen;
            // adding close
            chart1.Series["price"].Points[i].YValues[3] = k[i].PriceClose;
        }




        }


        class dbdata
        {
            public string date;
            public float up;
            public float down;
            public float PriceOpen;
            public float PriceClose;
            public dbdata(string d, float h, float l, float o, float c) { date = d; up = h; down = l; PriceOpen = o; PriceClose = c; }
        }


        private void setTime()
        {

            if (radioButton1.Checked)
            {
                TimeSplit = 5;
            }
            else if (radioButton2.Checked)
            {
                TimeSplit = 15;
            }
            else if (radioButton3.Checked)
            {
                TimeSplit = 30;
            }
            else if (radioButton4.Checked)
            {
                TimeSplit = 60;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setTime();
            Main_Load(sender, e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setTime();
            Main_Load(sender, e);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            setTime();
            Main_Load(sender, e);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            setTime();
            Main_Load(sender, e);
        }

        private void Btn_Buy_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Sell_Click(object sender, EventArgs e)
        {

        }

        private void bt_SendMessage_Click(object sender, EventArgs e)
        {

        }

    }
}
