using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class Chronic_DiseaseRepository : IChronic_DeseaseRepository
    {
        private readonly DatabaseContext _context;

        public Chronic_DiseaseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Patient_In_Hospital Create(Patient_In_Hospital disease)
        {
            _context.Patient_In_Hospital.Add(disease);
            _context.SaveChanges();
            return disease; 
        }

        public Patient_In_Hospital Delete(Patient_In_Hospital disease)
        {
            _context.Patient_In_Hospital.Attach(disease);
            _context.Entry(disease).State = EntityState.Deleted;
            _context.SaveChanges();
            return disease;
        }

        public List<Patient_In_Hospital> GetAll()
        {
            List<Patient_In_Hospital> hos = _context.Patient_In_Hospital.ToList();
            return hos;
        }

        public Patient_In_Hospital GetById(int id)
        {
            Patient_In_Hospital hos = _context.Patient_In_Hospital.FirstOrDefault(p => p.id == id);
            return hos;
        }

        public Patient_In_Hospital Update(Patient_In_Hospital disease)
        {
            _context.Patient_In_Hospital.Attach(disease);
            _context.Entry(disease).State = EntityState.Modified;
            _context.SaveChanges();
            return disease;
        }
    }
}
