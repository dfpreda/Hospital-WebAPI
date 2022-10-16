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
    public class MedicalReportsController : ControllerBase
    {
        private readonly IMedicalReportsService _medicalReportsService;
        /// <summary>
        /// MedicalReports controller constructor
        /// </summary>
        public MedicalReportsController(IMedicalReportsService medicalReportsService)
        {
            _medicalReportsService = medicalReportsService;
        }

        /// <summary>
        /// Get medical reports
        /// </summary>
        [HttpGet]
        public GetResponse<MedicalReportGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter = null, bool includeDeleted = false)
        {
            return _medicalReportsService.Get(skip, take, startDate, endDate, filter, includeDeleted);
        }

        /// <summary>
        /// Get medical report
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult<MedicalReportGetDto>> GetById(Guid id)
        {
            var result = await _medicalReportsService.GetByIdAsync(id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        /// <summary>
        /// Add medical report
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MedicalReportPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _medicalReportsService.AddAsync(item);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Update medical report
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] MedicalReportPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _medicalReportsService.UpdateAsync(item, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete medical report
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                await _medicalReportsService.DeleteAsync(id);
                return Ok();
            }

            return NotFound();
        }
    }
}
