using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasureController : ControllerBase
    {
        private readonly MeasureManager _manager;

        public MeasureController()
        {
            _manager = new MeasureManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] MeasureDTO measure)
        {
            _manager.Create(measure);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] MeasureDTO measure)
        {
            _manager.Update(measure);
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
            var measure = _manager.RetrieveById(id);
            return Ok(measure);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var measures = _manager.RetrieveAll();
            return Ok(measures);
        }
    }
}
