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
    public class FinancialInformationController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IFinancialInformationRepository _finance;

        public FinancialInformationController(DatabaseContext context, IFinancialInformationRepository finance)
        {
            _context = context;
            _finance = finance;
        }
        [Authorize(Roles = "Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            List<FinancialInformation> finance = _finance.GetAll();
            return View(finance);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FinancialInformation finance = _finance.Get(id);
            if(finance == null)
            {
                return NotFound();
            }

            return View(finance);
        }
        [Authorize(Roles ="Admin, Doctor")]
        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinancialInfoId,PatientId,SubscriberName,PhoneNumber,Address,AmountOwe,AmountPayed,MethodOfPayement,RelationShipToThePatient")] FinancialInformation finance)
        {
            //if(finance.AmountOwe == finance.AmountPayed)
            //{
            //    ViewData["payed"] = "Congratulations, you dont have any outstanding🤙🏼!";
            //}
            //else
            //{
            //    ViewData["outstanding"] =finance.AmountOwe - finance.AmountPayed;
            //}


            _finance.Create(finance);
            //TempData["success"] = "Prescription was created successfully";
            return RedirectToAction("Create", "MedicalRecords");

            
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", finance.PatientId);
            
        }
        [Authorize(Roles = ("Admin, Doctor"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FinancialInformation finance = _finance.Get(id);
            if (finance == null)
            {
                return NotFound();
            }

            
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", finance.PatientId);
            return View(finance);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinancialInfoId,PatientId,SubscriberName,PhoneNumber,Address,AmountOwe,AmountPayed,MethodOfPayement,RelationShipToThePatient")] FinancialInformation finance)
        {
            if (id != finance.FinancialInfoId)
            {
                return NotFound();
            }


            _finance.Update(finance);
            //TempData["success"] = "Prescription was updated successfully";

            return RedirectToAction(nameof(Index));

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", finance.FinancialInfoId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", finance.FinancialInfoId);
            return View(finance);
        }
        [Authorize(Roles = ("Admin, Finance"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FinancialInformation finance = _finance.Get(id);
            if (finance == null)
            {
                return NotFound();
            }

            return View(finance);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(FinancialInformation finance)
        {
            finance = _finance.Delete(finance);
            //TempData["success"] = "Prescription was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
