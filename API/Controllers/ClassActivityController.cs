using BL.ClassActivity;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/classactivities")]
    public class ClassActivityController : ControllerBase
    {
        private readonly ClassActivityManager _classActivityManager;

        public ClassActivityController()
        {
            _classActivityManager = new ClassActivityManager();
        }

        [HttpGet]
        public ActionResult<List<ClassActivityDTO>> GetAll()
        {
            var classActivities = _classActivityManager.RetrieveAll();
            return Ok(classActivities);
        }

        [HttpGet("{id}")]
        public ActionResult<ClassActivityDTO> GetById(int id)
        {
            var classActivity = _classActivityManager.RetrieveById(id);
            if (classActivity == null)
            {
                return NotFound();
            }
            return Ok(classActivity);
        }

        [HttpPost]
        public IActionResult Create(ClassActivityDTO classActivity)
        {
            _classActivityManager.Create(classActivity);
            return CreatedAtAction(nameof(GetById), new { id = classActivity.Id }, classActivity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClassActivityDTO classActivity)
        {
            if (id != classActivity.Id)
            {
                return BadRequest();
            }

            _classActivityManager.Update(classActivity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var classActivity = _classActivityManager.RetrieveById(id);
            if (classActivity == null)
            {
                return NotFound();
            }

            _classActivityManager.Delete(id);
            return NoContent();
        }
    }
}
