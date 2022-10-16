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
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patientsService;
        /// <summary>
        /// Patients controller constructor
        /// </summary>
        public PatientsController(IPatientsService patientsService)
        {
            _patientsService = patientsService;
        }

        /// <summary>
        /// Get patients
        /// </summary>
        [HttpGet]
        public GetResponse<PatientGetDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _patientsService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get patient
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult<PatientGetDto>> GetById(Guid id)
        {
            var result = await _patientsService.GetByIdAsync(id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        /// <summary>
        /// Get patient's appointments
        /// </summary>
        [HttpGet("{id}/Appointments")]
        [Authorize(Roles = "Doctor, Patient")]
        public GetResponse<AppointmentGetDto> GetPatientAppointments(Guid id, int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _patientsService.GetPatientAppointments(id, skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get patient's medical reports
        /// </summary>
        [HttpGet("{id}/MedicalReports")]
        [Authorize(Roles = "Doctor, Patient")]
        public GetResponse<MedicalReportGetDto> GetPatientMedicalReports(Guid id, int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _patientsService.GetPatientMedicalReports(id, skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Update patient
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult> Update(Guid id, [FromBody] PatientPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _patientsService.UpdateAsync(item, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete patient
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                await _patientsService.DeleteAsync(id);
                return Ok();
            }

            return NotFound();
        }
    }
}
