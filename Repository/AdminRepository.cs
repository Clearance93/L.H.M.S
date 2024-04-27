using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DatabaseContext _context;

        public AdminRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public Admin Create(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public Admin Delete(Admin admin)
        {
            _context.Admins.Attach(admin);
            _context.Entry(admin).State = EntityState.Deleted;
            _context.SaveChanges();
            return admin;
        }

        public List<Admin> GetAll()
        {
            List<Admin> admin = _context.Admins.ToList();
            return admin;
        }

        public Admin GetById(int id)
        {
            Admin admin = _context.Admins.FirstOrDefault(p => p.AdminId == id); 
            return admin;
        }

        public Admin Update(Admin admin)
        {
            _context.Admins.Attach(admin);
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
            return admin;
        }
    }
}
