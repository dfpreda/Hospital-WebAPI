using Hospital.Dtos.GetDtos;
using Hospital.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace Hospital.Services.DataServices.Contracts
{
    public interface IDoctorsService
    {
        Task DeleteAsync(Guid? Id);
        GetResponse<DoctorGetDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        GetResponse<MedicalReportGetDto> GetDoctorMedicalReports(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        GetResponse<AppointmentGetDto> GetDoctorAppointments(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        GetResponse<SpecialtyGetDto> GetDoctorSpecialties(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        Task<DoctorGetDto> GetByIdAsync(Guid? Id);
        Task UpdateAsync(DoctorPostDto item, Guid Id);
    }
}