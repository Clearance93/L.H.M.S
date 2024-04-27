using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class PickUpMMedicationRepository : IPuckUpMedicationRepository
    {
        public readonly DatabaseContext _context;

        public PickUpMMedicationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public PickUpMedication Create(PickUpMedication meds)
        {
            _context.PickUpMedications.Add(meds);
            _context.SaveChanges();
            return meds;
        }

        public List<PickUpMedication> GetAll()
        {
            List<PickUpMedication> meds = _context.PickUpMedications.ToList();
            return meds;
        }

        public PickUpMedication GetbyId(int id)
        {
            PickUpMedication meds = _context.PickUpMedications.FirstOrDefault(g => g.MedsId == id);
            return meds;
        }

        public PickUpMedication Update(PickUpMedication meds)
        {
            _context.PickUpMedications.Attach(meds);
            _context.Entry(meds).State = EntityState.Modified;
            _context.SaveChanges();
            return meds;
        }
    }
}
