using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseRepository _nurse;
        private readonly IWebHostEnvironment _environment;

        public NurseController(INurseRepository nurse, IWebHostEnvironment environment)
        {
            _nurse = nurse;
            _environment = environment;
        }
        [Authorize(Roles = "Admin, Doctor, Nurse")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<Nurse> nurse = _nurse.GetAll();
            return View(nurse);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Nurse nurse = _nurse.GetById(id);
            return View(nurse);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NurseId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Nurse nurse)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Nurses\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            nurse.Image = @"\Images\Nurses\" + fileName + extention;

            _nurse.Create(nurse);
            TempData["success"] = "Nurse was added successfully to database";
            return RedirectToAction("Index");
        }

        // GET: AdminController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nurse nurse = _nurse.GetById(id);
            return View(nurse);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NurseId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Nurse nurse)
        {
            if (id != nurse.NurseId)
            {
                return NotFound();
            }

            nurse = _nurse.Update(nurse);
            TempData["success"] = "Nurse was updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nurse nurse = _nurse.GetById(id);
            return View(nurse);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Nurse nurse)
        {
            nurse = _nurse.Delete(nurse);
            return RedirectToAction(nameof(Index));
        }
    }
}
