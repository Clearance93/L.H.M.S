using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IMetinityWardRepository
    {
        List<MetinityWard> GetAll();
        MetinityWard GetById(int id);
        MetinityWard Update(MetinityWard ward);
        MetinityWard Delete(MetinityWard ward);
        MetinityWard Create(MetinityWard ward);
    }
}
