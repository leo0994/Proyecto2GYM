using BL.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionManager _manager;

        public SubscriptionController()
        {
            _manager = new SubscriptionManager();
        }

        [HttpGet("RetrieveAll")]
        public IActionResult RetrieveAll()
        {
            try
            {
                var response = _manager.RetrieveAll();
                return Ok(ResponseHelper.Success<List<SubscriptionDTO>>(response, "Getting all subscriptions"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }

        /*[HttpGet("{id}")]
        public IActionResult GetSubscriptionById(int id)
        {
            try
            {
                var result = _manager.RetrieveById(id);
                var subscription = ExecuteSqlOperation(result);

                if (subscription == null)
                {
                    return NotFound();
                }

                return Ok(subscription);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateSubscription([FromBody] SubscriptionDTO subscription)
        {
            try
            {
                var result = _subscriptionMapper.GetCreateStatement(subscription);
                ExecuteSqlOperation(result);

                return CreatedAtAction(nameof(GetSubscriptionById), new { id = subscription.name }, subscription);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubscription(int id, [FromBody] SubscriptionDTO subscription)
        {
            try
            {
                subscription.name = id;
                var result = _subscriptionMapper.GetUpdateStatement(subscription);
                ExecuteSqlOperation(result);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscription(int id)
        {
            try
            {
                var result = _subscriptionMapper.GetDeleteStatement(id);
                ExecuteSqlOperation(result);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Método de ejemplo para ejecutar SqlOperation y obtener los resultados
        private List<SubscriptionDTO> ExecuteSqlOperation(SqlOperation sqlOperation)
        {
            // Aquí iría la lógica para ejecutar la operación SQL y mapear los resultados
            return new List<SubscriptionDTO>();
        }*/
    }
}
