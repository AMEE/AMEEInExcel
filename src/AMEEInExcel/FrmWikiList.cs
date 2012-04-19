using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AMEEInExcel
{
    public partial class FrmWikiList : Form
    {
        static List<String> wikiNameList;

        public FrmWikiList()
        {
            InitializeComponent();
        }

        private void btnBuildWikiList_Click(object sender, EventArgs e)
        {

            try
            {
                populateWikiNames();

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Exception in BuildWikiList: "+ex.Message); 
            }
        }

        private void timerStatusUpdater_Tick(object sender, EventArgs e)
        {
            toolStripStatusUpdaterLabel.Text += ".";
        }

        private void cbEcoinvent_CheckedChanged(object sender, EventArgs e)
        {
            populateWikiList();
        }

        private void populateWikiList()
        {
            listBoxWikiNames.Items.Clear();

            foreach (String wikis in wikiNameList)
            {
                if ((cbEcoinvent.CheckState == CheckState.Unchecked) && (wikis.ToLower().Contains("ecoinvent") == true))
                {
                    continue;
                }

                listBoxWikiNames.Items.Add(wikis.ToString().Trim());
            }

        }

        private void populateWikiNames() 
        {
            toolStripStatusUpdaterLabel.Text = "Building Wiki List ";

            timerStatusUpdater.Enabled = true;

            wikiNameList = BuildWikiList.MapWikiListNames();
            populateWikiList();

            timerStatusUpdater.Enabled = false;
            toolStripStatusUpdaterLabel.Text = "";


        }



    }
}
