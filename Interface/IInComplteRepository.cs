using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IInComplteRepository
    {
        List<InComplete> GetAll();
        InComplete GetById(int id);
        InComplete Update(InComplete inComplete);
        InComplete DeleteById(InComplete inComplete);
    }
}
