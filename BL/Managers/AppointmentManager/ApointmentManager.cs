using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class AppointmentManager
    {
        private readonly AppointmentCrudFactory _crudFactory;

        public AppointmentManager()
        {
            _crudFactory = new AppointmentCrudFactory();
        }

        public AppointmentDTO Create(AppointmentDTO appointment)
        {
            return _crudFactory.Create(appointment);
        }

        public AppointmentDTO Update(AppointmentDTO appointment)
        {
            return _crudFactory.Update(appointment);
        }

        public AppointmentDTO Delete(AppointmentDTO appointment)
        {
            return _crudFactory.Delete(appointment);
        }

        public List<AppointmentDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public AppointmentDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
