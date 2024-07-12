using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace Managers
{
    public class ExerciseManager : CrudFactory<ExerciseDTO>
    {
        private readonly ExerciseCrudFactory _exerciseCrudFactory;

        public ExerciseManager()
        {
            _exerciseCrudFactory = new ExerciseCrudFactory();
        }

        public override ExerciseDTO Create(ExerciseDTO entityDTO)
        {
            return _exerciseCrudFactory.Create(entityDTO);
        }

        public override ExerciseDTO Update(ExerciseDTO entityDTO)
        {
            return _exerciseCrudFactory.Update(entityDTO);
        }

        public override ExerciseDTO Delete(ExerciseDTO entityDTO)
        {
            return _exerciseCrudFactory.Delete(entityDTO);
        }

        public override List<ExerciseDTO> RetrieveAll()
        {
            return _exerciseCrudFactory.RetrieveAll();
        }

        public override ExerciseDTO RetrieveById(int id)
        {
            return _exerciseCrudFactory.RetrieveById(id);
        }
    }
}
