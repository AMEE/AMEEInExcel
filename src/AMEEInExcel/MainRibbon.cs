using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace AMEEInExcel
{
    public partial class MainRibbon
    {
        public static MainRibbon Instance;

        private static AMEEdiscoverForm discoverForm;

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            Instance = this;
            //versionLabel.Label = ThisAddIn.Instance.Version; 
        }

        private void findButton_Click(object sender, RibbonControlEventArgs e)
        {
            // want a single instance of the form 
            // if the user presses the button twice the existing one
            // is brought forward
            if (discoverForm == null)
            {
                discoverForm = new AMEEdiscoverForm();

                discoverForm.Show();
            }

            discoverForm.BringToFront();
        }

        private void findUIDButton_Click(object sender, RibbonControlEventArgs e)
        {
            var f = new UIDFinderForm();
            f.ShowDialog();
        }

        private void btnLogon_Click(object sender, RibbonControlEventArgs e)
        {
            var f = new AMEEInExcel.Authentication.Logon();
            f.ShowDialog();
        }
    }
}
