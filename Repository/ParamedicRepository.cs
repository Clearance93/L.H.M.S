using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class ParamedicRepository : IParamedicRepository
    {
        public readonly DatabaseContext _context;

        public ParamedicRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Paramedic Create(Paramedic paramedic)
        {
           _context.Paramedics.Add(paramedic);
            _context.SaveChanges(); 
            return paramedic;
        }

        public Paramedic Delete(Paramedic paramedic)
        {
            _context.Paramedics.Attach(paramedic);
            _context.Entry(paramedic).State = EntityState.Deleted;
            _context.SaveChanges();
            return paramedic;
        }

        public List<Paramedic> GetAll()
        {
            List<Paramedic> paramedics = _context.Paramedics.ToList();
            return paramedics;
        }

        public Paramedic GetById(int id)
        {
            Paramedic paramedic = _context.Paramedics.FirstOrDefault(p => p.ParamedicId == id);
            return paramedic;
        }

        public Paramedic Update(Paramedic paramedic)
        {
            _context.Paramedics.Attach(paramedic);
            _context.Entry(paramedic).State = EntityState.Modified;
            _context.SaveChanges();
            return paramedic;
        }
    }
}
