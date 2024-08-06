using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO.Mapper.CouponsMapper
{
    public class CouponsMapper : ICrudStatements<CouponsDTO>, IObjectMapper<CouponsDTO>
    {
        public CouponsDTO BuildObject(Dictionary<string, object> row)
        {
            return new CouponsDTO
            {
                Id = (int)row["Id"],
                CouponsName = (string)row["CouponName"],
                NumbersCoupons= (int)row["NumbersCoupons"],
                ExpirationDate = (DateTime)row["ExpirationDate"],
                Percentaje = (decimal)row["Percentaje"]
            };
        }

        public List<CouponsDTO> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<CouponsDTO>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetCreateStatement(CouponsDTO coupons) // create
        {
            var operation = new SqlOperation { ProcedureName = "CreateCoupons" };
            operation.AddVarcharParam("@CouponsName", coupons.CouponsName);
            operation.AddIntParam("@NumbersCoupons", coupons.NumbersCoupons);
            operation.AddDateTimeParam("@ExpirationDate", coupons.ExpirationDate);
            operation.AddDecimalParam("@Percentaje", coupons.Percentaje);


            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id) // return by ID
        {
            var operation = new SqlOperation { ProcedureName = "GetCouponsById" };
            operation.AddIntParam("@Id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(CouponsDTO coupons) // Update
        {
            var operation = new SqlOperation { ProcedureName = "UpdateCoupons"};

            operation.AddIntParam("@Id", coupons.Id);
            operation.AddVarcharParam("@CouponName", coupons.CouponsName);
            operation.AddIntParam("@NumbersCoupons", coupons.NumbersCoupons);
            operation.AddDateTimeParam("@ExpirationDate", coupons.ExpirationDate);
            operation.AddDecimalParam("@Percentaje", coupons.Percentaje);

            return operation;
        }

        public SqlOperation GetDeleteStatement(int id) // Delete
        {
            var operation = new SqlOperation { ProcedureName = "DeleteCoupons" };
            operation.AddIntParam("@Id", id);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement() // Retrieve All 
        {
            return new SqlOperation { ProcedureName = "GetAllCoupons" };
        }
    }
}
