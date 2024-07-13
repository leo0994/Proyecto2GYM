using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class PaymentMethodCrudFactory : CrudFactory<PaymentMethodDTO>
    {
        private readonly PaymentMethodMapper _mapper;
        private readonly SqlDAO _dao;

        public PaymentMethodCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new PaymentMethodMapper();
        }

        public override PaymentMethodDTO Create(PaymentMethodDTO entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override PaymentMethodDTO Delete(PaymentMethodDTO entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO.Id);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override List<PaymentMethodDTO> RetrieveAll()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _dao.ExecuteQueryProcedure(operation);
            return _mapper.BuildObjects(results);
        }

        public override PaymentMethodDTO RetrieveById(int id)
        {
            var operation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(operation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override PaymentMethodDTO Update(PaymentMethodDTO entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }
    }
}
