using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class CleanerRepository : ICleanerRepository
    {
        private readonly DatabaseContext _context;

        public CleanerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Clearner Create(Clearner clearner)
        {
            _context.Clearners.Add(clearner);
            _context.SaveChanges();
            return clearner;
        }

        public Clearner Delete(Clearner clearner)
        {
            _context.Clearners.Attach(clearner);
            _context.Entry(clearner).State = EntityState.Deleted;
            _context.SaveChanges();
            return clearner;
        }

        public List<Clearner> GetAll()
        {
            List<Clearner> clearner = _context.Clearners.ToList();  
            return clearner;
        }

        public Clearner GetById(int id)
        {
            Clearner clearner = _context.Clearners.FirstOrDefault(p => p.CleanerId == id);
            return clearner;
        }

        public Clearner Update(Clearner clearner)
        {
            _context.Clearners.Attach(clearner);
            _context.Entry(clearner).State = EntityState.Modified;
            _context.SaveChanges();
            return clearner;
        }
    }
}
