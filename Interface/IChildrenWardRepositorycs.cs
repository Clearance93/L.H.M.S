using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IChildrenWardRepositorycs
    {
        List<ChildrenWard> GetAll();
        ChildrenWard GetById(int id);
        ChildrenWard Create(ChildrenWard ward);
        ChildrenWard Update(ChildrenWard ward); 
        ChildrenWard Delete(ChildrenWard ward);
    }
}
