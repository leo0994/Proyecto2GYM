using DTOs;
using Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MachineController : ControllerBase
    {
        private readonly MachineManager _manager;

        public MachineController()
        {
            _manager = new MachineManager();
        }

        [HttpPost]
        public IActionResult Create(MachineDTO machineDTO)
        {
            var result = _manager.Create(machineDTO);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult RetrieveAll()
        {
            var result = _manager.RetrieveAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult RetrieveById(int id)
        {
            var result = _manager.RetrieveById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(MachineDTO machineDTO)
        {
            var result = _manager.Update(machineDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var machineDTO = new MachineDTO { Id = id };
            var result = _manager.Delete(machineDTO);
            return Ok(result);
        }
    }
}