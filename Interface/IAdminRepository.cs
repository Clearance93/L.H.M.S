using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IAdminRepository 
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        Admin Create(Admin admin);
        Admin Update(Admin admin);
        Admin Delete(Admin admin);
    }
}
