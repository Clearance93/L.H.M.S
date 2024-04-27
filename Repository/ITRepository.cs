using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class ITRepository : IITRepository
    {
        private readonly DatabaseContext _context;

        public ITRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IT Create(IT it)
        {
            _context.ITs.Add(it);   
            _context.SaveChanges();
            return it;
        }

        public IT Delete(IT it)
        {
            _context.ITs.Attach(it);
            _context.Entry(it).State = EntityState.Deleted;
            _context.SaveChanges();
            return it;
        }

        public List<IT> GetAll()
        {
            List<IT> it = _context.ITs.ToList();
            return it;
        }

        public IT GetById(int id)
        {
            IT it = _context.ITs.FirstOrDefault(i => i.ITId == id);
            return it;
        }

        public IT Update(IT it)
        {
            _context.ITs.Attach(it);
            _context.Entry(it).State= EntityState.Modified;
            _context.SaveChanges();
            return it;
        }
    }
}
