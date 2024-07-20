using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class PasswordCrudFactory : CrudFactory<PasswordDTO>
    {
        private readonly PasswordMapper _mapper;

        public PasswordCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new PasswordMapper();
        }

        public override PasswordDTO Create(PasswordDTO password)
        {
            var sqlOperation = _mapper.GetCreateStatement(password);
            dao.ExecuteProcedure(sqlOperation);
            return password;
        }

        public override PasswordDTO Delete(PasswordDTO password)
        {
            var sqlOperation = _mapper.GetDeleteStatement(password.Id);
            dao.ExecuteProcedure(sqlOperation);
            return password;
        }

        public override List<PasswordDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override PasswordDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override PasswordDTO Update(PasswordDTO password)
        {
            var sqlOperation = _mapper.GetUpdateStatement(password);
            dao.ExecuteProcedure(sqlOperation);
            return password;
        }
    }
}
