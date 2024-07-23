using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class ExerciseRoutineCrudFactory : CrudFactory<ExerciseRoutineDTO>
    {
        private readonly SqlDAO _dao;
        private readonly ExerciseRoutineMapper _mapper;

        public ExerciseRoutineCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new ExerciseRoutineMapper();
        }

        public override ExerciseRoutineDTO Create(ExerciseRoutineDTO entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override ExerciseRoutineDTO Update(ExerciseRoutineDTO entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override ExerciseRoutineDTO Delete(ExerciseRoutineDTO entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO.Id);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override List<ExerciseRoutineDTO> RetrieveAll()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _dao.ExecuteQueryProcedure(operation);
            return _mapper.BuildObjects(results);
        }

        public override ExerciseRoutineDTO RetrieveById(int id)
        {
            var operation = _mapper.GetRetrieveByIdStatement(id);
            var results = _dao.ExecuteQueryProcedure(operation);
            if (results.Count > 0)
            {
                return _mapper.BuildObject(results[0]);
            }
            return null;
        }
    }
}
