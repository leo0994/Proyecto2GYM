using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;

namespace API.Controllers
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
                var response = _manager.Create(appointment);
                return Ok(ResponseHelper.Success<AppointmentDTO>(response, "Appointment created"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] AppointmentDTO appointment)
        {
            try
            {
                var response = _manager.Update(appointment);
                return Ok(ResponseHelper.Success<AppointmentDTO>(response, "Appointment updated"));
            }
             catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] AppointmentDTO appointment)
        {
            try
            {
                var response = _manager.Delete(appointment);
                return Ok(ResponseHelper.Success<AppointmentDTO>(response, "Appointment deleted"));
            }
             catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }

        [HttpGet("RetrieveAll")]
        public IActionResult RetrieveAll()
        {
            try
            {
                var response = _manager.RetrieveAll();
                return Ok(ResponseHelper.Success<List<AppointmentDTO>>(response, "Getting all appointments"));
            }
             catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }

        [HttpGet("RetrieveAllByUser")]
        public IActionResult RetrieveAllByUser(int id)
        {
            try
            {
                var response = _manager.RetrieveByUser(id);
                return Ok(ResponseHelper.Success<List<AppointmentDTO>>(response, "Getting all appointments by user"+id));
            }
             catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }

        [HttpGet("RetrieveById/{id}")]
        public IActionResult RetrieveById(int id)
        {
            try
            {            
                var response = _manager.RetrieveById(id);
                return Ok(ResponseHelper.Success<AppointmentDTO>(response, "Getting appointment" + id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }
    }
}
