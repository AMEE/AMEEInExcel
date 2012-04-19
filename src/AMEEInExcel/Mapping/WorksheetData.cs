using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// the MS Office Interop 
using System.Reflection;

using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

using AMEEInExcel.Model;

namespace AMEEInExcel.Mapping
{
    class WorksheetData
    {

        public static void BuildExcelWorksheet(DataCategory categoryData)
        {
            //CreateNewWorkSheet();
            //ThisAddIn.Instance.Application.Worksheets.Add();

            Excel.Worksheet newWorksheet;
            newWorksheet = (Excel.Worksheet)ThisAddIn.Instance.Application.Worksheets.Add();

            // 31 chars is the longest length for the sheetname
            newWorksheet.Name = StringHelper.LimitWithElipsesOnWordBoundary(categoryData.WikiName.Replace("_", " "), 31);

            //Add table headers going cell by cell.
            int rowCntr = 1;
            int colCntr = 1;

            newWorksheet.Cells[rowCntr, 1] = "Name";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Name;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "WikiName";
            newWorksheet.Cells[rowCntr, 2] = categoryData.WikiName;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "FullPath";
            newWorksheet.Cells[rowCntr, 2] = categoryData.FullPath;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "Path";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Path;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "Created";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Created;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "Last Modified";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Modified;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "Uid";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Uid;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "Name";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Name;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "ParentUid";
            newWorksheet.Cells[rowCntr, 2] = categoryData.ParentUid;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "ParentWikiName";
            newWorksheet.Cells[rowCntr, 2] = categoryData.ParentWikiName;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "ParentWikiName";
            newWorksheet.Cells[rowCntr, 2] = categoryData.ParentWikiName;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "Authority";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Authority;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "History";
            newWorksheet.Cells[rowCntr, 2] = categoryData.History;
            rowCntr++;

            newWorksheet.Cells[rowCntr, 1] = "Provenance";
            newWorksheet.Cells[rowCntr, 2] = categoryData.Provenance;
            rowCntr++;
            
            // header information
            // add the uids to the sheet
            rowCntr+=2;

            //rowCntr = 15;
            colCntr = 1;

            for (int cntr = 0; cntr < categoryData.item.Count(); cntr++)
            {
                colCntr = 1;

                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Uid";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Name";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Path";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "FullPath";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Label";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "WikiDoc";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Provenance";

                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "StartDate";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "EndDate";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Created";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Modified";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "CategoryUid";
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = "CategoryWikiName";

                for (int itemValueCntr = 0; itemValueCntr < categoryData.item[cntr].ItemValues.Count(); itemValueCntr++)
                {
                    if (categoryData.item[cntr].ItemValues[itemValueCntr] == null)
                        continue;

                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Path";
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Name";
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Value";
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = "Unit";
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = "PerUnit";
                }
            }            
            
            // data will start at row 10.

            // add the uids to the sheet
            rowCntr++;

            //rowCntr = 16;
            colCntr = 1;

            for (int cntr = 0; cntr < categoryData.item.Count(); cntr++)
            {
                colCntr = 1;

                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].Uid;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].Name;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].Path;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].FullPath;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].Label;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].WikiDoc;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].Provenance;

                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].StartDate;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].EndDate;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].Created;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].Modified;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].CategoryUid;
                newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].CategoryWikiName;

                for (int itemValueCntr = 0; itemValueCntr < categoryData.item[cntr].ItemValues.Count(); itemValueCntr++) 
                {
                    if (categoryData.item[cntr].ItemValues[itemValueCntr] == null)
                        continue;

                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].ItemValues[itemValueCntr].Path;
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].ItemValues[itemValueCntr].Name;
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].ItemValues[itemValueCntr].Value;
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].ItemValues[itemValueCntr].Unit;
                    newWorksheet.Cells[rowCntr + cntr, colCntr++] = categoryData.item[cntr].ItemValues[itemValueCntr].PerUnit;
                }

                /*
                    //  public DataCategoryItem DataCategory;
                          //  public Environment Environment;

                                    // only need the itemdef for drill information
                    public ItemDefinition ItemDefinition;

                */

            }

            //newWorksheet.Cells[1, 2] = "path";

            //rowCntr = 2; colCntr = 2;

            //foreach (String ids in uids)
            //{
            //    newWorksheet.Cells[rowCntr++, colCntr] = fullPath;
            //}

            //newWorksheet.Cells[1, 3] = "uid";

            //// add the uids to the sheet
            //rowCntr = 2; colCntr = 3;

            //Excel.Range oUidRng;
            //oUidRng = newWorksheet.get_Range("C" + rowCntr.ToString(), "C" + (uids.Count + (rowCntr - 1)).ToString());
            //oUidRng.EntireColumn.NumberFormat = "Text";
            //oUidRng.EntireColumn.NumberFormatLocal = "Text";

            //foreach (String ids in uids)
            //{

            //    /*
            //     * Excel assumes that 0
            //     * the Leading 0s cause the cell to formatted as a number 
            //     * and the leading 0 will be stripped off (lost)
            //     */
            //    if ((uids.ToString().Substring(0, 1) == "0") || (uids.ToString().Substring(0, 1) == "O"))
            //        newWorksheet.Cells[rowCntr++, colCntr] = "'" + ids.ToString();
            //    else
            //        newWorksheet.Cells[rowCntr++, colCntr] = ids.ToString();
            //}

            //newWorksheet.Cells[1, 4] = "Label";

            //rowCntr = 2; colCntr = 4;
            //Excel.Range oRng;
            //oRng = newWorksheet.get_Range("D" + rowCntr.ToString(), "D" + (uids.Count + (rowCntr - 2)).ToString());
            //oRng.Formula = "=AMEE_DATAITEM_LABEL(B2,C2)";

        }

    }
}
