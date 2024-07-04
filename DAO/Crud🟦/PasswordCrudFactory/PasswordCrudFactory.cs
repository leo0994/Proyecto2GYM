using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class PasswordCrudFactory : CrudFactory
    {
        private readonly PasswordMapper _mapper;

        public PasswordCrudFactory()
        {
            _mapper = new PasswordMapper();
            dao = SqlDAO.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var password = (PasswordDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(password);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var password = (PasswordDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(password);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var password = (PasswordDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(password.Id);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
            }

            var password = _mapper.BuildObject(dic);
            return (T)System.Convert.ChangeType(password, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var passwords = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var password in passwords)
            {
                list.Add((T)System.Convert.ChangeType(password, typeof(T)));
            }

            return list;
        }
    }
}
