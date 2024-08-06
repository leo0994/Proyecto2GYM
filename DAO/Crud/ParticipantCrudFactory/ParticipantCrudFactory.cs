using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class ParticipantCrudFactory : CrudFactory<ParticipantDTO>
    {
        private readonly ParticipantMapper _mapper;

        public ParticipantCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new ParticipantMapper();
        }

        public override ParticipantDTO Create(ParticipantDTO participant)
        {
            var sqlOperation = _mapper.GetCreateStatement(participant);
            dao.ExecuteProcedure(sqlOperation);
            return participant;
        }

         public int RegisterParticipant(ParticipantDTO participant)
        {
            var sqlOperation = _mapper.GetCreateStatement(participant);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return (int)result[0]["Status"];
        }

        public override ParticipantDTO Delete(ParticipantDTO participant)
        {
            var sqlOperation = _mapper.GetDeleteStatement(participant.Id);
            dao.ExecuteProcedure(sqlOperation);
            return participant;
        }

        public override List<ParticipantDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override ParticipantDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override ParticipantDTO Update(ParticipantDTO participant)
        {
            var sqlOperation = _mapper.GetUpdateStatement(participant);
            dao.ExecuteProcedure(sqlOperation);
            return participant;
        }
    }
}
