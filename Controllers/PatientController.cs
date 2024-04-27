#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicalApp.Data;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using ClinicalApp.Interface;

namespace ClinicalApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMaleWardRepository _male;
        private readonly IPatientRepository _patient;
        private readonly IWebHostEnvironment _environment;
        private readonly IFemaleWardRepository _female;
        private readonly IMetinityWardRepository _metinity;
        private readonly IChronic_DeseaseRepository _hos;

        public PatientController(
         IPatientRepository patient,
         IWebHostEnvironment environment, 
         IMaleWardRepository male,
         IChronic_DeseaseRepository hos,
         IFemaleWardRepository female, 
         IMetinityWardRepository metinity,
         DatabaseContext context)

        {
            _male = male;
            _patient = patient;
            _environment = environment;
            _female = female;  
            _hos = hos;
            _metinity = metinity;
            _context = context; 
        }
        [Authorize(Roles = "Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            List<Patient> patient = _patient.GetAll();
            return View(patient);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = _patient.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,AdmittedFor,RealtionshipToThePatient,FirstName,Address,LastName,HomeAddress,PassportNumber,Country,TreeatmentStatus,P_EmailAddress,WorkEmailAddress,HomeNumber,WorkNumber,CellNo,ReasonForVisitation,DurationOfVisitation,AdmitStatus,Sex,Ethnicity,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")]Patient patient, Patient_In_Hospital hos, ChildrenWard child, ManWard men, FemaleWard female, MetinityWard ward)
        {
            if (patient.AdmitStatus == "Admitted" || patient.AdmitStatus == "admitted")
            {
                _hos.Create(hos);
            }

            if (patient.Sex == "Male" || patient.Sex == "male")
            {
                _male.Create(men);  
            }
            
            //if (patient.Age <= 17)
            //{
            //    _context.ChildrenWards.Add(child);
            //    _context.SaveChanges();
            //}

            if (patient.AdmittedFor == "Pregnancy" || patient.AdmittedFor == "pregnancy")
            {
                _metinity.Create(ward);
            }
            else if (patient.Sex == "Female" || patient.Sex == "female")
            {
                _female.Create(female);
            }


            _patient.Create(patient);
            TempData["success"] = "Patient was created successfully";
            
            return RedirectToAction("Create", "Habit");

            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", patient.DoctorId);
            
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = _patient.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", patient.DoctorId);
            return View(patient);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,AdmittedFor,RealtionshipToThePatient,FirstName,Address,LastName,HomeAddress,PassportNumber,Country,TreeatmentStatus,P_EmailAddress,WorkEmailAddress,HomeNumber,WorkNumber,CellNo,ReasonForVisitation,DurationOfVisitation,AdmitStatus,Sex,Ethnicity,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")] Patient patient, Patient_Of_Hospital hos, InComplete comp)
        {

            if(id != patient.PatientId)
            {
                return NotFound();
            }
            _patient.Update(patient);
            TempData["success"] = "Patient was updated successfully";

            if (patient.TreeatmentStatus == "Incomplete" || patient.TreeatmentStatus == "incomplete")
            {
                _context.InCompletes.Add(comp);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));

            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", patient.DoctorId);
            return View(patient);
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = _patient.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Patient patient)
        {
            _patient.Delete(patient);
            TempData["success"] = "Patient was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
