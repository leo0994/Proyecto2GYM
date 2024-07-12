using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentManager _manager;

        public PaymentController()
        {
            _manager = new PaymentManager();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] PaymentDTO payment)
        {
            try
            {
                var createdPayment = _manager.Create(payment);
                return Ok(createdPayment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] PaymentDTO payment)
        {
            try
            {
                var updatedPayment = _manager.Update(payment);
                return Ok(updatedPayment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] PaymentDTO payment)
        {
            try
            {
                var deletedPayment = _manager.Delete(payment);
                return Ok(deletedPayment);
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
                var payments = _manager.RetrieveAll();
                return Ok(payments);
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
                var payment = _manager.RetrieveById(id);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
