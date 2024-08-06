using DTOs;
using Microsoft.AspNetCore.Mvc;
using BL.Managers;
using System;
using System.Collections.Generic;
using DTO.ResponseDTO;

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

        [HttpPost("Create")] // Modificado por MARIA 
        public IActionResult Create([FromBody] PaymentDTO payment)
        {
            try
            {
                int createdPaymentId = Int32.Parse(_manager.Create(payment)); // response del manager
                var responseDTO = new ResponseDTO //  dto response 
                {
                    codeResponse = "0",
                    messageResponse = "Payment registered correctly",
                    dataResponse = createdPaymentId.ToString()
                };

                return Ok(responseDTO);
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

        [HttpDelete("Delete")] //  Modificado por Maria
        public IActionResult Delete(int id) //  Modificado por Maria - No tenia el id para delete y Estaba linkeado a invoice, entonces se modifico la base de datos para que elimianra en cascade
        {
            try
            {
                var PaymentDTO = new PaymentDTO { Id = id };
                var deletedPayment = _manager.Delete(PaymentDTO);
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
