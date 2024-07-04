using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentManager _manager;

        public PaymentController()
        {
            _manager = new PaymentManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] PaymentDTO payment)
        {
            _manager.Create(payment);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] PaymentDTO payment)
        {
            _manager.Update(payment);
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
            var payment = _manager.RetrieveById(id);
            return Ok(payment);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var payments = _manager.RetrieveAll();
            return Ok(payments);
        }
    }
}
