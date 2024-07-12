using DTOs;
using DAO;
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
