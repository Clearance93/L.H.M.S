using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class MetinityRepository : IMetinityWardRepository
    {
        private readonly DatabaseContext _context;

        public MetinityRepository(DatabaseContext context)
        {
            _context = context;
        }

        public MetinityWard Create(MetinityWard ward)
        {
            _context.MetinityWards.Add(ward);
            _context.SaveChanges();
            return ward;
        }

        public MetinityWard Delete(MetinityWard ward)
        {
            _context.MetinityWards.Attach(ward);
            _context.Entry(ward).State = EntityState.Deleted;
            _context.SaveChanges();
            return ward;
        }

        public List<MetinityWard> GetAll()
        {
            List<MetinityWard> ward = _context.MetinityWards.ToList();
            return ward;
        }

        public MetinityWard GetById(int id)
        {
            MetinityWard ward = _context.MetinityWards.FirstOrDefault(m => m.MetinityWardId == id);
            return ward;
        }

        public MetinityWard Update(MetinityWard ward)
        {
            _context.MetinityWards.Attach(ward);
            _context.Entry(ward).State = EntityState.Modified;
            _context.SaveChanges();
            return ward;
        }
    }
}
