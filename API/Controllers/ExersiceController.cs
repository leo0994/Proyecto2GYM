using System.Collections.Generic;
using System.Web.Http;
using BL.Mana_ger;
using DTOs;

namespace API.Controllers
{
    [RoutePrefix("api/exercises")]
    public class ExerciseController : ApiController
    {
        private readonly ExerciseManager _exerciseManager;

        public ExerciseController()
        {
            _exerciseManager = new ExerciseManager();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateExercise([FromBody] ExerciseDTO exercise)
        {
            _exerciseManager.CreateExercise(exercise);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateExercise([FromBody] ExerciseDTO exercise)
        {
            _exerciseManager.UpdateExercise(exercise);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult DeleteExercise(int id)
        {
            _exerciseManager.DeleteExercise(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetExerciseById(int id)
        {
            var exercise = _exerciseManager.GetExerciseById(id);
            return Ok(exercise);
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllExercises()
        {
            var exercises = _exerciseManager.GetAllExercises();
            return Ok(exercises);
        }
    }
}
