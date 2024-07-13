using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class EnrollmentManager
    {
        private readonly EnrollmentCrudFactory _crudFactory;

        public EnrollmentManager()
        {
            _crudFactory = new EnrollmentCrudFactory();
        }

        public EnrollmentDTO Create(EnrollmentDTO enrollment)
        {
            return _crudFactory.Create(enrollment);
        }

        public EnrollmentDTO Update(EnrollmentDTO enrollment)
        {
            return _crudFactory.Update(enrollment);
        }

        public EnrollmentDTO Delete(EnrollmentDTO enrollment)
        {
            return _crudFactory.Delete(enrollment);
        }

        public List<EnrollmentDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public EnrollmentDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
