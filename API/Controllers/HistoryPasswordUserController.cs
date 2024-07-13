using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryPasswordUserController : ControllerBase
    {
        private readonly HistoryPasswordUserManager _manager;

        public HistoryPasswordUserController()
        {
            _manager = new HistoryPasswordUserManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] HistoryPasswordUserDTO historyPasswordUser)
        {
            try
            {
                var createdHistoryPasswordUser = _manager.Create(historyPasswordUser);
                return Ok(createdHistoryPasswordUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] HistoryPasswordUserDTO historyPasswordUser)
        {
            try
            {
                var updatedHistoryPasswordUser = _manager.Update(historyPasswordUser);
                return Ok(updatedHistoryPasswordUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] HistoryPasswordUserDTO historyPasswordUser)
        {
            try
            {
                var deletedHistoryPasswordUser = _manager.Delete(historyPasswordUser);
                return Ok(deletedHistoryPasswordUser);
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
                var historyPasswordUsers = _manager.RetrieveAll();
                return Ok(historyPasswordUsers);
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
                var historyPasswordUser = _manager.RetrieveById(id);
                return Ok(historyPasswordUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
