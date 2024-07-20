using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;

namespace API.Controllers
    //test // test 2 // test 3 //Test 4
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentManager _manager;

        public AppointmentController()
        {
            _manager = new AppointmentManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] AppointmentDTO appointment)
        {
            try
            {
                var createdAppointment = _manager.Create(appointment);
                return Ok(createdAppointment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] AppointmentDTO appointment)
        {
            try
            {
                var updatedAppointment = _manager.Update(appointment);
                return Ok(updatedAppointment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] AppointmentDTO appointment)
        {
            try
            {
                var deletedAppointment = _manager.Delete(appointment);
                return Ok(deletedAppointment);
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
                var appointments = _manager.RetrieveAll();
                return Ok(appointments);
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
                var appointment = _manager.RetrieveById(id);
                return Ok(appointment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
