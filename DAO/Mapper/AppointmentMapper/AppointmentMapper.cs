using DTOs;
using DAO.Mapper;
using System;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class AppointmentMapper : ISqlStatements, IObjectMapper
    {
        public AppointmentDTO BuildObject(Dictionary<string, object> row)
        {
            var appointmentDTO = new AppointmentDTO
            {
                Id = Convert.ToInt32(row["id"]),
                Date = Convert.ToDateTime(row["date"]),
                UserAId = Convert.ToInt32(row["user_A_id"]),
                UserBId = Convert.ToInt32(row["user_B_id"])
            };

            return appointmentDTO;
        }

        public List<AppointmentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<AppointmentDTO>();
            foreach (var row in rowsList)
            {
                var appointmentDTO = BuildObject(row);
                resultsList.Add(appointmentDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(AppointmentDTO appointment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RegisterAppointment" };

            sqlOperation.AddIntParam("@p_user_A_id", appointment.UserAId);
            sqlOperation.AddIntParam("@p_user_B_id", appointment.UserBId);
            sqlOperation.AddDateTimeParam("@p_date", appointment.Date);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteAppointment" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllAppointments" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetAppointmentById" };
            sqlOperation.AddIntParam("@p_appointment_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(AppointmentDTO appointment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateAppointment" };

            sqlOperation.AddIntParam("@p_appointment_id", appointment.Id);
            sqlOperation.AddIntParam("@p_user_A_id", appointment.UserAId);
            sqlOperation.AddIntParam("@p_user_B_id", appointment.UserBId);
            sqlOperation.AddDateTimeParam("@p_date", appointment.Date);

            return sqlOperation;
        }
    }
}
