using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET.Domain;
using NET.Services.Interfaces;

namespace NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PRController : ControllerBase
    {
        private readonly IPrService _prService;

        public PRController(IPrService prService)
        {
            _prService = prService;
        }

        [HttpPost("CreatePR")]
        public async Task<IActionResult> CreatePR([FromBody] CreatePRDTO createPrDto)
        {
            var pr = await _prService.CreatePRAsync(createPrDto);
            return Ok(pr);
        }

        [HttpGet("GetPR/{id}")]
        public async Task<IActionResult> GetPR(int id)
        {
            var pr = await _prService.GetPRByIdAsync(id);
            if (pr == null)
            {
                return NotFound("PR not found.");
            }
            return Ok(pr);
        }

        [HttpGet("GetAllPRs")]
        public async Task<IActionResult> GetAllPRs()
        {
            var prs = await _prService.GetAllPRsAsync();
            return Ok(prs);
        }
        [HttpPut("UpdatePR/{id}")]
        public async Task<IActionResult> UpdatePR(int id, [FromBody] UpdatePRDTO updatePrDto)
        {
            try
            {
                var pr = await _prService.UpdatePRAsync(id, updatePrDto);
                return Ok(pr);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeletePR/{id}")]
        public async Task<IActionResult> DeletePR(int id)
        {
            var pr = await _prService.DeletePRAsync(id);
            
            if (pr == false)
            {
                return NotFound("PR not found.");
            }
            return Ok("PR deleted successfully.");
        }
    }
}