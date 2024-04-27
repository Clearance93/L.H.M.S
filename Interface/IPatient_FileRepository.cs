using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IPatient_FileRepository
    {
        List<Patient_File> GetAll();
        Patient_File GetPatientById(int id);

    }
}
