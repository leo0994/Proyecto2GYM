using DTOs;
using Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly MachineManager _manager;

        public MachineController()
        {
            _manager = new MachineManager();
        }

        [HttpPost]
        public IActionResult Create(MachineDTO machine)
        {
            _manager.Create(machine);
            return Ok();
        }

        [HttpGet]
        public IActionResult RetrieveAll()
        {
            return Ok(_manager.RetrieveAll());
        }

        [HttpGet("{id}")]
        public IActionResult RetrieveById(int id)
        {
            return Ok(_manager.RetrieveById(id));
        }

        [HttpPut]
        public IActionResult Update(MachineDTO machine)
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
    }
}
