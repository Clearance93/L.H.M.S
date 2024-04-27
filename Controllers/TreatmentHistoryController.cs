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
    public class TretmentHistoryController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly ITreatmentsRepository _treatment;

        public TretmentHistoryController(DatabaseContext context, ITreatmentsRepository treatment)
        {
            _context = context;
            _treatment = treatment;
        }
        [Authorize(Roles = "Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            List<TreatmentHistory> treatment = _treatment.GetAll();
            return View(treatment);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TreatmentHistory treatment = _treatment.Get(id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            ;
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreatMentHistoryId,DoctorId,PatientId,ChiefComplains,HistoryOfIllenes,VitalSigns,PhysicalExamination,SurgicalHistory,ObstetricHistory,MedicalAllegies,FamilyHistory,ImmunizationHistory,DevelopmentHistory")] TreatmentHistory treatment)
        {

            _treatment.Create(treatment);
            //TempData["success"] = "Prescription was created successfully";
            return RedirectToAction("Index", "DashBoard");

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", treatment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", treatment.PatientId);
            //return RedirectToAction("Index", "DashBoard");
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TreatmentHistory treatment = _treatment.Get(id);
            if (treatment == null)
            {
                return NotFound();
            }
            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", treatment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", treatment.PatientId);
            return View(treatment);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreatMentHistoryId,DoctorId,PatientId,ChiefComplains,HistoryOfIllenes,VitalSigns,PhysicalExamination,SurgicalHistory,ObstetricHistory,MedicalAllegies,FamilyHistory,ImmunizationHistory,DevelopmentHistory")] TreatmentHistory treatment)
        {
            if (id != treatment.TreatMentHistoryId)
            {
                return NotFound();
            }


            _treatment.Update(treatment);
            //TempData["success"] = "Prescription was updated successfully";

            return RedirectToAction(nameof(Index));

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", treatment.TreatMentHistoryId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", treatment.TreatMentHistoryId);
            return View(treatment);
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TreatmentHistory treatment = _treatment.Get(id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TreatmentHistory treatment)
        {
            treatment = _treatment.Delete(treatment);
            //TempData["success"] = "Prescription was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
