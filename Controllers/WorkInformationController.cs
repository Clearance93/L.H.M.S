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
    public class WorkInformationController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IWorkInformationRepository _work;

        public WorkInformationController(DatabaseContext context, IWorkInformationRepository work)
        {
            _context = context;
            _work = work;
        }
        [Authorize(Roles = "Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            List<WorkInformation> work = _work.GetAll();
            return View(work);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

           WorkInformation work = _work.GetById(id);    
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
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
        public async Task<IActionResult> Create([Bind("WorkId,PatientId,CompanyName,CompanyAddress,CompanyContactNumber,ManagerName,ManagerEmail,Occupation")] WorkInformation work)
        {

            _work.Create(work);
            //TempData["success"] = "Prescription was created successfully";
            return RedirectToAction("Create", "FinancialInformation");

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", work.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", work.PatientId);
            
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkInformation work = _work.GetById(id);
            if (work == null)
            {
                return NotFound();
            }
            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", work.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", work.PatientId);
            return View(work);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkId,PatientId,CompanyName,CompanyAddress,CompanyContactNumber,ManagerName,ManagerEmail,Occupation")] WorkInformation work)
        {
            if (id != work.WorkId)
            {
                return NotFound();
            }


            _work.Update(work);
            //TempData["success"] = "Prescription was updated successfully";

            return RedirectToAction(nameof(Index));

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", work.WorkId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", work.WorkId);
            return View(work);
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkInformation work = _work.GetById(id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(WorkInformation work)
        {
            work =_work.Delete(work); 
            //TempData["success"] = "Prescription was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
