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

    public class TypeUserController : ControllerBase
    {
        private readonly TypeUserManager _typeUserManager;

        public TypeUserController()
        {
            _typeUserManager = new TypeUserManager();
        }

        [HttpPost]
        public IActionResult Create(TypeUserDTO typeUserDTO)
        {
            var result = _typeUserManager.Create(typeUserDTO);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _typeUserManager.RetrieveAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _typeUserManager.RetrieveById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(TypeUserDTO typeUserDTO)
        {
            var result = _typeUserManager.Update(typeUserDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var typeUserDTO = new TypeUserDTO { Id = id };
            var result = _typeUserManager.Delete(typeUserDTO);
            return Ok(result);
        }
    }
}
