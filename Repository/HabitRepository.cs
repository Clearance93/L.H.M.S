using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class HabitRepository : IHabitRepository
    {
        private readonly DatabaseContext _context;

        public HabitRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Habits Create(Habits habits)
        {
            _context.Habits.Add(habits);
            _context.SaveChanges();
            return habits;
        }

        public Habits Delete(Habits habits)
        {
            _context.Habits.Attach(habits);
            _context.Entry(habits).State = EntityState.Deleted;
            _context.SaveChanges();
            return habits;
        }

        public Habits Get(int id)
        {
            Habits habits = _context.Habits.FirstOrDefault(p => p.HabitsId == id);   
            return habits;
        }

        public List<Habits> GetAll()
        {
            List<Habits> habits = _context.Habits.ToList();
            return habits;
        }

        public Habits Update(Habits habits)
        {
            _context.Habits.Attach(habits);
            _context.Entry(habits).State = EntityState.Modified;
            _context.SaveChanges();
            return habits;
        }
    }
}
