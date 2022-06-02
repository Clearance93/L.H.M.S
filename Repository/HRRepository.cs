using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class HRRepository : IHRRepository
    {
        private readonly DatabaseContext _context;

        public HRRepository(DatabaseContext context)
        {
            _context = context;
        }

        public HR Create(HR hr)
        {
            _context.HRs.Add(hr);
            _context.SaveChanges(); 
            return hr;
        }

        public HR Delete(HR hr)
        {
            _context.HRs.Attach(hr);
            _context.Entry(hr).State = EntityState.Deleted;
            _context.SaveChanges();
            return hr;
        }

        public List<HR> GetAll()
        {
            List<HR> hr = _context.HRs.ToList();
            return hr;
        }

        public HR GetById(int id)
        {
           HR hr = _context.HRs.FirstOrDefault(p => p.HRId == id);
            return hr;
        }

        public HR Update(HR hr)
        {
            _context.HRs.Attach(hr);
            _context.Entry(hr).State= EntityState.Modified;
            _context.SaveChanges();
            return hr;
        }
    }
}
