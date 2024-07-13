using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class HistoryPasswordUserManager
    {
        private readonly HistoryPasswordUserCrudFactory _crudFactory;

        public HistoryPasswordUserManager()
        {
            _crudFactory = new HistoryPasswordUserCrudFactory();
        }

        public HistoryPasswordUserDTO Create(HistoryPasswordUserDTO historyPasswordUser)
        {
            return _crudFactory.Create(historyPasswordUser);
        }

        public HistoryPasswordUserDTO Update(HistoryPasswordUserDTO historyPasswordUser)
        {
            return _crudFactory.Update(historyPasswordUser);
        }

        public HistoryPasswordUserDTO Delete(HistoryPasswordUserDTO historyPasswordUser)
        {
            return _crudFactory.Delete(historyPasswordUser);
        }

        public List<HistoryPasswordUserDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public HistoryPasswordUserDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
