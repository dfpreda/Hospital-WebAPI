using AutoMapper;
using ClosedXML.Excel;
using Hospital.Data.Entities;
using Hospital.Dtos.GetDtos;
using Hospital.Repositories.UnitofWork;
using Hospital.Services.DataServices.Contracts;
using Hospital.Services.DataServices.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.DataServices.Implementations
{
    public class MedicalReportsExportService : IMedicalReportsExportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalReportsExportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        IEnumerable<MedicalReport> GetMedicalReports(Guid id, DateTimeOffset? startDate, DateTimeOffset? endDate, string userType)
        {
            var result = _unitOfWork.MedicalReportsRepository.Get(include: i => i.Include(x => x.Appointment).ThenInclude(x => x.Doctor)
                                                                                 .Include(x => x.Appointment).ThenInclude(x => x.Patient),
                                                                  orderBy: o => o.OrderBy(x => x.Appointment.Date));

            if(userType.Equals("doctor", StringComparison.OrdinalIgnoreCase))
            {
                result.Where(x => x.Appointment.DoctorId == id);
            }
            else
            {
                result.Where(x => x.Appointment.PatientId == id);
            }

            if (startDate.HasValue)
            {
                result = result.Where(x => x.Appointment.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                result = result.Where(x => x.Appointment.Date <= endDate.Value);
            }

            return result;
        }

        public byte[] ExportDoctorMedicalReports(Guid id, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var medicalReports = GetMedicalReports(id, startDate, endDate, "");

            var doctorName = medicalReports.Select(x => x.Appointment).Select(x => x.Doctor.Name).FirstOrDefault();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Medical reports");
                worksheet.SetMedicalReportTitle("Medical reports of Doctor", doctorName, startDate, endDate);

                worksheet.SetDoctorMedicalReportContent(medicalReports);
                worksheet.FormatForBeauty();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }

        public byte[] ExportPatientMedicalReports(Guid id, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var medicalReports = GetMedicalReports(id, startDate, endDate, "patient");

            var patientName = medicalReports.Select(x => x.Appointment).Select(x => x.Patient.Name).FirstOrDefault();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Medical reports");
                worksheet.SetMedicalReportTitle("Medical reports of Patient", patientName, startDate, endDate);

                worksheet.SetPatientMedicalReportContent(medicalReports);
                worksheet.FormatForBeauty();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }
    }
}
