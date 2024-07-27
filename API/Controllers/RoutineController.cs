using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly RoutineManager _manager;

        public RoutineController()
        {
            _manager = new RoutineManager();
        }

        [HttpPost("Create")]

        public IActionResult Create([FromBody] RoutineDTO routine)
        {
            /*
            try
            {
                var createdRoutine = _manager.Create(routine);
                return Ok(createdRoutine);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            */
        var result = _manager.Create(routine);
        return Ok(result);

        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] RoutineDTO routine)
        {
            try
            {
                var updatedRoutine = _manager.Update(routine);
                return Ok(updatedRoutine);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] RoutineDTO routine)
        {
            try
            {
                var deletedRoutine = _manager.Delete(routine);
                return Ok(deletedRoutine);
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
                var routines = _manager.RetrieveAll();
                return Ok(routines);
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
                var routine = _manager.RetrieveById(id);
                return Ok(routine);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
