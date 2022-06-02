using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;

namespace ClinicalApp.Repository
{
    public class MaleWardRepository : IMaleWardRepository
    {
        public readonly DatabaseContext _context;

        public MaleWardRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ManWard Create(ManWard man)
        {
            _context.ManWards.Add(man);
            _context.SaveChanges();
            return man; 
        }

        public ManWard Delete(ManWard man)
        {
            _context.ManWards.Attach(man);
            _context.Entry(man).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return man;
        }

        public List<ManWard> GetAll()
        {
            List<ManWard> men = _context.ManWards.ToList();
            return men; 
        }

        public ManWard GetById(int id)
        {
            ManWard men = _context.ManWards.FirstOrDefault(m => m.MenWardId == id);
            return men;
        }

        public ManWard Update(ManWard man)
        {
            _context.ManWards.Attach(man);
            _context.Entry(man).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return man; 
        }
    }
}
