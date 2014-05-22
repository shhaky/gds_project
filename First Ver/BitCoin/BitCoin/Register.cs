﻿using System;
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
    public partial class Register : Form
    {
        public FatToAccM.FatC_to_AccMClient F_A_proxy; // Fat client to Account Management Proxy
        InstanceContext context;

        public Register()
        {
            InitializeComponent();
            Acc_Mgnt_CallbackService callback1 = new Acc_Mgnt_CallbackService();
            context = new InstanceContext(callback1);
            F_A_proxy = new FatToAccM.FatC_to_AccMClient(context);
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void bt_Register_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "" ||txtFirstName.Text != "" ||txtLastName.Text!= ""
                ||txtEmail.Text!= "" ||txtPassword.Text!= "" || txtPasswordConf.Text !="")
            {
                if(txtPassword.Text == txtPasswordConf.Text)
                {
                    try
                    {
                        F_A_proxy.register(txtUsername.Text, txtPassword.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, Convert.ToString(System.DateTime.Now) );
                    }catch(Exception)
                    {
                
                    }
                }else
                {
                }

             }
        }
    }
}
