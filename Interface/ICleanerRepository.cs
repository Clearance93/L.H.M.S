using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface ICleanerRepository 
    {
        List<Clearner> GetAll();
        Clearner GetById(int id);
        Clearner Create(Clearner clearner);
        Clearner Update(Clearner clearner);
        Clearner Delete(Clearner clearner);
    }
}
