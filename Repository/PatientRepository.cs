using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DatabaseContext _context;

        public PatientRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Patient Create(Patient patient)
        {
            _context.Patients.Add(patient); 
            _context.SaveChanges();
            return patient;
        }

        public Patient Delete(Patient patient)
        {
            _context.Patients.Attach(patient);
            _context.Entry(patient).State = EntityState.Deleted;
            _context.SaveChanges();
            return patient;
        }

        public List<Patient> GetAll()
        {
            List<Patient> patient = _context.Patients.ToList(); 
            return patient;
        }

        public Patient GetById(int id)
        {
            Patient patient = _context.Patients.FirstOrDefault(x => x.PatientId == id);
            return patient;
        }

        public Patient Update(Patient patient)
        {
            _context.Patients.Attach(patient);
            _context.Entry(patient).State= EntityState.Modified;
            _context.SaveChanges();
            return patient;
        }
    }
}
