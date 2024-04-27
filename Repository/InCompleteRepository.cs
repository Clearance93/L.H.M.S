using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class InCompleteRepository : IInComplteRepository
    {
        private readonly DatabaseContext _context;

        public InCompleteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public InComplete DeleteById(InComplete inComplete)
        {
            _context.InCompletes.Attach(inComplete);
            _context.Entry(inComplete).State = EntityState.Deleted;
            _context.SaveChanges();
            return inComplete;
        }

        public List<InComplete> GetAll()
        {
            List<InComplete> inCompletes = _context.InCompletes.ToList();
            return inCompletes;
        }

        public InComplete GetById(int id)
        {
            InComplete inComplete = _context.InCompletes.FirstOrDefault(x => x.Id == id);   
            return inComplete;
        }

        public InComplete Update(InComplete inComplete)
        {
            _context.InCompletes.Attach(inComplete);
            _context.Entry(inComplete). State = EntityState.Modified; 
            _context.SaveChanges();
            return inComplete;
        }
    }
}
