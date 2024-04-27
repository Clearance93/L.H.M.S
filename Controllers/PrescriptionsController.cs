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
    public class PrescriptionsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IPrescriptionRepository _prescription;

        public PrescriptionsController(DatabaseContext context, IPrescriptionRepository prescription)
        {
            _context = context;
            _prescription = prescription;
        }
        [Authorize(Roles ="Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
           List<Prescription> prescriptions = _prescription.GetAll();
            return View(prescriptions);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }
            
            return View(prescription);
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
        public async Task<IActionResult> Create([Bind("Id,DoctorId,PatientName,Amount,Frequency")] Prescription prescription)
        {
          
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                TempData["success"] = "Prescription was created successfully";
                return RedirectToAction(nameof(Index));
           
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", prescription.DoctorId);
            return RedirectToAction("Index", "DoctorPrescriptions", prescription);
        }
        [Authorize(Roles =("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", prescription.DoctorId);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PatientName,Amount,Frequency")] Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return NotFound();
            }

               
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Prescription was updated successfully";

            return RedirectToAction(nameof(Index));
            
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", prescription.DoctorId);
            return View(prescription);
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
            TempData["success"] = "Prescription was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescriptions.Any(e => e.Id == id);
        }
    }
}
