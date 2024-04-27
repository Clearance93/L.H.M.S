using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class FemaleWardRepository : IFemaleWardRepository
    {
        public readonly DatabaseContext _context;

        public FemaleWardRepository(DatabaseContext context)
        {
            _context = context;
        }

        public FemaleWard Create(FemaleWard female)
        {
            _context.FemaleWards.Add(female);
            _context.SaveChanges();
            return female;
        }

        public FemaleWard Delete(FemaleWard female)
        {
            _context.FemaleWards.Attach(female);
            _context.Entry(female).State = EntityState.Deleted;
            _context.SaveChanges();
            return female;
        }

        public List<FemaleWard> GetAll()
        {
            List<FemaleWard> female = _context.FemaleWards.ToList();
            return female;
        }

        public FemaleWard GetById(int id)
        {
            FemaleWard female = _context.FemaleWards.FirstOrDefault(f => f.FemaleWardId == id);
            return female;
        }

        public FemaleWard Update(FemaleWard female)
        {
            _context.FemaleWards.Attach(female);
            _context.Entry(female).State = EntityState.Modified;
            _context.SaveChanges();
            return female;
        }
    }
}
