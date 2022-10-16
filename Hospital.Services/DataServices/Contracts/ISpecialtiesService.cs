using Hospital.Dtos.GetDtos;
using Hospital.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace Hospital.Services.DataServices.Contracts
{
    public interface ISpecialtiesService
    {
        Task<SpecialtyPostDto> AddAsync(SpecialtyPostDto item);
        Task DeleteAsync(Guid? Id);
        GetResponse<SpecialtyGetDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        Task<SpecialtyGetDto> GetByIdAsync(Guid? Id);
        Task UpdateAsync(SpecialtyPostDto item, Guid Id);
    }
}