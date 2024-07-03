using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class MeasureCrudFactory : CrudFactory
    {
        private readonly MeasureMapper _mapper;

        public MeasureCrudFactory()
        {
            _mapper = new MeasureMapper();
            dao = SqlDAO.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var measure = (MeasureDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(measure);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var measure = (MeasureDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(measure);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var measure = (MeasureDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(measure.Id);
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

            var measure = _mapper.BuildObject(dic);
            return (T)Convert.ChangeType(measure, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var measures = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var measure in measures)
            {
                list.Add((T)Convert.ChangeType(measure, typeof(T)));
            }

            return list;
        }
    }
}
