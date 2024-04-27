using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Controllers
{
    public class InCompleteController : Controller
    {
        private readonly IInComplteRepository _file;
        private readonly DatabaseContext _context;
        public InCompleteController(IInComplteRepository file, DatabaseContext context)
        {
            _file = file;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<InComplete> file = _file.GetAll();
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

            InComplete file = _file.GetById(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PatientFirstName,DateOfBirth, BirthId,PatientLastName,ContactNumber,EmailAddress,HomeAddress,PassportNumber,Country,TreeatmentStatus,ReasonForVisitation,DurationOfVisitation,AdmitStatus,Ward_Name,DateOfAdmition,DateOfDischarge,BenefitOfTreatment,RiskOfTreatment,StartOfTreatment,EndOfTreatment,PatientStatus,Infection,Illness,RecoveryChances,RecommendedTreatment,SucessOfRecoveryIftreatmentTaken")] InComplete hos)
        {
            if (id == null)
            {
                return NotFound();
            }
                _file.Update(hos);
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

            InComplete hos = _file.GetById(id);
            return View(hos);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(InComplete hos)
        {
            hos = _file.DeleteById(hos);
            return RedirectToAction(nameof(Index));
        }

    }
}
