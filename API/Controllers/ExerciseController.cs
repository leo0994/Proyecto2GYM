using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Managers;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseManager _exerciseManager;

        public ExerciseController()
        {
            _exerciseManager = new ExerciseManager();
        }

        [HttpPost("Create")]
        public IActionResult Create(ExerciseDTO exerciseDTO)
        {
            var result = _exerciseManager.Create(exerciseDTO);
            return Ok(result);
        }

        [HttpGet("RetrieveAll")]
        public IActionResult GetAll()
        {
            var result = _exerciseManager.RetrieveAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _exerciseManager.RetrieveById(id);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(ExerciseDTO exerciseDTO)
        {
            var result = _exerciseManager.Update(exerciseDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exerciseDTO = new ExerciseDTO { Id = id };
            var result = _exerciseManager.Delete(exerciseDTO);
            return Ok(result);
        }
    }
}
