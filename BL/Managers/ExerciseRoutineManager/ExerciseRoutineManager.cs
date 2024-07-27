using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace Managers
{
    public class ExerciseRoutineManager : CrudFactory<ExerciseRoutineDTO>
    {
        private readonly ExerciseRoutineCrudFactory _exerciseRoutineCrudFactory;

        public ExerciseRoutineManager()
        {
            _exerciseRoutineCrudFactory = new ExerciseRoutineCrudFactory();
        }

        public override ExerciseRoutineDTO Create(ExerciseRoutineDTO entityDTO)
        {
            return _exerciseRoutineCrudFactory.Create(entityDTO);
        }

        public override ExerciseRoutineDTO Update(ExerciseRoutineDTO entityDTO)
        {
            return _exerciseRoutineCrudFactory.Update(entityDTO);
        }

        public override ExerciseRoutineDTO Delete(ExerciseRoutineDTO entityDTO)
        {
            return _exerciseRoutineCrudFactory.Delete(entityDTO);
        }

        public override List<ExerciseRoutineDTO> RetrieveAll()
        {
            return _exerciseRoutineCrudFactory.RetrieveAll();
        }

        public override ExerciseRoutineDTO RetrieveById(int id)
        {
            return _exerciseRoutineCrudFactory.RetrieveById(id);
        }
    }
}