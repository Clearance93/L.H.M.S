using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class TreatmentRepository : ITreatmentsRepository
    {
        private readonly DatabaseContext _context;

        public TreatmentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public TreatmentHistory Create(TreatmentHistory treatment)
        {
            _context.Treatments.Add(treatment);
            _context.SaveChanges();
            return treatment;
        }

        public TreatmentHistory Delete(TreatmentHistory treatment)
        {
            _context.Treatments.Attach(treatment);
            _context.Entry(treatment).State = EntityState.Deleted;
            _context.SaveChanges();
            return treatment;
        }

        public TreatmentHistory Get(int id)
        {
            TreatmentHistory treatment = _context.Treatments.FirstOrDefault(x => x.TreatMentHistoryId == id); 
            return treatment;
        }

        public List<TreatmentHistory> GetAll()
        {
            List<TreatmentHistory> treatment = _context.Treatments.ToList();
            return treatment;
        }

        public TreatmentHistory Update(TreatmentHistory treatment)
        {
            _context.Treatments.Attach(treatment);
            _context.Entry(treatment).State= EntityState.Modified;
            _context.SaveChanges();
            return treatment;
        }
    }
}
