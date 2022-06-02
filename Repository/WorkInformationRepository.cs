using ClinicalApp.Data;
using ClinicalApp.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class WorkInformationRepository : IWorkInformationRepository
    {
        private readonly DatabaseContext _context;

        public WorkInformationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Models.WorkInformation Create(Models.WorkInformation workInformation)
        {
            _context.WorkInformations.Add(workInformation);
            _context.SaveChanges(); 
            return workInformation;
        }

        public Models.WorkInformation Delete(Models.WorkInformation workInformation)
        {
            _context.WorkInformations.Attach(workInformation);
            _context.Entry(workInformation).State = EntityState.Deleted;
            _context.SaveChanges();
            return workInformation;
        }

        public List<Models.WorkInformation> GetAll()
        {
            List<Models.WorkInformation> work = _context.WorkInformations.ToList();
            return work;
        }

        public Models.WorkInformation GetById(int id)
        {
            Models.WorkInformation work = _context.WorkInformations.FirstOrDefault(x => x.WorkId == id);
            return work;
        }

        public Models.WorkInformation Update(Models.WorkInformation workInformation)
        {
            _context.WorkInformations.Attach(workInformation);
            _context.Entry(workInformation).State = EntityState.Modified;
            _context.SaveChanges();
            return workInformation;
        }
    }
}
