using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class FemaleWardsController : Controller
    {
        private readonly IFemaleWardRepository _female;
        public FemaleWardsController(IFemaleWardRepository female)
        {
            _female = female;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<FemaleWard> female = _female.GetAll();
            return View(female);
        }

        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FemaleWard female = _female.GetById(id);
            if (female == null)
            {
                return NotFound();
            }
            return View(female);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,HomeAddress,PassportNumber,Country,ReasonForVisitation,TreeatmentStatus,DurationOfVisitation,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")] FemaleWard female)
        {

            if (id != female.FemaleWardId)
            {
                return NotFound();
            }

            _female.Update(female);
            TempData["success"] = "Patient was updated successfully";

            return RedirectToAction(nameof(Index));

            return View(female);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FemaleWard female = _female.GetById(id);
            return View(female);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(FemaleWard female)
        {
            female = _female.Delete(female);
            return RedirectToAction(nameof(Index));
        }
    }
}
