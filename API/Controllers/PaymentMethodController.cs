using DTOs;
using Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly PaymentMethodManager _manager;

        public PaymentMethodController()
        {
            _manager = new PaymentMethodManager();
        }

        [HttpPost]
        public IActionResult Create(PaymentMethodDTO paymentMethod)
        {
            _manager.Create(paymentMethod);
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
        public IActionResult Update(PaymentMethodDTO paymentMethod)
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
    }
}
