using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class HistoryEnrollmentManager
    {
        private readonly HistoryEnrollmentCrudFactory _crudFactory;

        public HistoryEnrollmentManager()
        {
            _crudFactory = new HistoryEnrollmentCrudFactory();
        }

        public void Create(HistoryEnrollmentDTO historyEnrollment)
        {
            _crudFactory.Create(historyEnrollment);
        }

        public void Update(HistoryEnrollmentDTO historyEnrollment)
        {
            _crudFactory.Update(historyEnrollment);
        }

        public void Delete(int id)
        {
            var historyEnrollment = new HistoryEnrollmentDTO { Id = id };
            _crudFactory.Delete(historyEnrollment);
        }

        public HistoryEnrollmentDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<HistoryEnrollmentDTO>(id);
        }

        public List<HistoryEnrollmentDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<HistoryEnrollmentDTO>();
        }
    }
}
