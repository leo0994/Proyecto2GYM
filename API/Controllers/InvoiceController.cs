using DTOs;
using BL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceManager _manager;

        public InvoiceController()
        {
            _manager = new InvoiceManager();
        }

        [HttpPost]
        public IActionResult Create([FromBody] InvoiceDTO invoice)
        {
            _manager.Create(invoice);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] InvoiceDTO invoice)
        {
            _manager.Update(invoice);
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
            var invoice = _manager.RetrieveById(id);
            return Ok(invoice);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var invoices = _manager.RetrieveAll();
            return Ok(invoices);
        }
    }
}
