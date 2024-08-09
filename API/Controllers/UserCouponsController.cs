using BL.Managers.UserCouponsManager;
using DTO.UserCouponsDTO;
using DTOs;
using Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class UserCouponsController : ControllerBase
    {
        private readonly UserCouponsManager _UserCouponsManager;

        public UserCouponsController()
        {
            _UserCouponsManager = new UserCouponsManager();
        }

        [HttpPost]
        public IActionResult Create(UserCouponsDTO userCouponsDTO)
        {
            var result = _UserCouponsManager.Create(userCouponsDTO);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _UserCouponsManager.RetrieveAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _UserCouponsManager.RetrieveById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(UserCouponsDTO userCouponsDTO)
        {
            var result = _UserCouponsManager.Update(userCouponsDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var UserCouponsDTO = new UserCouponsDTO { Id = id };
            var result = _UserCouponsManager.Delete(UserCouponsDTO);
            return Ok(result);
        }
    }
}
