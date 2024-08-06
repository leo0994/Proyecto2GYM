using DAO.Mapper;
using DAO.Mapper.CouponsMapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO.Crud.CouponsCrudFactory
{
    public class CouponsCrudFactory : CrudFactory<CouponsDTO>
    {
        private readonly SqlDAO _dao;
        private readonly CouponsMapper _mapper;

        public CouponsCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new CouponsMapper();
        }

        public override CouponsDTO Create(CouponsDTO entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override CouponsDTO Update(CouponsDTO entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override CouponsDTO Delete(CouponsDTO entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO.Id);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override List<CouponsDTO> RetrieveAll()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _dao.ExecuteQueryProcedure(operation);
            return _mapper.BuildObjects(results);
        }

        public override CouponsDTO RetrieveById(int id)
        {
            var operation = _mapper.GetRetrieveByIdStatement(id);
            var results = _dao.ExecuteQueryProcedure(operation);
            if (results.Count > 0)
            {
                return _mapper.BuildObject(results[0]);
            }
            return null;
        }
    }
}
