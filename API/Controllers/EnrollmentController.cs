using DTOs;
using DAO.Crud;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentCrudFactory _enrollmentCrudFactory;

        public EnrollmentController()
        {
            _enrollmentCrudFactory = new EnrollmentCrudFactory();
        }

        [HttpGet]
        public ActionResult<List<EnrollmentDTO>> GetAllEnrollments()
        {
            var enrollments = _enrollmentCrudFactory.RetrieveAll();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public ActionResult<EnrollmentDTO> GetEnrollmentById(int id)
        {
            var enrollment = _enrollmentCrudFactory.RetrieveById(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult CreateEnrollment(EnrollmentDTO enrollment)
        {
            _enrollmentCrudFactory.Create(enrollment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            _enrollmentCrudFactory.Delete(id);
            return Ok();
        }
    }
}
