using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

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
