using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly PasswordManager _manager;

        public PasswordController()
        {
            _manager = new PasswordManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] PasswordDTO password)
        {
            _manager.Create(password);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] PasswordDTO password)
        {
            _manager.Update(password);
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
            var password = _manager.RetrieveById(id);
            return Ok(password);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var passwords = _manager.RetrieveAll();
            return Ok(passwords);
        }
    }
}
