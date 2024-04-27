using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class UserRolesRepository : IUserRoleRepository
    {
        private readonly DatabaseContext _context;

        public UserRolesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public UserRole Create(UserRole userRole)
        {
            _context.UsersRole.Add(userRole);
            _context.SaveChanges();
            return userRole;
        }

        public UserRole Delete(UserRole userRole)
        {
            _context.UsersRole.Attach(userRole);
            _context.Entry(userRole).State = EntityState.Deleted;
            _context.SaveChanges();
            return userRole;
        }

        public List<UserRole> GetAll()
        {
            List<UserRole> roles = _context.UsersRole.ToList();
            return roles;
        }

        public UserRole GetById(string id)
        {
            UserRole roles = _context.UsersRole.FirstOrDefault(p => p.UserId == id);
            return roles;
        }

        public UserRole Update(UserRole userRole)
        {
            _context.UsersRole.Attach(userRole);
            _context.Entry(userRole).State = EntityState.Modified;
            _context.SaveChanges();
            return userRole;
        }
    }
}
