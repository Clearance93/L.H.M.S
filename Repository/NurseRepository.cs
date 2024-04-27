using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class NurseRepository : INurseRepository
    {
        private readonly DatabaseContext _context;

        public NurseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Nurse Create(Nurse nurse)
        {
            _context.Add(nurse);
            _context.SaveChanges();
            return nurse;
        }

        public Nurse Delete(Nurse nurse)
        {
            _context.Nurses.Attach(nurse);
            _context.Entry(nurse).State = EntityState.Deleted;
            _context.SaveChanges();
            return nurse;
        }

        public List<Nurse> GetAll()
        {
            List<Nurse> nurses = _context.Nurses.ToList();
            return nurses;
        }

        public Nurse GetById(int id)
        {
            Nurse nurse = _context.Nurses.FirstOrDefault(x => x.NurseId == id);
            return nurse;
        }

        public Nurse Update(Nurse nurse)
        {
            _context.Nurses.Attach(nurse);
            _context.Entry(nurse).State = EntityState.Modified;
            _context.SaveChanges();
            return nurse;
        }
    }
}
