using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class HistoryPasswordUserCrudFactory : CrudFactory<HistoryPasswordUserDTO>
    {
        private readonly HistoryPasswordUserMapper _mapper;

        public HistoryPasswordUserCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new HistoryPasswordUserMapper();
        }

        public override HistoryPasswordUserDTO Create(HistoryPasswordUserDTO historyPasswordUser)
        {
            var sqlOperation = _mapper.GetCreateStatement(historyPasswordUser);
            dao.ExecuteProcedure(sqlOperation);
            return historyPasswordUser;
        }

        public override HistoryPasswordUserDTO Delete(HistoryPasswordUserDTO historyPasswordUser)
        {
            var sqlOperation = _mapper.GetDeleteStatement(historyPasswordUser.Id);
            dao.ExecuteProcedure(sqlOperation);
            return historyPasswordUser;
        }

        public override List<HistoryPasswordUserDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override HistoryPasswordUserDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override HistoryPasswordUserDTO Update(HistoryPasswordUserDTO historyPasswordUser)
        {
            var sqlOperation = _mapper.GetUpdateStatement(historyPasswordUser);
            dao.ExecuteProcedure(sqlOperation);
            return historyPasswordUser;
        }
    }
}
