using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IDoctorRespository
    {
        List<Doctor> GetAll();
        Doctor GetDoctor(int id);

        Doctor Create(Doctor doctor);

        Doctor Edit(Doctor doctor);

        Doctor Delete(Doctor doctor);
    }
}