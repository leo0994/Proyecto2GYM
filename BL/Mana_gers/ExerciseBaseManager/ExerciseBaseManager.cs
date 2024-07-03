using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Mana_gers
{
    public class ExerciseBaseManager
    {
        private readonly ExerciseBaseCrudFactory _crudFactory;

        public ExerciseBaseManager()
        {
            _crudFactory = new ExerciseBaseCrudFactory();
        }

        public void Create(ExerciseBaseDTO exerciseBase)
        {
            _crudFactory.Create(exerciseBase);
        }

        public void Update(ExerciseBaseDTO exerciseBase)
        {
            _crudFactory.Update(exerciseBase);
        }

        public void Delete(int id)
        {
            var exerciseBase = new ExerciseBaseDTO { Id = id };
            _crudFactory.Delete(exerciseBase);
        }

        public ExerciseBaseDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<ExerciseBaseDTO>(id);
        }

        public List<ExerciseBaseDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<ExerciseBaseDTO>();
        }
    }
}
