using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseBaseController : ControllerBase
    {
        private readonly ExerciseBaseManager _manager;

        public ExerciseBaseController()
        {
            _manager = new ExerciseBaseManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExerciseBaseDTO exerciseBase)
        {
            _manager.Create(exerciseBase);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ExerciseBaseDTO exerciseBase)
        {
            _manager.Update(exerciseBase);
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
            var exerciseBase = _manager.RetrieveById(id);
            return Ok(exerciseBase);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exerciseBases = _manager.RetrieveAll();
            return Ok(exerciseBases);
        }
    }
}
