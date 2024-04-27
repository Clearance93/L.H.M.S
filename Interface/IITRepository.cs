using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IITRepository
    {
        List<IT> GetAll();
        IT GetById(int id);
        IT Create(IT it);
        IT Update(IT it);
        IT Delete(IT it);
    }
}
