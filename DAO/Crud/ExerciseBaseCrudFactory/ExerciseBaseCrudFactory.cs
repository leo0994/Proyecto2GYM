using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class ExerciseBaseCrudFactory : CrudFactory<ExerciseBaseDTO>
    {
        private readonly ExerciseBaseMapper _mapper;

        public ExerciseBaseCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new ExerciseBaseMapper();
        }

        public override ExerciseBaseDTO Create(ExerciseBaseDTO exerciseBase)
        {
            var sqlOperation = _mapper.GetCreateStatement(exerciseBase);
            dao.ExecuteProcedure(sqlOperation);
            return exerciseBase;
        }

        public override ExerciseBaseDTO Delete(ExerciseBaseDTO exerciseBase)
        {
            var sqlOperation = _mapper.GetDeleteStatement(exerciseBase.Id);
            dao.ExecuteProcedure(sqlOperation);
            return exerciseBase;
        }

        public override List<ExerciseBaseDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override ExerciseBaseDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override ExerciseBaseDTO Update(ExerciseBaseDTO exerciseBase)
        {
            var sqlOperation = _mapper.GetUpdateStatement(exerciseBase);
            dao.ExecuteProcedure(sqlOperation);
            return exerciseBase;
        }
    }
}
