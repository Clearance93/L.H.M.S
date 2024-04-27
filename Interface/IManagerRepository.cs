using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IManagerRepository
    {
        List<Manager> GetAll();
        Manager GetById(int id);
        Manager Create(Manager manager);
        Manager Update(Manager manager);
        Manager Delete(Manager manager);
    }
}
