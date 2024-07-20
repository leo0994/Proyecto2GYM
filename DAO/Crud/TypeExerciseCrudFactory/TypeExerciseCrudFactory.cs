using DTOs;
using DAO.Mapper;
using DAO.Mapper.TypeExerciseMapper;

using DTO.TypeExcercise;


namespace DAO.Crud
{
    public class TypeExerciseCrudFactory : CrudFactory<TypeExerciseDTO>
    {
        private readonly SqlDAO _dao;
            private readonly TypeExerciseMapper _mapper;

            public TypeExerciseCrudFactory()
            {
                _dao = SqlDAO.GetInstance();
                _mapper = new TypeExerciseMapper();
            }

            public override TypeExerciseDTO Create(TypeExerciseDTO entityDTO)
            {
                var operation = _mapper.GetCreateStatement(entityDTO);
                _dao.ExecuteProcedure(operation);
                return entityDTO;
            }

            public override TypeExerciseDTO Update(TypeExerciseDTO entityDTO)
            {
                var operation = _mapper.GetUpdateStatement(entityDTO);
                _dao.ExecuteProcedure(operation);
                return entityDTO;
            }

            public override TypeExerciseDTO Delete(TypeExerciseDTO entityDTO)
            {
                var operation = _mapper.GetDeleteStatement(entityDTO.Id);
                _dao.ExecuteProcedure(operation);
                return entityDTO;
            }

            public override List<TypeExerciseDTO> RetrieveAll()
            {
                var operation = _mapper.GetRetrieveAllStatement();
                var results = _dao.ExecuteQueryProcedure(operation);
                return _mapper.BuildObjects(results);
            }

            public override TypeExerciseDTO RetrieveById(int id)
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