using DTOs;
using DAO.Crud.Appointment;
using System;
using System.Collections.Generic;

namespace Bl.Mana_gers
{
    public class AppointmentManager
    {
        private readonly AppointmentCrudFactory _appointmentCrudFactory;

        public AppointmentManager()
        {
            _appointmentCrudFactory = new AppointmentCrudFactory();
        }

        public void Create(AppointmentDTO appointment)
        {
            _appointmentCrudFactory.Create(appointment);
        }

        public void Update(AppointmentDTO appointment)
        {
            _appointmentCrudFactory.Update(appointment);
        }

        public void Delete(int id)
        {
            _appointmentCrudFactory.Delete(id);
        }

        public List<AppointmentDTO> RetrieveAll()
        {
            return _appointmentCrudFactory.RetrieveAll();
        }

        public AppointmentDTO RetrieveById(int id)
        {
            return _appointmentCrudFactory.RetrieveById(id);
        }

        public List<AppointmentDTO> RetrieveByUserId(int userId)
        {
            return _appointmentCrudFactory.RetrieveByUserId(userId);
        }

        public List<AppointmentDTO> RetrieveByDateRange(DateTime startDate, DateTime endDate)
        {
            return _appointmentCrudFactory.RetrieveByDateRange(startDate, endDate);
        }
    }
}
