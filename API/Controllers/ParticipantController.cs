using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantManager _manager;

        public ParticipantController()
        {
            _manager = new ParticipantManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ParticipantDTO participant)
        {
            _manager.Create(participant);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ParticipantDTO participant)
        {
            _manager.Update(participant);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var participant = _manager.RetrieveById(id);
            return Ok(participant);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var participants = _manager.RetrieveAll();
            return Ok(participants);
        }
    }
}
