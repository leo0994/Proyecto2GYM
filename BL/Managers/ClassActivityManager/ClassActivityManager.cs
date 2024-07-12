using DTOs;
<<<<<<< HEAD
using DAO.Crud;
using System;
=======
using DAO;
>>>>>>> d2c19281475524053010af6b91c4e29ab8621293
using System.Collections.Generic;
using DAO.Crud;

namespace Managers
{
    public class ClassActivityManager
    {
        private readonly ClassActivityCrudFactory _crudFactory;

        public ClassActivityManager()
        {
            _crudFactory = new ClassActivityCrudFactory();
        }

        public void Create(ClassActivityDTO classActivity)
        {
            _crudFactory.Create(classActivity);
        }

        public void Update(ClassActivityDTO classActivity)
        {
            _crudFactory.Update(classActivity);
        }

        public void Delete(int id)
        {
            _crudFactory.Delete(id);
        }

        public List<ClassActivityDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public ClassActivityDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
