using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly PaymentMethodManager _manager;

        public PaymentMethodController()
        {
            _manager = new PaymentMethodManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] PaymentMethodDTO paymentMethod)
        {
            _manager.Create(paymentMethod);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] PaymentMethodDTO paymentMethod)
        {
            _manager.Update(paymentMethod);
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
            var paymentMethod = _manager.RetrieveById(id);
            return Ok(paymentMethod);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var paymentMethods = _manager.RetrieveAll();
            return Ok(paymentMethods);
        }
    }
}
