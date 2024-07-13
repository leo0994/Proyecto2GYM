using DTOs;
using Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassActivityController : ControllerBase
    {
        private readonly ClassActivityManager _manager;

        public ClassActivityController()
        {
            _manager = new ClassActivityManager();
        }

        [HttpPost]
        public IActionResult Create(ClassActivityDTO classActivity)
        {
            _manager.Create(classActivity);
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
        public IActionResult Update(ClassActivityDTO classActivity)
        {
            _manager.Update(classActivity);
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
