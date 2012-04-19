using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;



namespace AMEEInExcel
{
    public partial class ThisAddIn
    {

        public static ThisAddIn Instance { get; private set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Instance = this;
            InitXllAddin();

#if DEBUG
            var debugFilePath = GetAppLocation() + @"..\..\DebugTest.xlsm";
            //var debugFilePath = GetAppLocation() + @"C:\development\build\AMEEInExcel\src\AMEEInExcel\DebugTest.xlsm";

            if (File.Exists(debugFilePath))
                Application.Workbooks.Open(debugFilePath);

            // switch to our ribbon tab
            Application.SendKeys("%");
            Application.SendKeys("AM {ESC}");
#endif


            ThisAddIn_Startup1(sender, e);

        }


        public void AddWorkSheet()
        {
            Application.Worksheets.Add();
        }



        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        public static string GetAppLocation()
        {
            var location = Assembly.GetExecutingAssembly().CodeBase;
            location = (new Uri(location)).LocalPath;
            var res = Path.GetDirectoryName(location) + "\\";
            return res;
        }

        public string Version
        {
            get
            {
                try
                {
                    var version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    return string.Format("v{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build,
                        version.Revision);
                }
                catch (InvalidDeploymentException)
                {
                    var res = string.Format("v{0}D", Assembly.GetCallingAssembly().GetName().Version);
                    return res;
                }
            }
        }

        void InitXllAddin()
        {
            // register UDF proxy add-in
            var xllPath = GetAppLocation() + @"AMEEInExcel.xll";
            try
            {
                File.WriteAllBytes(xllPath, ExcelDna.Files.Xll);
            }
            catch (IOException exc)
            {
                if (!IsFileBusyException(exc))
                    ReportWarning(exc);
            }
            try
            {
                var dnaPath = Path.ChangeExtension(xllPath, ".dna");
                File.WriteAllBytes(dnaPath, ExcelDna.Files.Dna);
            }
            catch (IOException exc)
            {
                if (!IsFileBusyException(exc))
                    ReportWarning(exc);
            }
            if (!Application.RegisterXLL(xllPath)) // temporary registration of XLL add-in for this run
                ReportWarning(string.Format("XLL add-in failed to load from {0}.  Do you have the Office Shared Feature > Visual Basic for Applications installed?", xllPath));
        }


        static bool IsFileBusyException(IOException exc)
        {
            var hr = (uint)Marshal.GetHRForException(exc);
            return (hr == 0x80070020); // The process cannot access the file because it is being used by another process. 
        }

        public void ReportWarning(string message)
        {
            ReportException(new ApplicationException(message), false);
        }

        public void ReportWarning(Exception exc)
        {
            ReportException(exc, false);
        }

        public void ReportException(Exception exc)
        {
            ReportException(exc, true);
        }

        void ReportException(Exception exc, bool showWindow)
        {
            if (exc is ObjectDisposedException || exc is ThreadAbortException)
                return;
            
            try
            {
                Trace.WriteLine(exc);
                MessageBox.Show(exc.ToString());
//                _log.Error(message);
//
//                if (showWindow)
//                {
//                    _exceptionForm.AddMessage(message);
//                    _exceptionForm.ShowError();
//                }
            }
            catch (Exception exc2)
            {
                Trace.WriteLine(exc);
                Trace.WriteLine(exc2);
            }
        }

#region right_mouse_context_menu
        // right mouse menu 
        private Office.CommandBarButton generateWikiList;
        private Excel.Range selectedCells;


        private void ThisAddIn_Startup1(object sender, System.EventArgs e)
        {
            DefineShortcutMenu();
            Application.SheetBeforeRightClick +=
                new Excel.AppEvents_SheetBeforeRightClickEventHandler
                    (Application_SheetBeforeRightClick);
            generateWikiList.Click +=
                new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler
                    (BuildWikiList_Click);
        }

        void BuildWikiList_Click(Office.CommandBarButton Ctrl,
            ref bool CancelDefault)
        {
            try
            {
                /*
                Authentication.Logon lgn = new Authentication.Logon();
                lgn.Show();
                */

                AMEEInExcel.FrmWikiList buildlist = new FrmWikiList();
                buildlist.Show();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        void Application_SheetBeforeRightClick(object Sh,
            Excel.Range Target, ref bool Cancel)
        {
            selectedCells = Target;
        }

        private void DefineShortcutMenu()
        {

            Office.MsoControlType menuItem = Office.MsoControlType.msoControlButton;
            generateWikiList = (Office.CommandBarButton)Application.CommandBars["Cell"].
                Controls.Add(menuItem, missing, missing, 1, true);

            generateWikiList.Style = Office.MsoButtonStyle.msoButtonIconAndCaption/*.msoButtonCaption*/;
            generateWikiList.Caption = "Get Wiki List";
            generateWikiList.FaceId = 7;
            generateWikiList.Tag = "0";
        }

#endregion




        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }





}
