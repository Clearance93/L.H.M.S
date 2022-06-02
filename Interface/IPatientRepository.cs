using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
        Patient GetById(int id);
        Patient Create(Patient patient);
        Patient Update(Patient patient);
        Patient Delete(Patient patient);
    }
}
