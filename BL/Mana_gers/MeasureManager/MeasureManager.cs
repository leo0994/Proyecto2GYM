using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Mana_gers
{
    public class MeasureManager
    {
        private readonly MeasureCrudFactory _crudFactory;

        public MeasureManager()
        {
            _crudFactory = new MeasureCrudFactory();
        }

        public void Create(MeasureDTO measure)
        {
            _crudFactory.Create(measure);
        }

        public void Update(MeasureDTO measure)
        {
            _crudFactory.Update(measure);
        }

        public void Delete(int id)
        {
            var measure = new MeasureDTO { Id = id };
            _crudFactory.Delete(measure);
        }

        public MeasureDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<MeasureDTO>(id);
        }

        public List<MeasureDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<MeasureDTO>();
        }
    }
}
