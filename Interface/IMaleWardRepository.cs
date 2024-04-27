using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IMaleWardRepository
    {
        List<ManWard> GetAll();
        ManWard GetById(int id);
        ManWard Update(ManWard man);
        ManWard Delete ( ManWard man);
        ManWard Create(ManWard man);
    }
}
