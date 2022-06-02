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
    public class MedicationController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMedicationRepository _meds;

        public MedicationController(DatabaseContext context, IMedicationRepository meds)
        {
            _context = context;
            _meds = meds;
        }
        [Authorize(Roles = "Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            List<Medications> meds = _meds.GetAll();
            return View(meds);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medications meds = _meds.GetById(id);
            if (meds == null)
            {
                return NotFound();
            }

            return View(meds);
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
        public async Task<IActionResult> Create([Bind("MedicationId,DoctorId,PatientId,MedicationName,TypeOfMedication,Symptoms,MedicationFor,StartTime,DurationOfMedication")] Medications meds)
        {

            _meds.Create(meds);
            //TempData["success"] = "Prescription was created successfully";
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Create", "TretmentHistory");

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", meds.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", meds.PatientId);
            //return RedirectToAction("Create", "TreatmentHistory");
        }
        [Authorize(Roles = ("Admin, Doctor"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medications meds = _meds.GetById(id);
            if (meds == null)
            {
                return NotFound();
            }
            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", meds.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", meds.PatientId);
            return View(meds);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicationId,DoctorId,PatientId,MedicationName,TypeOfMedication,Symptoms,MedicationFor,StartTime,DurationOfMedication")] Medications meds)
        {
            if (id != meds.MedicationId)
            {
                return NotFound();
            }


            _meds.Update(meds);
            //TempData["success"] = "Prescription was updated successfully";

            return RedirectToAction(nameof(Index));

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", meds.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", meds.MedicationId);
            return View(meds);
        }
        [Authorize(Roles = ("Admin, Doctor"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medications meds = _meds.GetById(id);
            if (meds == null)
            {
                return NotFound();
            }

            return View(meds);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Medications meds)
        {
            meds = _meds.Delete(meds);
            //TempData["success"] = "Prescription was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
