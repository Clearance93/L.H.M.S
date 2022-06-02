using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class MedicalRecordsRepository : IMedicalRecordsRepository
    {
        private readonly DatabaseContext _context;

        public MedicalRecordsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public MedicalRecord Create(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            _context.SaveChanges();
            return record;
        }

        public MedicalRecord Delete(MedicalRecord record)
        {
            _context.MedicalRecords.Attach(record);
            _context.Entry(record).State = EntityState.Deleted;
            _context.SaveChanges();
            return record;
        }

        public List<MedicalRecord> GetAll()
        {
           List<MedicalRecord> record = _context.MedicalRecords.ToList();
            return record;
        }

        public MedicalRecord GetById(int id)
        {
            MedicalRecord record = _context.MedicalRecords.FirstOrDefault(x => x.MedicalId == id);
            return record;
        }

        public MedicalRecord Update(MedicalRecord record)
        {
            _context.MedicalRecords.Attach(record);
            _context.Entry(record).State |= EntityState.Modified;
            _context.SaveChanges();
            return record;
        }
    }
}
