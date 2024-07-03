using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryPasswordUserController : ControllerBase
    {
        private readonly HistoryPasswordUserManager _manager;

        public HistoryPasswordUserController()
        {
            _manager = new HistoryPasswordUserManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] HistoryPasswordUserDTO historyPasswordUser)
        {
            _manager.Create(historyPasswordUser);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] HistoryPasswordUserDTO historyPasswordUser)
        {
            _manager.Update(historyPasswordUser);
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
            var historyPasswordUser = _manager.RetrieveById(id);
            return Ok(historyPasswordUser);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var historyPasswordUsers = _manager.RetrieveAll();
            return Ok(historyPasswordUsers);
        }
    }
}
