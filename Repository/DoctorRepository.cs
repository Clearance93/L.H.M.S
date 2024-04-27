using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class DoctorRepository : IDoctorRespository
    {
        private readonly DatabaseContext _context;

        public DoctorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Doctor Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor Delete(Doctor doctor)
        {
            _context.Doctors.Attach(doctor);
            _context.Entry(doctor).State = EntityState.Deleted;
            _context.SaveChanges();
            return doctor;
        }

        public Doctor Edit(Doctor doctor)
        {
           
            _context.Doctors.Attach(doctor);
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctor = _context.Doctors.ToList();
            return doctor;
        }

        public Doctor GetDoctor(int id)
        {
            Doctor doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == id);
            return doctor;
        }
    }
}
