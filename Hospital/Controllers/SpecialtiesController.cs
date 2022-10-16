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
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesService _specialtiesService;
        /// <summary>
        /// Specialties controller constructor
        /// </summary>
        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        /// <summary>
        /// Get specialties
        /// </summary>
        [HttpGet]
        public GetResponse<SpecialtyGetDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _specialtiesService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get specialty
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialtyGetDto>> GetById(Guid id)
        {
            var result = await _specialtiesService.GetByIdAsync(id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        /// <summary>
        /// Add specialty
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] SpecialtyPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _specialtiesService.AddAsync(item);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Update specialty
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] SpecialtyPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _specialtiesService.UpdateAsync(item, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete specialty
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                await _specialtiesService.DeleteAsync(id);
                return Ok();
            }

            return NotFound();
        }
    }
}
