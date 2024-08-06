using BL.Managers.CouponsManager;
using DTOs;
using Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class CouponsController : ControllerBase
    {
        private readonly CouponsManager _CouponsManager;

        public CouponsController()
        {
            _CouponsManager = new CouponsManager();
        }

        [HttpPost]
        public IActionResult Create(CouponsDTO couponsDTO)
        {
            var result = _CouponsManager.Create(couponsDTO);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _CouponsManager.RetrieveAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _CouponsManager.RetrieveById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(CouponsDTO couponsDTO)
        {
            var result = _CouponsManager.Update(couponsDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var couponsDTO = new CouponsDTO { Id = id };
            var result = _CouponsManager.Delete(couponsDTO);
            return Ok(result);
        }
    }
}

