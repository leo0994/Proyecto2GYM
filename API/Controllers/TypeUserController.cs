using BL;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeUserController : ControllerBase
    {
        private readonly TypeUserManager _typeUserManager;

        public TypeUserController()
        {
            _typeUserManager = new TypeUserManager();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(TypeUserDTO typeUser)
        {
            try
            {
                _typeUserManager.Create(typeUser);
                return Ok(typeUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            try
            {
                var typeUser = _typeUserManager.RetrieveById(id);
                return Ok(typeUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            try
            {
                var typeUsers = _typeUserManager.RetrieveAll();
                return Ok(typeUsers);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(TypeUserDTO typeUser)
        {
            try
            {
                _typeUserManager.Update(typeUser);
                return Ok(typeUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _typeUserManager.Delete(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
