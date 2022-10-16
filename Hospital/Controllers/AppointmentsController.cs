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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;
        /// <summary>
        /// Appointments controller constructor
        /// </summary>
        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        /// <summary>
        /// Get appointments
        /// </summary>
        [HttpGet]
        public GetResponse<AppointmentGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter = null, bool includeDeleted = false)
        {
            return _appointmentsService.Get(skip, take, startDate, endDate, filter, includeDeleted);
        }

        /// <summary>
        /// Get appointment
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult<AppointmentGetDto>> GetById(Guid id)
        {
            var result = await _appointmentsService.GetByIdAsync(id);
            
            if(result != null)
            {
                return result;
            }

            return NotFound();
        }

        /// <summary>
        /// Add appointment
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult> Add([FromBody] AppointmentPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _appointmentsService.AddAsync(item);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Update appointment
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult> Update(Guid id, [FromBody] AppointmentPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _appointmentsService.UpdateAsync(item, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete appointment
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                await _appointmentsService.DeleteAsync(id);
                return Ok();
            }

            return NotFound();
        }
    }
}
