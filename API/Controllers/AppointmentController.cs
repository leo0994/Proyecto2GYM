using BL.Appointment;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentManager _appointmentManager;

        public AppointmentController()
        {
            _appointmentManager = new AppointmentManager();
        }

        [HttpGet]
        public ActionResult<List<AppointmentDTO>> GetAll()
        {
            var appointments = _appointmentManager.RetrieveAll();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public ActionResult<AppointmentDTO> GetById(int id)
        {
            var appointment = _appointmentManager.RetrieveById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult Create(AppointmentDTO appointment)
        {
            _appointmentManager.Create(appointment);
            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AppointmentDTO appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _appointmentManager.Update(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var appointment = _appointmentManager.RetrieveById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentManager.Delete(id);
            return NoContent();
        }
    }
}
