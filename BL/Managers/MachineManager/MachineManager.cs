using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace Managers
{
    public class MachineManager
    {
        private readonly MachineCrudFactory _crudFactory;

        public MachineManager()
        {
            _crudFactory = new MachineCrudFactory();
        }

        public void Create(MachineDTO machine)
        {
            _crudFactory.Create(machine);
        }

        public void Update(MachineDTO machine)
        {
            _crudFactory.Update(machine);
        }

        public void Delete(int id)
        {
            var machine = new MachineDTO { Id = id };
            _crudFactory.Delete(machine);
        }

        public List<MachineDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public MachineDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
