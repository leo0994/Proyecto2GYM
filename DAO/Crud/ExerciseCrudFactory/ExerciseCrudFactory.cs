using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class ExerciseCrudFactory : CrudFactory<ExerciseDTO>
    {
        private readonly SqlDAO _dao;
        private readonly ExerciseMapper _mapper;

        public ExerciseCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new ExerciseMapper();
        }

        public override ExerciseDTO Create(ExerciseDTO entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override ExerciseDTO Update(ExerciseDTO entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override ExerciseDTO Delete(ExerciseDTO entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO.Id);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override List<ExerciseDTO> RetrieveAll()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _dao.ExecuteQueryProcedure(operation);
            return _mapper.BuildObjects(results);
        }

        public override ExerciseDTO RetrieveById(int id)
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
