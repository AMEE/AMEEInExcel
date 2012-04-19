namespace AMEEInExcel
{
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainRibbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.versionLabel = this.Factory.CreateRibbonLabel();
            this.button1 = this.Factory.CreateRibbonButton();
            this.findButton = this.Factory.CreateRibbonButton();
            this.btnLogon = this.Factory.CreateRibbonButton();
            this.findUIDButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group4);
            this.tab1.KeyTip = "AM";
            this.tab1.Label = "AMEE";
            this.tab1.Name = "tab1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.button1);
            this.group2.Name = "group2";
            // 
            // group1
            // 
            this.group1.Items.Add(this.findButton);
            this.group1.Items.Add(this.btnLogon);
            this.group1.Label = "AMEEdiscover";
            this.group1.Name = "group1";
            // 
            // group3
            // 
            this.group3.Items.Add(this.findUIDButton);
            this.group3.Label = "AMEE Connect";
            this.group3.Name = "group3";
            this.group3.Visible = false;
            // 
            // group4
            // 
            this.group4.Items.Add(this.versionLabel);
            this.group4.Name = "group4";
            // 
            // versionLabel
            // 
            this.versionLabel.Label = "v0.8.0.0";
            this.versionLabel.Name = "versionLabel";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "AMEE";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            // 
            // findButton
            // 
            this.findButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
            this.findButton.Label = "Find Data Sets";
            this.findButton.Name = "findButton";
            this.findButton.ShowImage = true;
            this.findButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.findButton_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnLogon.Enabled = false;
            this.btnLogon.Image = ((System.Drawing.Image)(resources.GetObject("btnLogon.Image")));
            this.btnLogon.Label = "Logon to Amee";
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.ShowImage = true;
            this.btnLogon.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLogon_Click);
            // 
            // findUIDButton
            // 
            this.findUIDButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.findUIDButton.Image = ((System.Drawing.Image)(resources.GetObject("findUIDButton.Image")));
            this.findUIDButton.Label = "Find UIDs";
            this.findUIDButton.Name = "findUIDButton";
            this.findUIDButton.ShowImage = true;
            this.findUIDButton.Visible = false;
            this.findUIDButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.findUIDButton_Click);
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MainRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton findButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton findUIDButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLogon;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel versionLabel;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
