using AutoMapper;
using ClosedXML.Excel;
using Hospital.BackgroundWorkers.Extensions;
using Hospital.BackgroundWorkers.Services.Contracts;
using Hospital.Data.Entities;
using Hospital.Dtos.GetDtos;
using Hospital.Repositories.UnitofWork;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BackgroundWorkers.Services.Implementations
{
    public class ExcelExportService : IExcelExportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExcelExportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<string> GetDoctors()
        {
            var result = _unitOfWork.DoctorsRepository.Get();

            return result.Where(x => x.IsDeleted == false).Select(s => s.Name);
        }

        public IEnumerable<string> GetPatients()
        {
            var result = _unitOfWork.PatientsRepository.Get(filter: f => !f.IsDeleted);

            return result.Where(x => x.IsDeleted == false).Select(s => s.Name);
        }

        public void ExcelSeed(string workbook, string worksheet, IEnumerable<string> names)
        {
            if (!File.Exists(workbook))
            {
                var _newworkbook = new XLWorkbook();
                var _newworksheet = _newworkbook.AddWorksheet(worksheet);
                WorksheetExtension.SetExcelContent(_newworksheet, names);
                WorksheetExtension.FormatForBeauty(_newworksheet);
                _newworkbook.SaveAs(workbook);
            }
            else
            {
                var _workbook = new XLWorkbook(workbook);
                var _worksheet = _workbook.Worksheet(worksheet);
                WorksheetExtension.VerifyExcelContent(_worksheet, names);
                _workbook.SaveAs(workbook);
            }
        }

        public async Task Start()
        {
            try
            {
                var doctorNames = GetDoctors();
                var patientNames = GetPatients();
                ExcelSeed(ExcelFilenameConstants.WORKBOOKDOCTORS, ExcelFilenameConstants.WORKSHEETDOCTORSLIST, doctorNames);
                ExcelSeed(ExcelFilenameConstants.WORKBOOKPATIENTS, ExcelFilenameConstants.WORKSHEETPATIENTSLIST, patientNames);
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public void Dispose()
        {

        }
    }
}
