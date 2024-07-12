using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class RoutineCrudFactory : CrudFactory<RoutineDTO>
    {
        private readonly RoutineMapper _mapper;

        public RoutineCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new RoutineMapper();
        }

        public override RoutineDTO Create(RoutineDTO routine)
        {
            var sqlOperation = _mapper.GetCreateStatement(routine);
            dao.ExecuteProcedure(sqlOperation);
            return routine;
        }

        public override RoutineDTO Delete(RoutineDTO routine)
        {
            var sqlOperation = _mapper.GetDeleteStatement(routine.Id);
            dao.ExecuteProcedure(sqlOperation);
            return routine;
        }

        public override List<RoutineDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override RoutineDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override RoutineDTO Update(RoutineDTO routine)
        {
            var sqlOperation = _mapper.GetUpdateStatement(routine);
            dao.ExecuteProcedure(sqlOperation);
            return routine;
        }
    }
}
