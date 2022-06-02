using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IChronic_DeseaseRepository
    {
        List<Patient_In_Hospital> GetAll();
        Patient_In_Hospital GetById(int id);
        Patient_In_Hospital Create(Patient_In_Hospital disease);
        Patient_In_Hospital Update(Patient_In_Hospital disease);
        Patient_In_Hospital Delete(Patient_In_Hospital disease);
    }
}
