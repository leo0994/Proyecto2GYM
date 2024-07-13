using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly PasswordManager _manager;

        public PasswordController()
        {
            _manager = new PasswordManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] PasswordDTO password)
        {
            try
            {
                var createdPassword = _manager.Create(password);
                return Ok(createdPassword);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] PasswordDTO password)
        {
            try
            {
                var updatedPassword = _manager.Update(password);
                return Ok(updatedPassword);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] PasswordDTO password)
        {
            try
            {
                var deletedPassword = _manager.Delete(password);
                return Ok(deletedPassword);
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
                var passwords = _manager.RetrieveAll();
                return Ok(passwords);
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
                var password = _manager.RetrieveById(id);
                return Ok(password);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
