using DAO.Crud.CouponsCrudFactory;
using DAO.Crud;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Crud.UserCouponsCrudFactory;
using DTO.UserCouponsDTO;

namespace BL.Managers.UserCouponsManager
{
    public class UserCouponsManager : CrudFactory<UserCouponsDTO>
    {
        private readonly UserCouponsCrudFactory _UserCouponsCrudFactory;

        public UserCouponsManager()
        {
            _UserCouponsCrudFactory = new UserCouponsCrudFactory();
        }

        public override UserCouponsDTO Create(UserCouponsDTO entityDTO)
        {

            return _UserCouponsCrudFactory.Create(entityDTO);
        }

        public override UserCouponsDTO Update(UserCouponsDTO entityDTO)
        {
            return _UserCouponsCrudFactory.Update(entityDTO);
        }

        public override UserCouponsDTO Delete(UserCouponsDTO entityDTO)
        {
            return _UserCouponsCrudFactory.Delete(entityDTO);
        }

        public override List<UserCouponsDTO> RetrieveAll()
        {
            return _UserCouponsCrudFactory.RetrieveAll();
        }

        public override UserCouponsDTO RetrieveById(int id)
        {
            return _UserCouponsCrudFactory.RetrieveById(id);
        }
    }
}
