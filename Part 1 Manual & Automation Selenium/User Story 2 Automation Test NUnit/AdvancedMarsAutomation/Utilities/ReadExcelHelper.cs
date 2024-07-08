using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OfficeOpenXml;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Utilities
{
    public class ReadExcelHelper
    {
        public List<Dictionary<string, string>> ReadExcelFile(string filePath)
        {
            var data = new List<Dictionary<string, string>>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Assumes data is in the first worksheet
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++) // Start at 2 to skip header row
                {
                    var rowData = new Dictionary<string, string>();
                    for (int col = 1; col <= colCount; col++)
                    {
                        var header = worksheet.Cells[1, col].Value.ToString();
                        var cellValue = worksheet.Cells[row, col].Value?.ToString() ?? string.Empty;
                        rowData[header] = cellValue;
                    }
                    data.Add(rowData);
                }
            }
            return data;
        }


    }
}
