using BL.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly MachineManager _manager;

        public MachineController()
        {
            _manager = new MachineManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] MachineDTO machine)
        {
            _manager.Create(machine);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] MachineDTO machine)
        {
            _manager.Update(machine);
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
            var machine = _manager.RetrieveById(id);
            return Ok(machine);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var machines = _manager.RetrieveAll();
            return Ok(machines);
        }
    }
}
