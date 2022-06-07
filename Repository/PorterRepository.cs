using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class PorterRepository : IPorterRepository
    {
        private readonly DatabaseContext _context;

        public PorterRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Porter Create(Porter porter)
        {
           //_context.Porters.Attach(porter);
           // _context.Entry(porter).State = EntityState.Added;
           // _context.SaveChanges();
           // return porter;
           _context.Porters.Add(porter);
            _context.SaveChanges();
            return porter;
        }

        public Porter Delete(Porter porter)
        {
            _context.Porters.Attach(porter);
            _context.Entry(porter).State = EntityState.Deleted;
            _context.SaveChanges();
            return porter;
        }

        public List<Porter> GetAll()
        {
            List<Porter> porter = _context.Porters.ToList();
            return porter;
        }

        public Porter GetById(int id)
        {
            Porter porter = _context.Porters.FirstOrDefault(x => x.Id == id);
            return porter;
        }

        public Porter Update(Porter porter)
        {
            _context.Porters.Attach(porter);
            _context.Entry(porter).State= EntityState.Modified; 
            _context.SaveChanges();
            return porter;
        }
    }
}
