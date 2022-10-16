using Hospital.Dtos.GetDtos;
using Hospital.Dtos.PostDtos;
using Hospital.Services.DataServices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _doctorsService;
        /// <summary>
        /// Doctors controller constructor
        /// </summary>
        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        /// <summary>
        /// Get doctors
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Doctor, Patient")]
        public GetResponse<DoctorGetDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _doctorsService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get doctor
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult<DoctorGetDto>> GetById(Guid id)
        {
            var result = await _doctorsService.GetByIdAsync(id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        /// <summary>
        /// Get doctor's specialties
        /// </summary>
        [HttpGet("{id}/Specialties")]
        [Authorize(Roles = "Doctor, Patient")]
        public GetResponse<SpecialtyGetDto> GetDoctorSpecialties(Guid id, int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _doctorsService.GetDoctorSpecialties(id, skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get doctor's appointments
        /// </summary>
        [HttpGet("{id}/Appointments")]
        public GetResponse<AppointmentGetDto> GetDoctorAppointments(Guid id, int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _doctorsService.GetDoctorAppointments(id, skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get doctor's medical reports
        /// </summary>
        [HttpGet("{id}/MedicalReports")]
        public GetResponse<MedicalReportGetDto> GetDoctorMedicalReports(Guid id, int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _doctorsService.GetDoctorMedicalReports(id, skip, take, filter, includeDeleted);
        }


        /// <summary>
        /// Update doctor
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] DoctorPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _doctorsService.UpdateAsync(item, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete doctor
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                await _doctorsService.DeleteAsync(id);
                return Ok();
            }

            return NotFound();
        }
    }
}
