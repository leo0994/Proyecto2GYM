using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryEnrollmentController : ControllerBase
    {
        private readonly HistoryEnrollmentManager _manager;

        public HistoryEnrollmentController()
        {
            _manager = new HistoryEnrollmentManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] HistoryEnrollmentDTO historyEnrollment)
        {
            _manager.Create(historyEnrollment);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] HistoryEnrollmentDTO historyEnrollment)
        {
            _manager.Update(historyEnrollment);
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
            var historyEnrollment = _manager.RetrieveById(id);
            return Ok(historyEnrollment);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var historyEnrollments = _manager.RetrieveAll();
            return Ok(historyEnrollments);
        }
    }
}
