using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Controllers
{
    public class Chronic_DeseaseController : Controller
    {
        private readonly IChronic_DeseaseRepository _file;
        private readonly DatabaseContext _context;
        public Chronic_DeseaseController(IChronic_DeseaseRepository file, DatabaseContext context)
        {
            _file = file;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Patient_In_Hospital> file = _file.GetAll();
            return View(file);
        }

        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient_In_Hospital file = _file.GetById(id);
            if (file == null)
            {
                return NotFound();
            }
            return View(file);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,HomeAddress,PassportNumber,Country,TreeatmentStatus,ReasonForVisitation,DurationOfVisitation,AdmitStatus,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")]Patient_In_Hospital hos, Patient_Of_Hospital hospital)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (hos.AdmitStatus == "Discharged" || hos.AdmitStatus == "discharged")
            {
                _context.Patient_Of_Hospital.Add(hospital);
                _context.SaveChanges();
            }
            else { 
            _file.Update(hos);
            TempData["success"] = "Patient was updated successfully";
            }

            return RedirectToAction(nameof(Index));
            return View(hos);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient_In_Hospital hos = _file.GetById(id);
            return View(hos);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Patient_In_Hospital hos)
        {
            hos = _file.Delete(hos);
            return RedirectToAction(nameof(Index));
        }

    }
}
