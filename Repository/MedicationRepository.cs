using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly DatabaseContext _context;

        public MedicationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Medications Create(Medications medication)
        {
            _context.Medications.Add(medication);
            _context.SaveChanges();
            return medication;
        }

        public Medications Delete(Medications medications)
        {
            _context.Medications.Attach(medications);
            _context.Entry(medications).State = EntityState.Deleted;
            _context.SaveChanges();
            return medications;
        }

        public List<Medications> GetAll()
        {
            List<Medications> meds = _context.Medications.ToList();
            return meds;
        }

        public Medications GetById(int id)
        {
            Medications med = _context.Medications.FirstOrDefault(p => p.MedicationId == id);
            return med;
        }

        public Medications Update(Medications medication)
        {
            _context.Medications.Attach(medication);
            _context.Entry(medication).State = EntityState.Modified;
            _context.SaveChanges();
            return medication;

        }
    }
}
