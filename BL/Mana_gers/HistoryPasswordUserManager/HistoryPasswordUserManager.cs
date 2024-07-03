using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Mana_gers
{
    public class HistoryPasswordUserManager
    {
        private readonly HistoryPasswordUserCrudFactory _crudFactory;

        public HistoryPasswordUserManager()
        {
            _crudFactory = new HistoryPasswordUserCrudFactory();
        }

        public void Create(HistoryPasswordUserDTO historyPasswordUser)
        {
            _crudFactory.Create(historyPasswordUser);
        }

        public void Update(HistoryPasswordUserDTO historyPasswordUser)
        {
            _crudFactory.Update(historyPasswordUser);
        }

        public void Delete(int id)
        {
            var historyPasswordUser = new HistoryPasswordUserDTO { Id = id };
            _crudFactory.Delete(historyPasswordUser);
        }

        public HistoryPasswordUserDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<HistoryPasswordUserDTO>(id);
        }

        public List<HistoryPasswordUserDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<HistoryPasswordUserDTO>();
        }
    }
}
