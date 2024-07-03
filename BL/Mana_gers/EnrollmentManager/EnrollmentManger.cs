using DTOs;
using DAO.Crud;
using System;
using System.Collections.Generic;

namespace Mana_gers.Management
{
    public class EnrollmentManager
    {
        private readonly EnrollmentCrudFactory _crudFactory;

        public EnrollmentManager()
        {
            _crudFactory = new EnrollmentCrudFactory();
        }

        public void Create(EnrollmentDTO enrollment)
        {
            if (enrollment.Amount <= 0)
            {
                throw new ArgumentException("The amount must be greater than zero.");
            }
            _crudFactory.Create(enrollment);
        }

        public EnrollmentDTO RetrieveById(int id)
        {
            var enrollment = _crudFactory.RetrieveById(id);
            if (enrollment == null)
            {
                throw new KeyNotFoundException($"Enrollment with id {id} not found.");
            }
            return enrollment;
        }

        public List<EnrollmentDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public void Delete(int id)
        {
            var enrollment = RetrieveById(id); // This will throw if the enrollment does not exist
            _crudFactory.Delete(id);
        }
    }
}
