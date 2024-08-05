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
                RegistrationDate = (DateTime)row["RegistrationDate"],
                UserId = (int)row["UserId"],
                ClassActivityId = (int)row["ClassActivityId"],
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
            var sqlOperation = new SqlOperation { ProcedureName = "RegisterParticipant" };
            sqlOperation.AddDateTimeParam("@registrationDate", participant.RegistrationDate);
            sqlOperation.AddIntParam("@userId", participant.UserId);
            sqlOperation.AddIntParam("@classActivityId", participant.ClassActivityId);
            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteParticipant" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllParticipants" }; 
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetParticipantById" }; 
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ParticipantDTO participant)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateClassAttendance" };

            sqlOperation.AddIntParam("@id", participant.Id);
            sqlOperation.AddDateTimeParam("@RegistrationDate", participant.RegistrationDate);
            sqlOperation.AddIntParam("@UserId", participant.UserId);
            sqlOperation.AddIntParam("@ClassActivityId", participant.ClassActivityId);

            return sqlOperation;
        }
    }
}
