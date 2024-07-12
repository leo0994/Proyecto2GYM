using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class MeasureManager
    {
        private readonly MeasureCrudFactory _crudFactory;

        public MeasureManager()
        {
            _crudFactory = new MeasureCrudFactory();
        }

        public MeasureDTO Create(MeasureDTO measure)
        {
            return _crudFactory.Create(measure);
        }

        public MeasureDTO Update(MeasureDTO measure)
        {
            return _crudFactory.Update(measure);
        }

        public MeasureDTO Delete(MeasureDTO measure)
        {
            return _crudFactory.Delete(measure);
        }

        public List<MeasureDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public MeasureDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
