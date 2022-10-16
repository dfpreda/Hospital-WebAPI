using ClosedXML.Excel;
using Hospital.Data.Entities;
using Hospital.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.DataServices.Extensions
{
    public static class WorksheetExtension
    {
        public static void SetMedicalReportTitle(this IXLWorksheet worksheet, string title, string name, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {

            worksheet.Cell(1, 1).Value = title;
            worksheet.Cell(1, 2).Value = name;
            if (startDate.HasValue)
            {
                worksheet.Cell(1, 3).Value = "from";
                worksheet.Cell(1, 4).Value = startDate.Value;
            }

            if (endDate.HasValue)
            {
                worksheet.Cell(1, 5).Value = "to";
                worksheet.Cell(1, 6).Value = endDate.Value;
            }
        }

        public static void SetDoctorMedicalReportContent(this IXLWorksheet worksheet, IEnumerable<MedicalReport> medicalReports)
        {
            worksheet.Cell(3, 1).Value = MedicalReportConstants.COLUMNPATIENTNAME;
            worksheet.Cell(3, 2).Value = MedicalReportConstants.COLUMNGENDER;
            worksheet.Cell(3, 3).Value = MedicalReportConstants.COLUMNADDRESS;
            worksheet.Cell(3, 4).Value = MedicalReportConstants.COLUMNPHONE;
            worksheet.Cell(3, 5).Value = MedicalReportConstants.COLUMNMEDICALHISTORY;
            worksheet.Cell(3, 6).Value = MedicalReportConstants.COLUMNDATE;
            worksheet.Cell(3, 7).Value = MedicalReportConstants.COLUMNSUMMARY;
            worksheet.Cell(3, 8).Value = MedicalReportConstants.COLUMNSYMPTOMS;
            worksheet.Cell(3, 9).Value = MedicalReportConstants.COLUMNINVESTIGATIONSMADE;
            worksheet.Cell(3, 10).Value = MedicalReportConstants.COLUMNFINDINGS;
            worksheet.Cell(3, 11).Value = MedicalReportConstants.COLUMNDIAGNOSIS;
            worksheet.Cell(3, 12).Value = MedicalReportConstants.COLUMNTREATMENT;

            var currentRow = 4;

            foreach (var medicalReport in medicalReports)
            {
                worksheet.Cell(currentRow, 1).Value = medicalReport.Appointment.Patient.Name;
                worksheet.Cell(currentRow, 2).Value = medicalReport.Appointment.Patient.Gender;
                worksheet.Cell(currentRow, 3).Value = medicalReport.Appointment.Patient.Address;
                worksheet.Cell(currentRow, 4).Value = medicalReport.Appointment.Patient.Phone;
                worksheet.Cell(currentRow, 5).Value = medicalReport.Appointment.Patient.MedicalHistory;
                worksheet.Cell(currentRow, 6).Value = medicalReport.Appointment.Date;
                worksheet.Cell(currentRow, 7).Value = medicalReport.Appointment.Summary;
                worksheet.Cell(currentRow, 8).Value = medicalReport.Appointment.Symptoms;
                worksheet.Cell(currentRow, 9).Value = medicalReport.InvestigationsMade;
                worksheet.Cell(currentRow, 10).Value = medicalReport.Findings;
                worksheet.Cell(currentRow, 11).Value = medicalReport.Diagnosis;
                worksheet.Cell(currentRow, 12).Value = medicalReport.Treatment;
                currentRow++;
            }
        }

        public static void SetPatientMedicalReportContent(this IXLWorksheet worksheet, IEnumerable<MedicalReport> medicalReports)
        {
            worksheet.Cell(3, 1).Value = MedicalReportConstants.COLUMNDOCTORNAME;
            worksheet.Cell(3, 2).Value = MedicalReportConstants.COLUMNDATE;
            worksheet.Cell(3, 3).Value = MedicalReportConstants.COLUMNSUMMARY;
            worksheet.Cell(3, 4).Value = MedicalReportConstants.COLUMNSYMPTOMS;
            worksheet.Cell(3, 5).Value = MedicalReportConstants.COLUMNINVESTIGATIONSMADE;
            worksheet.Cell(3, 6).Value = MedicalReportConstants.COLUMNFINDINGS;
            worksheet.Cell(3, 7).Value = MedicalReportConstants.COLUMNDIAGNOSIS;
            worksheet.Cell(3, 8).Value = MedicalReportConstants.COLUMNTREATMENT;

            var currentRow = 4;

            foreach (var medicalReport in medicalReports)
            {
                worksheet.Cell(currentRow, 1).Value = medicalReport.Appointment.Doctor.Name;
                worksheet.Cell(currentRow, 2).Value = medicalReport.Appointment.Date;
                worksheet.Cell(currentRow, 3).Value = medicalReport.Appointment.Summary;
                worksheet.Cell(currentRow, 4).Value = medicalReport.Appointment.Symptoms;
                worksheet.Cell(currentRow, 5).Value = medicalReport.InvestigationsMade;
                worksheet.Cell(currentRow, 6).Value = medicalReport.Findings;
                worksheet.Cell(currentRow, 7).Value = medicalReport.Diagnosis;
                worksheet.Cell(currentRow, 8).Value = medicalReport.Treatment;
                currentRow++;
            }
        }

        public static void FormatForBeauty(this IXLWorksheet worksheet)
        {
            worksheet.Columns().AdjustToContents();
        }
    }
}
