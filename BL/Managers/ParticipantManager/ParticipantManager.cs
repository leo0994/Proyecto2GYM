using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class ParticipantManager
    {
        private readonly ParticipantCrudFactory _crudFactory;

        public ParticipantManager()
        {
            _crudFactory = new ParticipantCrudFactory();
        }

        public int Create(ParticipantDTO participant)
        {
            return _crudFactory.RegisterParticipant(participant);
        }

        public ParticipantDTO Update(ParticipantDTO participant)
        {
            return _crudFactory.Update(participant);
        }

        public ParticipantDTO Delete(ParticipantDTO participant)
        {
            return _crudFactory.Delete(participant);
        }

        public List<ParticipantDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public ParticipantDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
