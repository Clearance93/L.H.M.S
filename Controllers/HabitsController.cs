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
    public class HabitController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IHabitRepository _habit;

        public HabitController(DatabaseContext context, IHabitRepository habit)
        {
            _context = context;
            _habit = habit;
        }
        [Authorize(Roles = "Admin, Doctor")]
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            List<Habits> habit = _habit.GetAll();
            return View(habit);
        }


        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Habits habit = _habit.Get(id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
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
        public async Task<IActionResult> Create([Bind("HabitsId,PatientId,Smoking,DrugUse_Abuse,Excercise,AlcoholIntake,Diet")] Habits habit)
        {

            _habit.Create(habit);
            //TempData["success"] = "Prescription was created successfully";
            return RedirectToAction("Create", "WorkInformation");

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", habit.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", habit.PatientId);
            
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Habits habit = _habit.Get(id);
            if (habit == null)
            {
                return NotFound();
            }
            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", habit.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", habit.PatientId);
            return View(habit);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitsId,PatientId,Smoking,DrugUse_Abuse,Excercise,AlcoholIntake,Diet")] Habits habit)
        {
            if (id != habit.HabitsId)
            {
                return NotFound();
            }


            _habit.Update(habit);
            //TempData["success"] = "Prescription was updated successfully";

            return RedirectToAction(nameof(Index));

            //ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorFirstName", habit.HabitsId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "EmailAddress", habit.HabitsId);
            return View(habit);
        }
        [Authorize(Roles = ("Admin"))]
        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Habits habit = _habit.Get(id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Habits habit)
        {
            habit = _habit.Delete(habit);
            //TempData["success"] = "Prescription was deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
