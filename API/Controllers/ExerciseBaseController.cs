using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseBaseController : ControllerBase
    {
        private readonly ExerciseBaseManager _manager;

        public ExerciseBaseController()
        {
            _manager = new ExerciseBaseManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ExerciseBaseDTO exerciseBase)
        {
            try
            {
                var createdExerciseBase = _manager.Create(exerciseBase);
                return Ok(createdExerciseBase);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ExerciseBaseDTO exerciseBase)
        {
            try
            {
                var updatedExerciseBase = _manager.Update(exerciseBase);
                return Ok(updatedExerciseBase);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] ExerciseBaseDTO exerciseBase)
        {
            try
            {
                var deletedExerciseBase = _manager.Delete(exerciseBase);
                return Ok(deletedExerciseBase);
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
                var exerciseBases = _manager.RetrieveAll();
                return Ok(exerciseBases);
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
                var exerciseBase = _manager.RetrieveById(id);
                return Ok(exerciseBase);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
