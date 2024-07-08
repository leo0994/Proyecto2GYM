using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.User;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;

        public UserController()
        {
            _userManager = new UserManager();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(UserDTO user)
        {
            try
            {
                _userManager.Create(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [Route("CreateAdm")]
        public async Task<IActionResult> CreateAdm(UserDTO user)
        {
            try
            {
                _userManager.CreateAdm(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(UserDTO user)
        {
            try
            {
                _userManager.Update(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        [Route("UpdateAdm")]
        public async Task<IActionResult> UpdateAdm(UserDTO user)
        {
            try
            {
                _userManager.Update(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _userManager.Delete(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            try
            {
                var users = _userManager.RetrieveAll();
                return Ok(users);
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
                var user = _userManager.RetrieveById(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByEmail")]
        public async Task<IActionResult> RetrieveByEmail(UserDTO email)
        {
            try
            {
                var user = _userManager.RetrieveByEmail(email);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(string email)
        {
            try
            {
                //_userManager.UpdatePassword(email);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Authorize(Policy = "Administrator")] // in use...!!
        [Route("testing-admin-policy")]
        public async Task<IActionResult> Testing()
        {
            return Ok("testing Administrator policy");
        }
    }
}
