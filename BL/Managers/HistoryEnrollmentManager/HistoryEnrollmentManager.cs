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

        public HistoryEnrollmentDTO Create(HistoryEnrollmentDTO historyEnrollment)
        {
            return _crudFactory.Create(historyEnrollment);
        }

        public HistoryEnrollmentDTO Update(HistoryEnrollmentDTO historyEnrollment)
        {
            return _crudFactory.Update(historyEnrollment);
        }

        public HistoryEnrollmentDTO Delete(HistoryEnrollmentDTO historyEnrollment)
        {
            return _crudFactory.Delete(historyEnrollment);
        }

        public List<HistoryEnrollmentDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public HistoryEnrollmentDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
