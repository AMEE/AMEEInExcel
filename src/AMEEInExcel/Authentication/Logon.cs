using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using AMEEInExcel.Authentication;
using AMEEInExcel.Core;


namespace AMEEInExcel.Authentication
{
    public partial class Logon : Form
    {

        public Boolean blnCreds = false;        // Indicate this to the calling function

        public Logon()
        {
            InitializeComponent();

            txtHostURL.Text = Credentials.Url;
            txtAMEEUsername.Text = Credentials.UserName;
            txtAMEEPassword.Text = Credentials.Password;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            blnCreds = true;

            if (txtAMEEUsername.Text == "")
            {
                MessageBox.Show("Missing Username.", "Authentication");
                blnCreds = false;
            }
            else if (txtAMEEPassword.Text == "")
            {
                MessageBox.Show("Missing Password.", "Authentication");
                blnCreds = false;
            }
            else if (txtHostURL.Text == "")
            {
                MessageBox.Show("Missing Host Url.", "Authentication");
                blnCreds = false;
            }
            else
            {
                blnCreds = true;
            }


            if (blnCreds)
            {
                // Log on - Authenticate
                Credentials.Url = txtHostURL.Text;
                Credentials.UserName = txtAMEEUsername.Text;
                Credentials.Password = txtAMEEPassword.Text;

                // parse the return code
                this.Close();
            }

        }


    }
}
