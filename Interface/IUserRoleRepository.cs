using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IUserRoleRepository
    {
        List<UserRole> GetAll();
        UserRole GetById(string id);
        UserRole Create(UserRole userRole);
        UserRole Update(UserRole userRole);
        UserRole Delete(UserRole userRole);
    }
}
