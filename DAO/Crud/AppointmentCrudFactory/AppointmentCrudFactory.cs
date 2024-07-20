using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class AppointmentCrudFactory : CrudFactory<AppointmentDTO>
    {
        private readonly AppointmentMapper _mapper;

        public AppointmentCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new AppointmentMapper();
        }

        public override AppointmentDTO Create(AppointmentDTO appointment)
        {
            var sqlOperation = _mapper.GetCreateStatement(appointment);
            dao.ExecuteProcedure(sqlOperation);
            return appointment;
        }

        public override AppointmentDTO Delete(AppointmentDTO appointment)
        {
            var sqlOperation = _mapper.GetDeleteStatement(appointment.Id);
            dao.ExecuteProcedure(sqlOperation);
            return appointment;
        }

        public override List<AppointmentDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override AppointmentDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override AppointmentDTO Update(AppointmentDTO appointment)
        {
            var sqlOperation = _mapper.GetUpdateStatement(appointment);
            dao.ExecuteProcedure(sqlOperation);
            return appointment;
        }
    }
}
