using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO
{
    public class UserCrudFactory
    {
        private readonly SqlDAO _dao;
        private readonly UserMapper _mapper;

        public UserCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new UserMapper();
        }

        public void Create(UserDTO user)
        {
            var sqlOperation = _mapper.GetCreateStatement(user);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public UserDTO RetrieveByCredentials(UserDTO user)
        {
            var sqlOperation = _mapper.RetrieveByCredentialsStatement(user);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                Console.WriteLine(result.Count);
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public UserDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }

            return null;
        }

        public List<UserDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<UserDTO>();
        }

        public void Update(UserDTO user)
        {
            var sqlOperation = _mapper.GetUpdateStatement(user);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void Delete(int id)
        {
            var sqlOperation = _mapper.GetDeleteStatement(id);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public UserDTO RetrieveByEmail(UserDTO user){
            var sqlOperation = _mapper.RetrieveByEmailtStatement(user);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }

            return null;
        }

        public void UpdatePassword(UserDTO user){
            var sqlOperation = _mapper.UpdatePasswordStatement(user);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public int VerifyUserPassword(UserDTO user){
            var sqlOperation = _mapper.VerifyUserPasswordStatement(user);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);
            return (int)result[0]["IsPasswordValid"];
        }
    }
}
