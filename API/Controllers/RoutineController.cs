using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutineController : ControllerBase
    {
        private readonly RoutineManager _manager;

        public RoutineController()
        {
            _manager = new RoutineManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] RoutineDTO routine)
        {
            _manager.Create(routine);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] RoutineDTO routine)
        {
            _manager.Update(routine);
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
            var routine = _manager.RetrieveById(id);
            return Ok(routine);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var routines = _manager.RetrieveAll();
            return Ok(routines);
        }
    }
}
