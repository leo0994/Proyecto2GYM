using DAO.Mapper.CouponsMapper;
using DAO.Mapper.UserCouponsMapper;
using DTO.UserCouponsDTO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Crud.UserCouponsCrudFactory
{
    public class UserCouponsCrudFactory : CrudFactory<UserCouponsDTO>
    {
        private readonly SqlDAO _dao;
        private readonly UserCouponsMapper _mapper;

        public UserCouponsCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new UserCouponsMapper();
        }

        public override UserCouponsDTO Create(UserCouponsDTO entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override UserCouponsDTO Update(UserCouponsDTO entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override UserCouponsDTO Delete(UserCouponsDTO entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO.Id);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override List<UserCouponsDTO> RetrieveAll()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _dao.ExecuteQueryProcedure(operation);
            return _mapper.BuildObjects(results);
        }

        public override UserCouponsDTO RetrieveById(int id)
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
