using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class RoutineManager
    {
        private readonly RoutineCrudFactory _crudFactory;

        public RoutineManager()
        {
            _crudFactory = new RoutineCrudFactory();
        }

        public RoutineDTO Create(RoutineDTO routine)
        {
            return _crudFactory.Create(routine);
        }

        public RoutineDTO Update(RoutineDTO routine)
        {
            return _crudFactory.Update(routine);
        }

        public RoutineDTO Delete(RoutineDTO routine)
        {
            return _crudFactory.Delete(routine);
        }

        public List<RoutineDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public RoutineDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
