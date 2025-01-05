using HealthHub.AppLogic;
using HealthHub.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HealthHub.Infrastructure
{
    internal class AppointmentsRepository: IAppointmentsRepository
    {
        private readonly HealthHubDbContext _context;

        public AppointmentsRepository(HealthHubDbContext context)
        {
            _context = context;
        }

        public IList<Appointment> GetAll()
        {
            IList<Appointment> appointments = _context.Appointments.ToList();

            return appointments;
        }

        public Appointment? GetById(int id)
        {
            Appointment? appointment = _context.Appointments.FirstOrDefault(x =>  x.Id == id);
            _context.SaveChanges();
            return appointment;
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public IList<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var appointments = _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToList();

            return appointments;
        }

        public IList<Appointment> GetAppointmentsForPatient(string patientNationalNumber)
        {
           var appointments = _context.Appointments.Where(v => v.PatientNationalNumber == patientNationalNumber).ToList();
            return appointments;
        }

        public IList<Appointment> GetUpcomingAppointments(int daysAhead)
        {
            var appontments = _context.Appointments
                .Where(z => z.AppointmentDate < DateTime.Now.AddDays(daysAhead) && z.AppointmentDate > DateTime.Now).ToList();
            return appontments;        
        }
    }
}

