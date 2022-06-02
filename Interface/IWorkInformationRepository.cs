using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IWorkInformationRepository
    {
        List<WorkInformation> GetAll();
        WorkInformation GetById(int id);
        WorkInformation Create(WorkInformation workInformation);
        WorkInformation Update(WorkInformation workInformation);
        WorkInformation Delete(WorkInformation workInformation);
    }
}
