using HealthHub.AppLogic;
using HealthHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace HealthHub.Infrastructure
{
    internal class DoctorsRepository : IDoctorsRepository
    {
        public readonly HealthHubDbContext _context;
        public DoctorsRepository(HealthHubDbContext context)
        {
            _context = context;
        }

        public IList<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor? GetById(int id)
        {
            return _context?.Doctors.FirstOrDefault(x => x.Id == id);
        }

        public IList<Doctor> GetDoctorsBySpecialty(int specialtyId)
        {
            IList<Doctor> l = _context.Doctors.Where(a => a.SpecialtyId == specialtyId).ToList();
            return l;
        }

        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _context?.Doctors.Update(doctor);
            _context?.SaveChanges();
        }

        public void Delete(int id)
        {
            Doctor? doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
            _context.SaveChanges();
        }
    }
}
