using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IMedicalRecordsRepository
    {
        List<MedicalRecord> GetAll();
        MedicalRecord GetById(int id);  
        MedicalRecord Create(MedicalRecord record); 
        MedicalRecord Update(MedicalRecord record);
        MedicalRecord Delete(MedicalRecord record) ;
    }
}
