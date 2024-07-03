using System.Collections.Generic;
using DTOs;
using DAO.Crud;

namespace BL.Mana_ger
{
    public class ExerciseManager
    {
        private readonly ExerciseCrudFactory _crudFactory;

        public ExerciseManager()
        {
            _crudFactory = new ExerciseCrudFactory();
        }

        public void CreateExercise(ExerciseDTO exercise)
        {
            _crudFactory.Create(exercise);
        }

        public void UpdateExercise(ExerciseDTO exercise)
        {
            _crudFactory.Update(exercise);
        }

        public void DeleteExercise(int exerciseId)
        {
            var exercise = new ExerciseDTO { Id = exerciseId };
            _crudFactory.Delete(exercise);
        }

        public ExerciseDTO GetExerciseById(int exerciseId)
        {
            return _crudFactory.Retrieve<ExerciseDTO>(exerciseId);
        }

        public List<ExerciseDTO> GetAllExercises()
        {
            return _crudFactory.RetrieveAll<ExerciseDTO>();
        }
    }
}
