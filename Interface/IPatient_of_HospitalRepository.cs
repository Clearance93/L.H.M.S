using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IPatient_of_HospitalRepository
    {
        List<Patient_Of_Hospital> GetAll();
        Patient_Of_Hospital GetById(int id);
        Patient_Of_Hospital Update(Patient_Of_Hospital hos);
        Patient_Of_Hospital Delete(Patient_Of_Hospital hos);
    }
}
