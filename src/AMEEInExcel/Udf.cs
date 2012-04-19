using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDna.Integration;

namespace AMEEInExcel
{
    public static class Udf
    {
        [ExcelFunction(Category = "AMEE", Description = "Get AMEE DataItem Label")]
        public static object AMEE_DATAITEM_LABEL(string path, string uid)
        {
            try
            {
                var defaultValue = string.Format("{0}->{1}", path, uid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().GetDataItemLabel(workbookName, path, uid);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }

        [ExcelFunction(Category = "AMEE", Description = "Get AMEE DataItem Value")]
        public static object AMEE_DATAITEM_VALUE(string path, string uid, string valuePath)
        {
            try
            {
                var defaultValue = string.Format("{0}->{1}", path, uid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().GetDataItemValue(workbookName, path, uid, valuePath);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }

        [ExcelFunction(Category = "AMEE", Description = "Perform AMEE calculation")]
        public static object AMEE_CALC(string path, string dataItemUid, string amountType, string argName, string argValue)
        {
            try
            {
                var defaultValue = string.Format("Calc({0}->{1})", path, dataItemUid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().Calculate(workbookName, path, dataItemUid, amountType, argName, argValue);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }


        // RCA: 20120215 - stubs below this point

        /// <summary>
        /// Units are a combination of Unit/perUnit
        /// 
        /// Unit value is a string label with represents the numerator of a unit
        /// the denominator - perUnit - is optional (depending on context)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        [ExcelFunction(Category = "AMEE", Description = "Get AMEE DataItem Unit")]
        public static object AMEE_DATAITEM_UNIT(string path, string uid)
        {
            try
            {
                var defaultValue = string.Format("{0}->{1}", path, uid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().GetDataItemUnit(workbookName, path, uid);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }

        // The 

        /// <summary>
        /// Units are a combination of Unit/perUnit
        /// 
        /// perUnit value is a string label with represents the denominator of a unit
        /// the denominator - perUnit - is optional (depending on context)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        [ExcelFunction(Category = "AMEE", Description = "Get AMEE DataItem perUnit")]
        public static object AMEE_DATAITEM_PERUNIT(string path, string uid)
        {
            try
            {
                var defaultValue = string.Format("{0}->{1}", path, uid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().GetDataItemPerUnit(workbookName, path, uid);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }


        [ExcelFunction(Category = "AMEE", Description = "Get AMEE DataItem Value")]
        public static object AMEE_DATAITEM_AMOUNT_UNIT(string path, string uid, string valuePath)
        {
            try
            {
                var defaultValue = string.Format("{0}->{1}", path, uid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().GetDataItemUnit(workbookName, path, uid, valuePath);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }


        [ExcelFunction(Category = "AMEE", Description = "Get AMEE DataItem Value")]
        public static object AMEE_DATAITEM_AMOUNT_PERUNIT(string path, string uid, string valuePath)
        {
            try
            {
                var defaultValue = string.Format("{0}->{1}", path, uid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().GetDataItemPerUnit(workbookName, path, uid, valuePath);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }


        #region nonAMEESupportFunctionality

        /*
         * Non AMEE related Worksheet specific functionality
         */

        static string CallingSheetName()
        {
            var tmp = XlCall.Excel(XlCall.xlfCaller);
            var caller = tmp as ExcelReference;
            if (caller == null)
                throw new ApplicationException("No calling worksheet found");
            var res = XlCall.Excel(XlCall.xlSheetNm, caller);
            return (string)res;
        }

        private static string GetCallingWorkbookName()
        {
            var sheetName = CallingSheetName();
            var parts = sheetName.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new ApplicationException();
            return parts[0];
        }

        #endregion
    }
}
