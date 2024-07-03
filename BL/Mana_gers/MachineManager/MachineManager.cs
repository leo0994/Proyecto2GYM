using DAO.Crud;
using DTOs;
using System.Collections.Generic;

namespace BL.Mana_gers
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
            _crudFactory.Delete(id);
        }

        public MachineDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }

        public List<MachineDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }
    }
}
