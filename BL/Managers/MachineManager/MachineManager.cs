using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace Managers
{
    public class MachineManager : CrudFactory<MachineDTO>
    {
        private readonly MachineCrudFactory _crudFactory;

        public MachineManager()
        {
            _crudFactory = new MachineCrudFactory();
        }

        public override MachineDTO Create(MachineDTO entityDTO)
        {
            return _crudFactory.Create(entityDTO);
        }

        public override MachineDTO Update(MachineDTO entityDTO)
        {
            return _crudFactory.Update(entityDTO);
        }

        public override MachineDTO Delete(MachineDTO entityDTO)
        {
            return _crudFactory.Delete(entityDTO);
        }

        public override List<MachineDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public override MachineDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}