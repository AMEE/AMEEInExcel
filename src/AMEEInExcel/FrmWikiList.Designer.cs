namespace AMEEInExcel
{
    partial class FrmWikiList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBuildWikiList = new System.Windows.Forms.Button();
            this.listBoxWikiNames = new System.Windows.Forms.ListBox();
            this.timerStatusUpdater = new System.Windows.Forms.Timer(this.components);
            this.statusStripStatusUpdate = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusUpdaterLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbEcoinvent = new System.Windows.Forms.CheckBox();
            this.statusStripStatusUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuildWikiList
            // 
            this.btnBuildWikiList.Location = new System.Drawing.Point(12, 12);
            this.btnBuildWikiList.Name = "btnBuildWikiList";
            this.btnBuildWikiList.Size = new System.Drawing.Size(75, 23);
            this.btnBuildWikiList.TabIndex = 0;
            this.btnBuildWikiList.Text = "Get Names";
            this.btnBuildWikiList.UseVisualStyleBackColor = true;
            this.btnBuildWikiList.Click += new System.EventHandler(this.btnBuildWikiList_Click);
            // 
            // listBoxWikiNames
            // 
            this.listBoxWikiNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxWikiNames.FormattingEnabled = true;
            this.listBoxWikiNames.HorizontalScrollbar = true;
            this.listBoxWikiNames.Items.AddRange(new object[] {
            "Click to fetch the Wikinames from the AMEE platform."});
            this.listBoxWikiNames.Location = new System.Drawing.Point(12, 41);
            this.listBoxWikiNames.Name = "listBoxWikiNames";
            this.listBoxWikiNames.Size = new System.Drawing.Size(340, 199);
            this.listBoxWikiNames.TabIndex = 1;
            // 
            // timerStatusUpdater
            // 
            this.timerStatusUpdater.Interval = 1000;
            this.timerStatusUpdater.Tick += new System.EventHandler(this.timerStatusUpdater_Tick);
            // 
            // statusStripStatusUpdate
            // 
            this.statusStripStatusUpdate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusUpdaterLabel});
            this.statusStripStatusUpdate.Location = new System.Drawing.Point(0, 252);
            this.statusStripStatusUpdate.Name = "statusStripStatusUpdate";
            this.statusStripStatusUpdate.Size = new System.Drawing.Size(364, 22);
            this.statusStripStatusUpdate.TabIndex = 2;
            this.statusStripStatusUpdate.Text = "statusStrip1";
            // 
            // toolStripStatusUpdaterLabel
            // 
            this.toolStripStatusUpdaterLabel.Name = "toolStripStatusUpdaterLabel";
            this.toolStripStatusUpdaterLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // cbEcoinvent
            // 
            this.cbEcoinvent.AutoSize = true;
            this.cbEcoinvent.Location = new System.Drawing.Point(278, 16);
            this.cbEcoinvent.Name = "cbEcoinvent";
            this.cbEcoinvent.Size = new System.Drawing.Size(74, 17);
            this.cbEcoinvent.TabIndex = 3;
            this.cbEcoinvent.Text = "Ecoinvent";
            this.cbEcoinvent.UseVisualStyleBackColor = true;
            this.cbEcoinvent.CheckedChanged += new System.EventHandler(this.cbEcoinvent_CheckedChanged);
            // 
            // FrmWikiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 274);
            this.Controls.Add(this.cbEcoinvent);
            this.Controls.Add(this.statusStripStatusUpdate);
            this.Controls.Add(this.listBoxWikiNames);
            this.Controls.Add(this.btnBuildWikiList);
            this.DoubleBuffered = true;
            this.Name = "FrmWikiList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Global Wiki List";
            this.statusStripStatusUpdate.ResumeLayout(false);
            this.statusStripStatusUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuildWikiList;
        private System.Windows.Forms.ListBox listBoxWikiNames;
        private System.Windows.Forms.Timer timerStatusUpdater;
        private System.Windows.Forms.StatusStrip statusStripStatusUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUpdaterLabel;
        private System.Windows.Forms.CheckBox cbEcoinvent;
    }
}