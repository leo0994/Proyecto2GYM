using DTOs;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class RoutineCrudFactory : CrudFactory
    {
        private readonly RoutineMapper _mapper;

        public RoutineCrudFactory()
        {
            _mapper = new RoutineMapper();
            dao = SqlDAO.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var routine = (RoutineDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(routine);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var routine = (RoutineDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(routine);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var routine = (RoutineDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(routine.Id);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
            }

            var routine = _mapper.BuildObject(dic);
            return (T)System.Convert.ChangeType(routine, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var routines = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var routine in routines)
            {
                list.Add((T)System.Convert.ChangeType(routine, typeof(T)));
            }

            return list;
        }
    }
}
