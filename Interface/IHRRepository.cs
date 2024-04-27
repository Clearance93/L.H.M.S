using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IHRRepository
    {
        List<HR> GetAll();
        HR GetById(int id);
        HR Create(HR hr);
        HR Update(HR hr);
        HR Delete(HR hr);
    }
}
