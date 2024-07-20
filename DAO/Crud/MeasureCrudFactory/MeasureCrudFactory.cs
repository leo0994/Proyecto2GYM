using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class MeasureCrudFactory : CrudFactory<MeasureDTO>
    {
        private readonly MeasureMapper _mapper;

        public MeasureCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new MeasureMapper();
        }

        public override MeasureDTO Create(MeasureDTO measure)
        {
            var sqlOperation = _mapper.GetCreateStatement(measure);
            dao.ExecuteProcedure(sqlOperation);
            return measure;
        }

        public override MeasureDTO Delete(MeasureDTO measure)
        {
            var sqlOperation = _mapper.GetDeleteStatement(measure.Id);
            dao.ExecuteProcedure(sqlOperation);
            return measure;
        }

        public override List<MeasureDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override MeasureDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override MeasureDTO Update(MeasureDTO measure)
        {
            var sqlOperation = _mapper.GetUpdateStatement(measure);
            dao.ExecuteProcedure(sqlOperation);
            return measure;
        }
    }
}
