using ClinicalApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Data
{

    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<DoctorPrescription> DoctorPrescriptions { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Paramedic> Paramedics { get; set; }
        public DbSet<Porter> Porters { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<IT> ITs { get; set; }
        public DbSet<Clearner> Clearners { get; set; }
        public DbSet<HR> HRs { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<UserRole> UsersRole { get; set; }
        public DbSet<WorkInformation> WorkInformations { get; set; }
        public DbSet<FinancialInformation> FinancialInformations { get; set; }
        public DbSet<Habits> Habits { get; set; }
        public DbSet<TreatmentHistory> Treatments { get; set; }
        public DbSet<Medications> Medications { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Patient_File> Patient_File { get; set; }
        public DbSet<Chronic_Desease> chronic_Deseases { get; set; }
        public DbSet<Patient_In_Hospital> Patient_In_Hospital { get; set; }
        public DbSet<Patient_Of_Hospital> Patient_Of_Hospital { get; set; }
        public DbSet<InComplete> InCompletes { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<PickUpMedication> PickUpMedications { get; set; }
        public DbSet<MedicationOrderDetails> MedicationOrderDetails { get; set; }
        public DbSet<ChildrenWard> ChildrenWards { get; set; }
        public DbSet<ManWard> ManWards { get; set; }
        public DbSet<FemaleWard> FemaleWards { get; set; }
        public DbSet<MetinityWard> MetinityWards { get; set; }
    }

}
