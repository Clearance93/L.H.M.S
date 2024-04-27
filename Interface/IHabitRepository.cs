using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IHabitRepository
    {
        List<Habits> GetAll();
        Habits Get(int id);
        Habits Create(Habits habits);
        Habits Update(Habits habits);   
        Habits Delete(Habits habits);
    }
}
