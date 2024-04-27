using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class MaleWardsController : Controller
    {
        private readonly IMaleWardRepository _men;
        public MaleWardsController(IMaleWardRepository men)
        {
            _men = men;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<ManWard> men = _men.GetAll();
            return View(men);
        }

        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ManWard men = _men.GetById(id);
            if (men == null)
            {
                return NotFound();
            }
            return View(men);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,HomeAddress,PassportNumber,Country,ReasonForVisitation,TreeatmentStatus,DurationOfVisitation,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")] ManWard men)
        {

            if (id != men.MenWardId)
            {
                return NotFound();
            }

            _men.Update(men);
            TempData["success"] = "Patient was updated successfully";

            return RedirectToAction(nameof(Index));

            return View(men);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ManWard men = _men.GetById(id);
            return View(men);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ManWard men)
        {
            men = _men.Delete(men);
            return RedirectToAction(nameof(Index));
        }
    }
}
