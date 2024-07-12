using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentManager _manager;

        public EnrollmentController()
        {
            _manager = new EnrollmentManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] EnrollmentDTO enrollment)
        {
            try
            {
                var createdEnrollment = _manager.Create(enrollment);
                return Ok(createdEnrollment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] EnrollmentDTO enrollment)
        {
            try
            {
                var updatedEnrollment = _manager.Update(enrollment);
                return Ok(updatedEnrollment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] EnrollmentDTO enrollment)
        {
            try
            {
                var deletedEnrollment = _manager.Delete(enrollment);
                return Ok(deletedEnrollment);
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
                var enrollments = _manager.RetrieveAll();
                return Ok(enrollments);
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
                var enrollment = _manager.RetrieveById(id);
                return Ok(enrollment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
