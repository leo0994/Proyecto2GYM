using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class ParticipantCrudFactory : CrudFactory
    {
        private readonly ParticipantMapper _mapper;

        public ParticipantCrudFactory()
        {
            _mapper = new ParticipantMapper();
            dao = SqlDAO.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var participant = (ParticipantDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(participant);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var participant = (ParticipantDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(participant);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var participant = (ParticipantDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(participant.Id);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
            }

            var participant = _mapper.BuildObject(dic);
            return (T)System.Convert.ChangeType(participant, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var participants = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var participant in participants)
            {
                list.Add((T)System.Convert.ChangeType(participant, typeof(T)));
            }

            return list;
        }
    }
}
