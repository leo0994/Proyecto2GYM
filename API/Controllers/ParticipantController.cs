using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantManager _manager;

        public ParticipantController()
        {
            _manager = new ParticipantManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ParticipantDTO participant)
        {
            try
            {
                var createdParticipant = _manager.Create(participant);
                return Ok(createdParticipant);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ParticipantDTO participant)
        {
            try
            {
                var updatedParticipant = _manager.Update(participant);
                return Ok(updatedParticipant);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] ParticipantDTO participant)
        {
            try
            {
                var deletedParticipant = _manager.Delete(participant);
                return Ok(deletedParticipant);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("RetrieveAll")]
        public IActionResult RetrieveAll()
        {
            try
            {
                var participants = _manager.RetrieveAll();
                return Ok(participants);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("RetrieveById/{id}")]
        public IActionResult RetrieveById(int id)
        {
            try
            {
                var participant = _manager.RetrieveById(id);
                return Ok(participant);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
