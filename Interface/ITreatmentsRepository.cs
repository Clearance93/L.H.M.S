using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface ITreatmentsRepository
    {
        List<TreatmentHistory> GetAll();
        TreatmentHistory Get(int id);   
        TreatmentHistory Create(TreatmentHistory treatment);  
        TreatmentHistory Update(TreatmentHistory treatment);
        TreatmentHistory Delete(TreatmentHistory treatment);
    }
}
