using DAO.Crud;
using DAO.Crud.CouponsCrudFactory;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.CouponsManager
{
    public class CouponsManager : CrudFactory<CouponsDTO>
    {
        private readonly CouponsCrudFactory _CouponsCrudFactory;

        public CouponsManager()
        {
            _CouponsCrudFactory = new CouponsCrudFactory();
        }

        public override CouponsDTO Create(CouponsDTO entityDTO)
        {

            return _CouponsCrudFactory.Create(entityDTO);
        }

        public override CouponsDTO Update(CouponsDTO entityDTO)
        {
            return _CouponsCrudFactory.Update(entityDTO);
        }

        public override CouponsDTO Delete(CouponsDTO entityDTO)
        {
            return _CouponsCrudFactory.Delete(entityDTO);
        }

        public override List<CouponsDTO> RetrieveAll()
        {
            return _CouponsCrudFactory.RetrieveAll();
        }

        public override CouponsDTO RetrieveById(int id)
        {
            return _CouponsCrudFactory.RetrieveById(id);
        }
    }
}
