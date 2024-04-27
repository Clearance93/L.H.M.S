using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicalApp.Controllers
{
    public class PickUpMedsController : Controller
    {

        private readonly IPuckUpMedicationRepository _meds;
        private readonly DatabaseContext _context;

        public PickUpMedsController(IPuckUpMedicationRepository meds, DatabaseContext context)
        {
            _meds = meds;
            _context = context;
        }

        // GET: PickUpMedsController
        public async Task<IActionResult> Index()
        {
            List<PickUpMedication> meds = _meds.GetAll();
            return View(meds);
        }

        // GET: PickUpMedsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PickUpMedsController/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientFirstName");
            return View();
        }

        // POST: PickUpMedsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedsId,PatientId, MedicationOder, MedicationSubtotal, PickupDate, MediationStatus, Comments, Payment, PatientFullName, CoolectorFullNames, PlhoneNumbers")] PickUpMedication meds)
        {
            _meds.Create(meds);
            return RedirectToAction(nameof(Index));
        }

        // GET: PickUpMedsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            PickUpMedication meds = _meds.GetbyId(id);
            if(meds == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientFirstName", meds.PatientId);
            return View(meds);
        }

        // POST: PickUpMedsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedsId, PatientId, MedicationOder, MedicationSubtotal, PickupDate, MediationStatus, Comments, Payment, PatientFullName, CoolectorFullNames, PlhoneNumbers")] PickUpMedication meds)
        {
            if(id != meds.MedsId)
            {
                return NotFound();
            }

            _meds.Update(meds);
            return RedirectToAction(nameof(Index));
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientFirstName", meds.PatientId);
            return View(meds);
        }
        
        // GET: PickUpMedsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PickUpMedsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
