using DTOs;
using DAO.Crud;
using System;
using System.Collections.Generic;

namespace BL.ClassActivity
{
    public class ClassActivityManager
    {
        private readonly ClassActivityCrudFactory _classActivityCrudFactory;

        public ClassActivityManager()
        {
            _classActivityCrudFactory = new ClassActivityCrudFactory();
        }

        public void Create(ClassActivityDTO classActivity)
        {
            _classActivityCrudFactory.Create(classActivity);
        }

        public void Update(ClassActivityDTO classActivity)
        {
            _classActivityCrudFactory.Update(classActivity);
        }

        public void Delete(int id)
        {
            _classActivityCrudFactory.Delete(id);
        }

        public List<ClassActivityDTO> RetrieveAll()
        {
            return _classActivityCrudFactory.RetrieveAll();
        }

        public ClassActivityDTO RetrieveById(int id)
        {
            return _classActivityCrudFactory.RetrieveById(id);
        }
    }
}
