using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IFinanceRepository
    {
        List<Finance> GetAll();
        Finance GetById(int id);
        Finance Create(Finance finance);
        Finance Update(Finance finance);
        Finance Delete(Finance finance);
    }
}
