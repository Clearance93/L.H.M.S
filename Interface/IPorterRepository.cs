using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IPorterRepository
    {
        List<Porter> GetAll();
        Porter GetById(int id);
        Porter Create(Porter porter);
        Porter Update(Porter porter);
        Porter Delete(Porter porter);
    }
}
