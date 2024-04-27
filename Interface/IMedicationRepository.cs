using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IMedicationRepository
    {
        List<Medications> GetAll();
        Medications GetById(int id);
        Medications Create(Medications medication);
        Medications Update(Medications medication); 
        Medications Delete(Medications medications);
    }
}
