#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicalApp.Data;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicalApp.Controllers
{
    public class MedsToBeCollectedController : Controller
    {
        private readonly DatabaseContext _context;

        public MedsToBeCollectedController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<MedsToBeCollected> details = _context.MedssToBeCollected.ToList();
            return View(details);
        }

        // GET: DoctorPrescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var details = await _context.MedssToBeCollected
                .FirstOrDefaultAsync(m => m.MedicId == id);
            if (details == null)
            {
                return NotFound();
            }

            return View(details);
        }

        // GET: DoctorPrescriptions/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientFirstName");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicId,PatientId,Total,PickUpTime,MedsStatus,FullNames,ContactNumber")] MedsToBeCollected collection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(collection);
        }

        // GET: DoctorPrescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorPrescription = await _context.DoctorPrescriptions.FindAsync(id);
            if (doctorPrescription == null)
            {
                return NotFound();
            }
            return View(doctorPrescription);
        }

        // POST: DoctorPrescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorFirstName,DoctorLastName,DoctorEmail,DoctorAddress,DoctorPhoneNumber,DoctorDepartmetment,PatientName,Amount,Frequency")] DoctorPrescription doctorPrescription)
        {
            if (id != doctorPrescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorPrescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorPrescriptionExists(doctorPrescription.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctorPrescription);
        }

        // GET: DoctorPrescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorPrescription = await _context.DoctorPrescriptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorPrescription == null)
            {
                return NotFound();
            }

            return View(doctorPrescription);
        }

        // POST: DoctorPrescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorPrescription = await _context.DoctorPrescriptions.FindAsync(id);
            _context.DoctorPrescriptions.Remove(doctorPrescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorPrescriptionExists(int id)
        {
            return _context.DoctorPrescriptions.Any(e => e.Id == id);
        }
    }
}