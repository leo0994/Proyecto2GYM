using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class AppointmentMapper : ICrudStatements<AppointmentDTO>, IObjectMapper<AppointmentDTO>
    {
        public AppointmentDTO BuildObject(Dictionary<string, object> row)
        {
            var appointment = new AppointmentDTO
            {
                Id = (int)row["id"],
                Date = (DateTime)row["date"],
                UserAId = (int)row["user_A_id"],
                UserBId = (int)row["user_B_id"]
            };

            return appointment;
        }

        public List<AppointmentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<AppointmentDTO>();
            foreach (var row in rowsList)
            {
                var appointment = BuildObject(row);
                resultsList.Add(appointment);
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
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteAppointment" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllAppointments" }; // Assuming the existence of this stored procedure
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetAppointmentById" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(AppointmentDTO appointment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateAppointment" }; // Assuming the existence of this stored procedure

            sqlOperation.AddIntParam("@p_id", appointment.Id);
            sqlOperation.AddIntParam("@p_user_A_id", appointment.UserAId);
            sqlOperation.AddIntParam("@p_user_B_id", appointment.UserBId);
            sqlOperation.AddDateTimeParam("@p_date", appointment.Date);

            return sqlOperation;
        }
    }
}
