using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BackgroundWorkers.Extensions
{
    public static class WorksheetExtension
    {
        public static void VerifyExcelContent(this IXLWorksheet worksheet, IEnumerable<string> names)
        {
            if (names.Count() == worksheet.Column(1).CellsUsed().Count())
            {
                foreach (var name in names)
                {
                    if (!worksheet.Rows().CellsUsed().Any(x => x.Equals(name)))
                    {
                        SetExcelContent(worksheet, names);
                        FormatForBeauty(worksheet);
                    }
                }
                SetExcelContent(worksheet, names);
                FormatForBeauty(worksheet);
            }
            else
            {
                SetExcelContent(worksheet, names);
                FormatForBeauty(worksheet);
            }
        }
        public static void SetExcelContent(this IXLWorksheet worksheet, IEnumerable<string> names)
        {
            var currentRow = 1;
            foreach (var name in names)
            {
                worksheet.Cell(currentRow, 1).Value = name;
                currentRow++;
            }
            
        }

        public static void FormatForBeauty(this IXLWorksheet worksheet)
        {
            worksheet.Columns().AdjustToContents();
        }
    }
}
