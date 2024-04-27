using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IParamedicRepository
    {
        List<Paramedic> GetAll();
        Paramedic GetById(int id);
        Paramedic Create(Paramedic paramedic);
        Paramedic Update(Paramedic paramedic);
        Paramedic  Delete(Paramedic paramedic);
    }
}
