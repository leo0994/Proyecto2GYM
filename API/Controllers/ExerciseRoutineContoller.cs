using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Managers;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseRoutineController : ControllerBase
    {
        private readonly ExerciseRoutineManager _exerciseRoutineManager;

        public ExerciseRoutineController()
        {
            _exerciseRoutineManager = new ExerciseRoutineManager();
        }

        [HttpPost("Create")]
        public IActionResult Create(ExerciseRoutineDTO exerciseRoutineDTO)
        {
            var result = _exerciseRoutineManager.Create(exerciseRoutineDTO);
            return Ok(result);
        }

        [HttpGet("RetrieveAll")]
        public IActionResult GetAll()
        {
            var result = _exerciseRoutineManager.RetrieveAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _exerciseRoutineManager.RetrieveById(id);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(ExerciseRoutineDTO exerciseroutineDTO)
        {
            var result = _exerciseRoutineManager.Update(exerciseroutineDTO);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] ExerciseRoutineDTO exerciseRoutine)
        {
        
            var result = _exerciseRoutineManager.Delete(exerciseRoutine);
            return Ok(result);
        }
    }
}
