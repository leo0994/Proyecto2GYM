using DTOs;
using DAO.Mapper;
using System;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class HistoryPasswordUserCrudFactory : CrudFactory
    {
        private readonly HistoryPasswordUserMapper _mapper;

        public HistoryPasswordUserCrudFactory()
        {
            _mapper = new HistoryPasswordUserMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var historyPasswordUser = (HistoryPasswordUserDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(historyPasswordUser);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var historyPasswordUser = (HistoryPasswordUserDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(historyPasswordUser);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var historyPasswordUser = (HistoryPasswordUserDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(historyPasswordUser.Id);
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

            var historyPasswordUser = _mapper.BuildObject(dic);
            return (T)Convert.ChangeType(historyPasswordUser, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var historyPasswordUsers = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var historyPasswordUser in historyPasswordUsers)
            {
                list.Add((T)Convert.ChangeType(historyPasswordUser, typeof(T)));
            }

            return list;
        }
    }
}
