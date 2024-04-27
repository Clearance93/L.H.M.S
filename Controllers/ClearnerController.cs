using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class ClearnerController : Controller
    {
        private readonly ICleanerRepository _clearner;
        private readonly IWebHostEnvironment _environment;

        public ClearnerController(ICleanerRepository clearner, IWebHostEnvironment environment)
        {
            _clearner = clearner;
            _environment = environment;
        }
        [Authorize(Roles = "Admin, Clearner")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<Clearner> clearner= _clearner.GetAll();
            return View(clearner);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Clearner clearner = _clearner.GetById(id);
            return View(clearner);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClearnerId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image, AgentName, Manager, AgentPhoneNumber, AgentWorkEmail, Address")] Clearner clearner)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Clearner\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            clearner.Image = @"\Images\Clearner\" + fileName + extention;

            _clearner.Create(clearner);
            TempData["success"] = "Admin was added successfully to database";
            return RedirectToAction("Index");
        }

        // GET: AdminController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clearner clearner = _clearner.GetById(id);
            return View(clearner);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CleanerId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image, AgentName, Manager, AgentPhoneNumber, AgentWorkEmail, Address")] Clearner clearner)
        {
            if (id != clearner.CleanerId)
            {
                return NotFound();
            }

            clearner = _clearner.Update(clearner);
            TempData["success"] = "Clearner was updated successfully";
            return RedirectToAction(nameof(Index));
        }


        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clearner clearner = _clearner.GetById(id);
            return View(clearner);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Clearner clearner)
        {
            clearner = _clearner.Delete(clearner);
            return RedirectToAction(nameof(Index));
        }
    }
}
