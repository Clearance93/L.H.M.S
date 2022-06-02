using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IFemaleWardRepository
    {
        List<FemaleWard> GetAll();
        FemaleWard GetById(int id);
        FemaleWard Update(FemaleWard female);
        FemaleWard Delete(FemaleWard female);
        FemaleWard Create(FemaleWard female);
    }
}
