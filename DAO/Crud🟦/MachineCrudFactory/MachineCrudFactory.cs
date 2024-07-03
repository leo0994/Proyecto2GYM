using DAO.Mapper;
using DTOs;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class MachineCrudFactory : ICrudFactory<MachineDTO>
    {
        private readonly SqlDAO _dao;
        private readonly MachineMapper _mapper;

        public MachineCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new MachineMapper();
        }

        public MachineDTO BuildObject(Dictionary<string, object> row)
        {
            return _mapper.BuildObject(row);
        }

        public List<MachineDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            return _mapper.BuildObjects(rowsList);
        }

        public void Create(MachineDTO machine)
        {
            var sqlOperation = _mapper.GetCreateStatement(machine);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void Update(MachineDTO machine)
        {
            var sqlOperation = _mapper.GetUpdateStatement(machine);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void Delete(int id)
        {
            var sqlOperation = _mapper.GetDeleteStatement(id);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public MachineDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }

            return null;
        }

        public List<MachineDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<MachineDTO>();
        }
    }
}
