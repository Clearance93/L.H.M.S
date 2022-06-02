using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class FinanceRepository : IFinanceRepository
    {
        private readonly DatabaseContext _context;

        public FinanceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Finance Create(Finance finance)
        {
            _context.Finances.Add(finance); 
            _context.SaveChanges();
            return finance;
        }

        public Finance Delete(Finance finance)
        {
            _context.Finances.Attach(finance);
            _context.Entry(finance).State = EntityState.Deleted;
            _context.SaveChanges();
            return finance;
        }

        public List<Finance> GetAll()
        {
            List<Finance> finance = _context.Finances.ToList();
            return finance;
        }

        public Finance GetById(int id)
        {
            Finance finance = _context.Finances.FirstOrDefault(p => p.FinanceId == id);
            return finance;
        }

        public Finance Update(Finance finance)
        {
            _context.Finances.Attach(finance);
            _context.Entry(finance).State = EntityState.Modified;
            _context.SaveChanges();
            return finance;
        }
    }
}
