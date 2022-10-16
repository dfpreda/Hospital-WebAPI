using Hospital.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace Hospital.Services.DataServices.Contracts
{
    public interface IAuthenticationService
    {
        Task<DoctorPostDto> RegisterAsync(DoctorPostDto item);
        Task<PatientPostDto> RegisterAsync(PatientPostDto item);
        Task<string> DoctorLoginAsync(LoginPostDto item);
        Task<string> PatientLoginAsync(LoginPostDto item);
    }
}