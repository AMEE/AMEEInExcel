﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace [!output SAFE_NAMESPACE_NAME]
{
    public partial class [!output SAFE_CLASS_NAME]
    {
        private void [!output SAFE_CLASS_NAME]_Startup(object sender, System.EventArgs e)
        {
        }

        private void [!output SAFE_CLASS_NAME]_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
	    private void InternalStartup()
        {
            this.Startup += new System.EventHandler([!output SAFE_CLASS_NAME]_Startup);
            this.Shutdown += new System.EventHandler([!output SAFE_CLASS_NAME]_Shutdown);
        }
        
        #endregion

    }
}
