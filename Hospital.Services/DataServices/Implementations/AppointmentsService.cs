using AutoMapper;
using Hospital.Data.Entities;
using Hospital.Dtos.GetDtos;
using Hospital.Dtos.PostDtos;
using Hospital.Repositories.UnitofWork;
using Hospital.Services.DataServices.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.DataServices.Implementations
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetResponse<AppointmentGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.AppointmentsRepository.Get(include: i => i.Include(x => x.Doctor)
                                                                               .Include(x => x.Patient));

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Symptoms.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (startDate.HasValue)
            {
                result = result.Where(x => x.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                result = result.Where(x => x.Date <= endDate.Value);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var currentCount = result.Count();

            var response = new GetResponse<AppointmentGetDto>
            {
                ItemsCount = $"{currentCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<AppointmentGetDto>(x))
            };

            return response;
        }

        public async Task<AppointmentGetDto> GetByIdAsync(Guid? Id)
        {
            var result = await _unitOfWork.AppointmentsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            return _mapper.Map<AppointmentGetDto>(result);
        }

        public async Task<AppointmentPostDto> AddAsync(AppointmentPostDto item)
        {
            Appointment entity = _mapper.Map<Appointment>(item);
            Appointment result = await _unitOfWork.AppointmentsRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AppointmentPostDto>(result);
        }

        public async Task UpdateAsync(AppointmentPostDto item, Guid Id)
        {
            Appointment entity = await _unitOfWork.AppointmentsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            _mapper.Map(item, entity);
            _unitOfWork.AppointmentsRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? Id)
        {
            var entity = await _unitOfWork.AppointmentsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            _unitOfWork.AppointmentsRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
