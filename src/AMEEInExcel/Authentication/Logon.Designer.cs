namespace AMEEInExcel.Authentication
{
    partial class Logon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logon));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAMEEUsername = new System.Windows.Forms.Label();
            this.txtAMEEUsername = new System.Windows.Forms.TextBox();
            this.gpBoxLogonDetails = new System.Windows.Forms.GroupBox();
            this.lblAMEEPassword = new System.Windows.Forms.Label();
            this.txtAMEEPassword = new System.Windows.Forms.TextBox();
            this.lblHostURL = new System.Windows.Forms.Label();
            this.txtHostURL = new System.Windows.Forms.TextBox();
            this.gpBoxLogonDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(186, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(105, 204);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblAMEEUsername
            // 
            this.lblAMEEUsername.AutoSize = true;
            this.lblAMEEUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAMEEUsername.Location = new System.Drawing.Point(6, 16);
            this.lblAMEEUsername.Name = "lblAMEEUsername";
            this.lblAMEEUsername.Size = new System.Drawing.Size(67, 13);
            this.lblAMEEUsername.TabIndex = 2;
            this.lblAMEEUsername.Text = "Username:";
            // 
            // txtAMEEUsername
            // 
            this.txtAMEEUsername.Location = new System.Drawing.Point(9, 36);
            this.txtAMEEUsername.Name = "txtAMEEUsername";
            this.txtAMEEUsername.Size = new System.Drawing.Size(231, 20);
            this.txtAMEEUsername.TabIndex = 3;
            // 
            // gpBoxLogonDetails
            // 
            this.gpBoxLogonDetails.Controls.Add(this.lblHostURL);
            this.gpBoxLogonDetails.Controls.Add(this.txtHostURL);
            this.gpBoxLogonDetails.Controls.Add(this.lblAMEEPassword);
            this.gpBoxLogonDetails.Controls.Add(this.txtAMEEPassword);
            this.gpBoxLogonDetails.Controls.Add(this.lblAMEEUsername);
            this.gpBoxLogonDetails.Controls.Add(this.txtAMEEUsername);
            this.gpBoxLogonDetails.Location = new System.Drawing.Point(15, 13);
            this.gpBoxLogonDetails.Name = "gpBoxLogonDetails";
            this.gpBoxLogonDetails.Size = new System.Drawing.Size(246, 180);
            this.gpBoxLogonDetails.TabIndex = 4;
            this.gpBoxLogonDetails.TabStop = false;
            // 
            // lblAMEEPassword
            // 
            this.lblAMEEPassword.AutoSize = true;
            this.lblAMEEPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAMEEPassword.Location = new System.Drawing.Point(6, 68);
            this.lblAMEEPassword.Name = "lblAMEEPassword";
            this.lblAMEEPassword.Size = new System.Drawing.Size(65, 13);
            this.lblAMEEPassword.TabIndex = 4;
            this.lblAMEEPassword.Text = "Password:";
            // 
            // txtAMEEPassword
            // 
            this.txtAMEEPassword.Location = new System.Drawing.Point(9, 88);
            this.txtAMEEPassword.Name = "txtAMEEPassword";
            this.txtAMEEPassword.Size = new System.Drawing.Size(231, 20);
            this.txtAMEEPassword.TabIndex = 5;
            this.txtAMEEPassword.UseSystemPasswordChar = true;
            // 
            // lblHostURL
            // 
            this.lblHostURL.AutoSize = true;
            this.lblHostURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostURL.Location = new System.Drawing.Point(6, 123);
            this.lblHostURL.Name = "lblHostURL";
            this.lblHostURL.Size = new System.Drawing.Size(66, 13);
            this.lblHostURL.TabIndex = 6;
            this.lblHostURL.Text = "Host URL:";
            // 
            // txtHostURL
            // 
            this.txtHostURL.Location = new System.Drawing.Point(9, 143);
            this.txtHostURL.Name = "txtHostURL";
            this.txtHostURL.Size = new System.Drawing.Size(231, 20);
            this.txtHostURL.TabIndex = 7;
            // 
            // Logon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 242);
            this.Controls.Add(this.gpBoxLogonDetails);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Logon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.gpBoxLogonDetails.ResumeLayout(false);
            this.gpBoxLogonDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAMEEUsername;
        private System.Windows.Forms.TextBox txtAMEEUsername;
        private System.Windows.Forms.GroupBox gpBoxLogonDetails;
        private System.Windows.Forms.Label lblAMEEPassword;
        private System.Windows.Forms.TextBox txtAMEEPassword;
        private System.Windows.Forms.Label lblHostURL;
        private System.Windows.Forms.TextBox txtHostURL;
    }
}