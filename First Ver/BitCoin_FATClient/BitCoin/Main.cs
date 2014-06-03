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
        private string userName;
        private string password;

        private ServiceReferenceHUB.HubClient proxy;

        Random r = new Random(123457);
        private Chart currentChart;
        string chartname = null;
        private double[] high, low, open, close;
        List<dbdata> list = new List<dbdata>();
        public Main()
        {
            InitializeComponent();
            
            proxy = new ServiceReferenceHUB.HubClient();
        }

        public Main(string userName)
        {
            InitializeComponent();
            proxy = new ServiceReferenceHUB.HubClient();
            txtPassWord.Visible = false;
            txtUserName.Visible = false;
            linkBtnRegister.Visible = false;
            lblInfo.Visible = true;
            lblInfo.Text = "Welcome " + userName;
            linkBtnLogin.Text = "Logout";
        }

        class dbdata
        {
            public string date;
            public double up;
            public double down;
            public double PriceOpen;
            public double PriceClose;
        }

        private void linkBtnRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)//done
        {
            Form reg = new RegistrationForm();
            reg.Show();
            this.Hide();
        }

        private void linkBtnLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkBtnLogin.Text == "Login")
            {
                this.userName = txtUserName.Text;
                this.password = txtPassWord.Text;
                if (proxy.checkIfExistedUserName(this.userName))
                {
                    if (proxy.checkPassword(this.userName, this.password))
                    {
                        txtPassWord.Visible = false;
                        txtUserName.Visible = false;
                        txtPassWord.Text = null;
                        txtUserName.Text = null;
                        linkBtnRegister.Visible = false;
                        lblInfo.Visible = true;
                        lblInfo.Text = "Welcome " + userName;
                        linkBtnLogin.Text = "Logout";
                        //Profile newProfile = new Profile(this.userName);
                        //this.Hide();
                        //newProfile.Show();
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
            else
            {
                txtPassWord.Visible = true;
                txtUserName.Visible = true;
                linkBtnRegister.Visible = true;
                lblInfo.Visible = false;
                linkBtnLogin.Text = "Login";

            }
        }

        private void chartUpdate(int n)
        {
            
        CreateData(n);
            // remove all previous series
            currentChart.Series.Clear();

            Series price = new Series(chartname); 
            currentChart.Series.Add(price);

            // Set series chart type
            currentChart.Series[chartname].ChartType = SeriesChartType.Candlestick;

            // Set the style of the open-close marks
            currentChart.Series[chartname]["OpenCloseStyle"] = "Triangle";

            // Show both open and close marks
            currentChart.Series[chartname]["ShowOpenClose"] = "Both";

            // Set point width
            currentChart.Series[chartname]["PointWidth"] = "0.5";

            // Set colors bars
            currentChart.Series[chartname]["PriceUpColor"] = "Green"; // <<== use text indexer for series
            currentChart.Series[chartname]["PriceDownColor"] = "Red"; // <<== use text indexer for series

            for (int i = 0; i < list.Count; i++)
            {
                // adding date and high
                currentChart.Series[chartname].Points.AddXY(list[i].date, list[i].up);
                // adding low
                currentChart.Series[chartname].Points[i].YValues[1] = list[i].down;
                //adding open
                currentChart.Series[chartname].Points[i].YValues[2] = list[i].PriceOpen;
                // adding close
                currentChart.Series[chartname].Points[i].YValues[3] = list[i].PriceClose;
            }


        }

        

        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            chartname = "LTC";
            currentChart = chart1;
            chartUpdate(30);
            textBox2.Text = Math.Round(list[29].up, 2).ToString();
            textBox5.Text = Math.Round(list[29].down, 2).ToString();
        }
        private void CreateData(int n)
        {
            if (n == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    list.RemoveAt(i);
                }

            }
           //    list.Clear();
            high = new double[n];
            low = new double[n];
            close = new double[n];
            open = new double[n];
            
            for (int k = 0; k < n; k++)
            {
                dbdata temp = new dbdata();
                double f = r.NextDouble();
                 if (k == 0)
                {
                    close[0] = (0.95 + 0.20 * f);
                }
                else
                {
                    close[k] = (0.95 + 0.20 * f) * close[k - 1];
                }
                high[k] = close[k] * (1 + 0.5 * r.NextDouble());
                low[k] = close[k] * (1 - 0.5 * r.NextDouble());
                open[k] = low[k] + r.NextDouble() * (high[k] - low[k]);

                temp.PriceClose = close[k];
                temp.down = low[k];
                temp.PriceOpen = open[k];
                temp.up = high[k];
                temp.date = System.DateTime.Now.AddMinutes(k*3).ToString("HH:mm:ss");
                list.Add(temp);

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chartUpdate(5);
        }


        private void tabPage3_Enter(object sender, EventArgs e)
        {
            chartname = "PPC";
            currentChart = chart3;
            chartUpdate(5);
            textBox17.Text = Math.Round(list[29].up, 2).ToString();
            textBox14.Text = Math.Round(list[29].down, 2).ToString();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            chartname = "DOGE";
            currentChart = chart2;
            chartUpdate(5);
            textBox11.Text = Math.Round(list[29].up, 2).ToString();
            textBox8.Text = Math.Round(list[29].down, 2).ToString();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            chartname = "LTC";
            currentChart = chart1;
            chartUpdate(5);
            textBox2.Text = Math.Round(list[29].up, 2).ToString();
            textBox5.Text = Math.Round(list[29].down, 2).ToString();
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            chartname = "XPM";
            currentChart = chart4;
            chartUpdate(5);
            textBox23.Text = Math.Round(list[29].up, 2).ToString();
            textBox20.Text = Math.Round(list[29].down, 2).ToString();
        }

        private void Main_Leave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
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

        private void tb_Email_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "E-mail")
            {
                txtUserName.Text = string.Empty;
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void tb_Email_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                txtUserName.Text = "E-mail";
                txtUserName.ForeColor = Color.LightGray;
            }
        }

        private void tb_password_Enter(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "Password")
            {
                txtPassWord.Text = string.Empty;
                txtPassWord.ForeColor = Color.Black;
                txtPassWord.PasswordChar = '*';
            }
        }

        private void tb_password_Leave(object sender, EventArgs e)
        {
            if (txtPassWord.Text == string.Empty)
            {
                txtPassWord.Text = "Password";
                txtPassWord.ForeColor = Color.LightGray;
                txtPassWord.PasswordChar = '\0';
            }
        }

        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form profile = new Profile(userName);
            profile.Show();
        }

        private void Btn_Buy_cal_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text =
              (Convert.ToDouble(textBox1.Text) *
              Convert.ToDouble(textBox2.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void Btn_Sel_Cal_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text =
              (Convert.ToDouble(textBox6.Text) *
              Convert.ToDouble(textBox5.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text =
              (Convert.ToDouble(textBox11.Text) *
              Convert.ToDouble(textBox12.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text =
              (Convert.ToDouble(textBox8.Text) *
              Convert.ToDouble(textBox9.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text =
              (Convert.ToDouble(textBox17.Text) *
              Convert.ToDouble(textBox18.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox13.Text =
              (Convert.ToDouble(textBox14.Text) *
              Convert.ToDouble(textBox15.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                textBox22.Text =
              (Convert.ToDouble(textBox23.Text) *
              Convert.ToDouble(textBox24.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                textBox19.Text =
              (Convert.ToDouble(textBox20.Text) *
              Convert.ToDouble(textBox21.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert value");
            }
        }

        private void tradeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(userName);
            this.Hide();
            profileForm.Show();

        }

      

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

