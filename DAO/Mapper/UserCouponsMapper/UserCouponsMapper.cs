using DTO.UserCouponsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mapper.UserCouponsMapper
{
    public class UserCouponsMapper : ICrudStatements<UserCouponsDTO>, IObjectMapper<UserCouponsDTO>
    {
        public UserCouponsDTO BuildObject(Dictionary<string, object> row)
        {
            return new UserCouponsDTO
            {
                Id = (int)row["Id"],
                IdCoupons = (int)row["IdCoupons"],
                IdUser = (int)row["IdUser"],
                ApplicationDate = (DateTime)row["ApplicationDate"],
            };
        }

        public List<UserCouponsDTO> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<UserCouponsDTO>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetCreateStatement(UserCouponsDTO usercoupons) // create
        {
            var operation = new SqlOperation { ProcedureName = "CreateUserCoupons" };
            operation.AddIntParam("@IdCoupons", usercoupons.IdCoupons);
            operation.AddIntParam("@IdUser", usercoupons.IdUser);
            operation.AddDateTimeParam("@ApplicationDate", usercoupons.ApplicationDate);


            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id) // return by ID
        {
            var operation = new SqlOperation { ProcedureName = "GetUserCouponsById" };
            operation.AddIntParam("@Id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(UserCouponsDTO Usercoupons) // Update
        {
            var operation = new SqlOperation { ProcedureName = "UpdateUserCoupons" };

            operation.AddIntParam("@Id", Usercoupons.Id);
            operation.AddIntParam("@IdCoupons", Usercoupons.IdCoupons);
            operation.AddIntParam("@IdUser", Usercoupons.IdUser);
            operation.AddDateTimeParam("@ApplicationDate", Usercoupons.ApplicationDate);

            return operation;
        }

        public SqlOperation GetDeleteStatement(int id) // Delete
        {
            var operation = new SqlOperation { ProcedureName = "DeleteUserCoupons" };
            operation.AddIntParam("@Id", id);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement() // Retrieve All 
        {
            return new SqlOperation { ProcedureName = "GetAllUserCoupons" };
        }
    }
}
