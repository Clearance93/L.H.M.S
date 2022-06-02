using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IPrescriptionRepository
    {
         List<Prescription> GetAll();   
        Prescription GetPrescription(int id);
        Prescription Create(Prescription prescription);
        Prescription Update(Prescription prescription); 
        Prescription Delete(Prescription prescription);
    }
}