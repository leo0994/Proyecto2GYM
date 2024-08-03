using DTOs;

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
                UserBId = (int)row["user_B_id"],
                UserAName = (string)row["user_A_name"],
                UserBName = (string)row["user_B_name"],
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
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteAppointment" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "RetrieveAllAppointments" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RetrieveAppointmentById" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }
        public SqlOperation GetRetrieveByUserStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RetrieveAppointmentsByUser" };
            sqlOperation.AddIntParam("@userId", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(AppointmentDTO appointment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateAppointment" };
            sqlOperation.AddIntParam("@id", appointment.Id);
            sqlOperation.AddDateTimeParam("@date", appointment.Date);
            sqlOperation.AddIntParam("@userAId", appointment.UserAId);
            sqlOperation.AddIntParam("@userBId", appointment.UserBId);
            return sqlOperation;
        }
    }
}
