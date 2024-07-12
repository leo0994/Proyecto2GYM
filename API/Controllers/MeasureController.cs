using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;
using BL.Managers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly MeasureManager _manager;

        public MeasureController()
        {
            _manager = new MeasureManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] MeasureDTO measure)
        {
            try
            {
                var createdMeasure = _manager.Create(measure);
                return Ok(createdMeasure);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] MeasureDTO measure)
        {
            try
            {
                var updatedMeasure = _manager.Update(measure);
                return Ok(updatedMeasure);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] MeasureDTO measure)
        {
            try
            {
                var deletedMeasure = _manager.Delete(measure);
                return Ok(deletedMeasure);
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
                var measures = _manager.RetrieveAll();
                return Ok(measures);
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
                var measure = _manager.RetrieveById(id);
                return Ok(measure);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
