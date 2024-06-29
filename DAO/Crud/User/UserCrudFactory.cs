using DAO;
using DAO.Crud;
// using DAO.Mapper;
using DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Crud.User
{
    public class UserCrudFactory : CrudFactory<UserEntity>
    {
        // private ArticleMapper mapper;

        public UserCrudFactory()
        {
            // mapper = new ArticleMapper();
            dao = SqlDao.GetInstance();
        }

        public override UserEntity Create(UserEntity entityDTO)
        {
            // SqlOperation operation = mapper.GetCreateStatement(entityDTO);
            // dao.ExecuteStoredProcedure(operation);
            entityDTO.Id = 092983;
            return entityDTO;
        }

        public override UserEntity Delete(UserEntity entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<UserEntity> RetrieveAll()
        {
            List<UserEntity> lstResults = new List<UserEntity>();
            // List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveAllStatement());

            // if (dataResults.Count > 0)
            // {
            //     var dtoObjects = mapper.BuildObjects(dataResults);

            //     foreach (var ob in dtoObjects)
            //     {
            //         lstResults.Add((T)Convert.ChangeType(ob, typeof(T)));
            //     }
            // }
            return lstResults;
        }

        public override UserEntity RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public override UserEntity Update(UserEntity entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
