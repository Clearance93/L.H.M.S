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
    public class MedicalRecordsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMedicalRecordsRepository _rec;

        public MedicalRecordsController(DatabaseContext context, IMedicalRecordsRepository rec)
        {
            _context = context;
            _rec = rec;
        }
        [Authorize(Roles = "Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            List<MedicalRecord> rec = _rec.GetAll();
            return View(rec);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalRecord rec = _rec.GetById(id);
            if (rec == null)
            {
                return NotFound();
            }

            return View(rec);
        }

        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalId,DoctorId,PatientId,PresentDiagnisis,PastDiagnosis,MedicalCare,Treatment,Allegies")] MedicalRecord rec)
        {

            _rec.Create(rec);
            //TempData["success"] = "Prescription was created successfully";
            return RedirectToAction("Create", "Medication");

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", rec.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", rec.PatientId);
            
        }
        [Authorize(Roles = ("Admin, Doctor"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalRecord rec = _rec.GetById(id);
            if (rec == null)
            {
                return NotFound();
            }
            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", rec.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", rec.PatientId);
            return View(rec);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalId,DoctorId,PatientId,PresentDiagnisis,PastDiagnosis,MedicalCare,Treatment,Allegies")] MedicalRecord rec)
        {
            if (id != rec.MedicalId)
            {
                return NotFound();
            }


            _rec.Update(rec);
            //TempData["success"] = "Prescription was updated successfully";

            return RedirectToAction(nameof(Index));

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", rec.MedicalId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", rec.MedicalId);
            return View(rec);
        }
        [Authorize(Roles = ("Admin, Doctor"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalRecord rec = _rec.GetById(id);
            if (rec == null)
            {
                return NotFound();
            }

            return View(rec);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(MedicalRecord rec)
        {
            rec = _rec.Delete(rec);
            //TempData["success"] = "Prescription was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
