using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface INurseRepository
    {
        List<Nurse> GetAll();
        Nurse GetById(int id);
        Nurse Create(Nurse nurse);
        Nurse Update(Nurse nurse);
        Nurse Delete(Nurse nurse);
    }
}
