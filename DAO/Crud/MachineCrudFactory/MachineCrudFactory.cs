using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class MachineCrudFactory : CrudFactory<MachineDTO>
    {
        private readonly MachineMapper _mapper;
        private readonly SqlDAO _dao;

        public MachineCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new MachineMapper();
        }

        public override MachineDTO Create(MachineDTO entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override MachineDTO Delete(MachineDTO entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO.Id);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override List<MachineDTO> RetrieveAll()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _dao.ExecuteQueryProcedure(operation);
            return _mapper.BuildObjects(results);
        }

        public override MachineDTO RetrieveById(int id)
        {
            var operation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(operation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override MachineDTO Update(MachineDTO entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }
    }
}
