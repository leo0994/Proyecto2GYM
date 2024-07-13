using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class ExerciseBaseManager
    {
        private readonly ExerciseBaseCrudFactory _crudFactory;

        public ExerciseBaseManager()
        {
            _crudFactory = new ExerciseBaseCrudFactory();
        }

        public ExerciseBaseDTO Create(ExerciseBaseDTO exerciseBase)
        {
            return _crudFactory.Create(exerciseBase);
        }

        public ExerciseBaseDTO Update(ExerciseBaseDTO exerciseBase)
        {
            return _crudFactory.Update(exerciseBase);
        }

        public ExerciseBaseDTO Delete(ExerciseBaseDTO exerciseBase)
        {
            return _crudFactory.Delete(exerciseBase);
        }

        public List<ExerciseBaseDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public ExerciseBaseDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
