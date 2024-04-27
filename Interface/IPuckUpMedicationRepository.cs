using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IPuckUpMedicationRepository
    {
        List<PickUpMedication> GetAll();
        PickUpMedication GetbyId(int id);
        PickUpMedication Create(PickUpMedication meds);
        PickUpMedication Update(PickUpMedication meds);
    }
}
