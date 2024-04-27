using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class Patient_Of_HospitalRepository : IPatient_of_HospitalRepository
    {
        private readonly DatabaseContext _context;

        public Patient_Of_HospitalRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Patient_Of_Hospital Delete(Patient_Of_Hospital hos)
        {
            _context.Patient_Of_Hospital.Attach(hos);
            _context.Entry(hos).State = EntityState.Deleted;
            _context.SaveChanges();
            return hos; 
        }

        public List<Patient_Of_Hospital> GetAll()
        {
           List<Patient_Of_Hospital> hospitals = _context.Patient_Of_Hospital.ToList();
            return hospitals;
        }

        public Patient_Of_Hospital GetById(int id)
        {
            Patient_Of_Hospital hospital = _context.Patient_Of_Hospital.FirstOrDefault(p => p.id == id);
            return hospital;
        }

        public Patient_Of_Hospital Update(Patient_Of_Hospital hos)
        {
            _context.Patient_Of_Hospital.Attach(hos);
            _context.Entry(hos).State = EntityState.Modified;
            _context.SaveChanges();
            return hos;
        }
    }
}
