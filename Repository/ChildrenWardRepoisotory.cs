using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class ChildrenWardRepoisotory : IChildrenWardRepositorycs
    {
        private readonly DatabaseContext _context;

        public ChildrenWardRepoisotory(DatabaseContext context)
        {
            _context = context;
        }

        public ChildrenWard Create(ChildrenWard ward)
        {
            _context.ChildrenWards.Add(ward);   
            _context.SaveChanges();
            return ward;
        }

        public ChildrenWard Delete(ChildrenWard ward)
        {
            _context.ChildrenWards.Attach(ward);
            _context.Entry(ward).State = EntityState.Deleted;
            _context.SaveChanges();
            return ward;
        }

        public List<ChildrenWard> GetAll()
        {
            List<ChildrenWard> wards = _context.ChildrenWards.ToList();
            return wards;
        }

        public ChildrenWard GetById(int id)
        {
            ChildrenWard ward = _context.ChildrenWards.FirstOrDefault(x => x.ChildrenId == id); 
            return ward;
        }

        public ChildrenWard Update(ChildrenWard ward)
        {
            throw new NotImplementedException();
        }
    }
}
