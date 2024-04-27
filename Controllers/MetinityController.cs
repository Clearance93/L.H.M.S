using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class MetinityWardController : Controller
    {
        private readonly IMetinityWardRepository _ward;
        public MetinityWardController(IMetinityWardRepository ward)
        {
            _ward = ward;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<MetinityWard> ward = _ward.GetAll();
            return View(ward);
        }

        [Authorize(Roles = ("Admin, Doctor"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MetinityWard ward = _ward.GetById(id);
            if (ward == null)
            {
                return NotFound();
            }
            return View(ward);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,HomeAddress,PassportNumber,Country,ReasonForVisitation,TreeatmentStatus,DurationOfVisitation,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")] MetinityWard ward)
        {

            if (id != ward.MetinityWardId)
            {
                return NotFound();
            }

            _ward.Update(ward);
            TempData["success"] = "Patient was updated successfully";

            return RedirectToAction(nameof(Index));

            return View(ward);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MetinityWard ward = _ward.GetById(id);
            return View(ward);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(MetinityWard ward)
        {
            ward = _ward.Delete(ward);
            return RedirectToAction(nameof(Index));
        }
    }
}
