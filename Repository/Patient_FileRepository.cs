using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;

namespace ClinicalApp.Repository
{
    public class Patient_FileRepository : IPatient_FileRepository
    {
        private readonly DatabaseContext _context;

        public Patient_FileRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Patient_File> GetAll()
        {
            List<Patient_File> admin = _context.Patient_File.ToList();
            return admin;
        }


        public Patient_File GetPatientById(int id)
        {
            Patient_File file = _context.Patient_File.FirstOrDefault(p => p.PatientId == id);
            return file; ;
        }
    }
}
