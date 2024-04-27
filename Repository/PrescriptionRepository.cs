using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly DatabaseContext _context;

        public PrescriptionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Prescription Create(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);   
            _context.SaveChanges();
            return prescription;
        }

        public Prescription Delete(Prescription prescription)
        {
            _context.Prescriptions.Attach(prescription);
            _context.Entry(prescription).State = EntityState.Deleted;
            _context.SaveChanges();
            return prescription;
        }

        public List<Prescription> GetAll()
        {
            List<Prescription> prescriptions = _context.Prescriptions.ToList();
            return prescriptions;
        }

        public Prescription GetPrescription(int id)
        {
            Prescription prescription = _context.Prescriptions.FirstOrDefault(d => d.Id == id);
            return prescription;
        }

        public Prescription Update(Prescription prescription)
        {
            _context.Prescriptions.Attach(prescription);
            _context.Entry(prescription).State = EntityState.Modified;
            _context.SaveChanges();
            return prescription;
        }
    }
}