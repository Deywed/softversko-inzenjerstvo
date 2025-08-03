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
    public class JoinRequestController : ControllerBase
    {
        private readonly IJoinRequestService _joinRequestService;

        public JoinRequestController(IJoinRequestService joinRequestService)
        {
            _joinRequestService = joinRequestService;
        }

        [HttpGet("GettAllJoinRequests")]
        public async Task<IActionResult> GetAllJoinRequests()
        {
            var joinRequests = await _joinRequestService.GetAllJoinRequestsAsync();
            return Ok(joinRequests);
        }

        [HttpGet("GetJoinRequestById/{id}")]
        public async Task<IActionResult> GetJoinRequestById(int id)
        {
            var joinRequest = await _joinRequestService.GetJoinRequestByIdAsync(id);
            if (joinRequest == null)
            {
                return NotFound($"Join request with ID {id} not found.");
            }
            return Ok(joinRequest);
        }

        [HttpPost("CreateJoinRequest")]
        public async Task<IActionResult> CreateJoinRequest([FromBody] CreateJoinRequestDTO joinRequestDto)
        {
            if (joinRequestDto == null)
            {
                return BadRequest("Join request data is null.");
            }

            var createdJoinRequest = await _joinRequestService.CreateJoinRequestAsync(joinRequestDto);
            return Ok(createdJoinRequest);
        }
        [HttpPut("UpdateJoinRequest/{id}")]
        public async Task<IActionResult> UpdateJoinRequest(int id, [FromBody] UpdateJoinRequestDTO updateJoinRequestDto)
        {
            if (updateJoinRequestDto == null)
            {
                return BadRequest("Update request data is null.");
            }
            var updatedJoinRequest = await _joinRequestService.UpdateJoinRequestAsync(id, updateJoinRequestDto);
            if (updatedJoinRequest == null)
            {
                return NotFound($"Join request with ID {id} not found.");
            }

            return Ok(updatedJoinRequest);
        }

        [HttpDelete("DeleteJoinRequest/{id}")]
        public async Task<IActionResult> DeleteJoinRequest(int id)
        {
            var deleted = await _joinRequestService.DeleteJoinRequestAsync(id);
            if (!deleted)
            {
                return NotFound($"Join request with ID {id} not found.");
            }

            return Ok($"Join request with ID {id} deleted successfully.");
        }
    }
}