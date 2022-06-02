using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class P_HospitalController : Controller
    {
        private readonly IPatient_of_HospitalRepository _hos;
        public P_HospitalController(IPatient_of_HospitalRepository hos)
        {
            _hos = hos;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Patient_Of_Hospital> file = _hos.GetAll();
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

            Patient_Of_Hospital hos = _hos.GetById(id);
            if (hos == null)
            {
                return NotFound();
            }
            return View(hos);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,HomeAddress,PassportNumber,Country,ReasonForVisitation,TreeatmentStatus,DurationOfVisitation,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")] Patient_Of_Hospital hos)
        {

            if (id != hos.id)
            {
                return NotFound();
            }

            _hos.Update(hos);
            TempData["success"] = "Patient was updated successfully";

            return RedirectToAction(nameof(Index));

            return View(hos);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient_Of_Hospital hos = _hos.GetById(id);
            return View(hos);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Patient_Of_Hospital hos)
        {
            hos = _hos.Delete(hos);
            return RedirectToAction(nameof(Index));
        }
    }
}
