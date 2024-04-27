using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly DatabaseContext _context;

        public ManagerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Manager Create(Manager manager)
        {
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return manager;
        }

        public Manager Delete(Manager manager)
        {
            _context.Managers.Attach(manager);
            _context.Entry(manager).State = EntityState.Deleted;
            _context.SaveChanges();
            return manager;
        }

        public List<Manager> GetAll()
        {
            List<Manager> managers = _context.Managers.ToList();
            return managers;
        }

        public Manager GetById(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(x => x.ManagerId == id); 
            return manager;
        }

        public Manager Update(Manager manager)
        {
            _context.Managers.Attach(manager);
            _context.Entry(manager).State= EntityState.Modified;    
            _context.SaveChanges();
            return manager;
        }
    }
}
