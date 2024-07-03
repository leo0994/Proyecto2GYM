using DTOs;
using DAO.Mapper;
using System;
using System.Collections.Generic;

namespace DAO.Crud.Appointment
{
    public class AppointmentCrudFactory
    {
        private readonly SqlDAO _dao;
        private readonly AppointmentMapper _mapper;

        public AppointmentCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new AppointmentMapper();
        }

        public void Create(AppointmentDTO appointment)
        {
            var sqlOperation = _mapper.GetCreateStatement(appointment);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public AppointmentDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }

            return null;
        }

        public List<AppointmentDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<AppointmentDTO>();
        }

        public void Update(AppointmentDTO appointment)
        {
            var sqlOperation = _mapper.GetUpdateStatement(appointment);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void Delete(int id)
        {
            var sqlOperation = _mapper.GetDeleteStatement(id);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public List<AppointmentDTO> RetrieveByUserId(int userId)
        {
            var sqlOperation = _mapper.GetRetrieveByUserIdStatement(userId);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<AppointmentDTO>();
        }

        public List<AppointmentDTO> RetrieveByDateRange(DateTime startDate, DateTime endDate)
        {
            var sqlOperation = _mapper.GetRetrieveByDateRangeStatement(startDate, endDate);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<AppointmentDTO>();
        }
    }
}
