using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class ParticipantMapper : ICrudStatements<ParticipantDTO>, IObjectMapper<ParticipantDTO>
    {
        public ParticipantDTO BuildObject(Dictionary<string, object> row)
        {
            var participant = new ParticipantDTO
            {
                Id = (int)row["id"],
                Date = (DateTime)row["date"],
                UserId = (int)row["user_id"],
                InstructorId = (int)row["instructor_id"],
                ClassId = (int)row["class_id"],
                Max = (int)row["max"]
            };

            return participant;
        }

        public List<ParticipantDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<ParticipantDTO>();
            foreach (var row in rowsList)
            {
                var participant = BuildObject(row);
                resultsList.Add(participant);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(ParticipantDTO participant)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RegisterClassAttendance" };

            sqlOperation.AddDateTimeParam("@date", participant.Date);
            sqlOperation.AddIntParam("@user_id", participant.UserId);
            sqlOperation.AddIntParam("@instructor_id", participant.InstructorId);
            sqlOperation.AddIntParam("@class_id", participant.ClassId);
            sqlOperation.AddIntParam("@max", participant.Max);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteParticipant" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllParticipants" }; // Assuming the existence of this stored procedure
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetParticipantById" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ParticipantDTO participant)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateClassAttendance" };

            sqlOperation.AddIntParam("@participant_id", participant.Id);
            sqlOperation.AddDateTimeParam("@date", participant.Date);
            sqlOperation.AddIntParam("@user_id", participant.UserId);
            sqlOperation.AddIntParam("@instructor_id", participant.InstructorId);
            sqlOperation.AddIntParam("@class_id", participant.ClassId);
            sqlOperation.AddIntParam("@max", participant.Max);

            return sqlOperation;
        }
    }
}
