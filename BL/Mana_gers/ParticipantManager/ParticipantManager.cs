using DTOs;
using BL.Managers;
using System.Collections.Generic;

namespace BL.Mana_gers
{
    public class ParticipantManager
    {
        private readonly ParticipantCrudFactory _crudFactory;

        public ParticipantManager()
        {
            _crudFactory = new ParticipantCrudFactory();
        }

        public void Create(ParticipantDTO participant)
        {
            _crudFactory.Create(participant);
        }

        public void Update(ParticipantDTO participant)
        {
            _crudFactory.Update(participant);
        }

        public void Delete(int id)
        {
            var participant = new ParticipantDTO { Id = id };
            _crudFactory.Delete(participant);
        }

        public ParticipantDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<ParticipantDTO>(id);
        }

        public List<ParticipantDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<ParticipantDTO>();
        }
    }
}
