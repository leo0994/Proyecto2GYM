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

        public void Create(RoutineDTO routine)
        {
            _crudFactory.Create(routine);
        }

        public void Update(RoutineDTO routine)
        {
            _crudFactory.Update(routine);
        }

        public void Delete(int id)
        {
            var routine = new RoutineDTO { Id = id };
            _crudFactory.Delete(routine);
        }

        public RoutineDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<RoutineDTO>(id);
        }

        public List<RoutineDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<RoutineDTO>();
        }
    }
}
