using System;
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
        // This comment was generated when the solution was upgraded.
        //
        // For tools support, it is recommended that you copy the
        // existing code in the OfficeCodeBehind class to the
        // corresponding methods below. Once all code has been moved,
        // [!output OLD_CODE_BEHIND] can be removed from the project.
        //
        // For more information, see Visual Studio Tools for Office
        // Help on upgrading solutions.
         
        private [!output UPGRADE_CLASS_NAME] oldCode;
        public [!output UPGRADE_CLASS_NAME] OldCode
        {
            get { return oldCode; }
        }

        private void [!output SAFE_CLASS_NAME]_Startup(object sender, System.EventArgs e)
        {
            oldCode = new [!output UPGRADE_CLASS_NAME]();
            OldCode._Startup(this.Application, this.InnerObject);
        }

        private void [!output SAFE_CLASS_NAME]_Shutdown(object sender, System.EventArgs e)
        {
            OldCode._Shutdown();
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

        private void DataComponentEventsHookup()
        {
        }

        private void ViewComponentEventsHookup()
        {
        }
 
        #endregion

        // This comment was generated when the solution was upgraded. 
        //
        // The commented event handlers below can be uncommented and used
        // in one of two ways:
        //
        // To move all code from the OfficeCodeBehind class, copy the
        // existing code in the OfficeCodeBehind class to the
        // corresponding methods below.
        //
        // To call the existing code in the OfficeCodeBehind class,
        // change the existing method so that it is no longer a private
        // method or an event handler.
        //
        // For more information, see Visual Studio Tools for Office Help
        // on upgrading solutions.
         
        //private void [!output SAFE_CLASS_NAME]_Open() {
        //    OldCode.ThisWorkbook_Open();
        //}

        //private void [!output SAFE_CLASS_NAME]_BeforeClose(ref bool Cancel) {
        //    OldCode.ThisWorkbook_BeforeClose(ref Cancel);
        //}
    }
}
