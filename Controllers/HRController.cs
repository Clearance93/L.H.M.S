using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class HRController : Controller
    {
        private readonly IHRRepository _hr;
        private readonly IWebHostEnvironment _environment;

        public HRController(IHRRepository hr, IWebHostEnvironment environment)
        {
            _hr = hr;
            _environment = environment;
        }
        [Authorize(Roles = "HR")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<HR> hr = _hr.GetAll();
            return View(hr);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HR hr = _hr.GetById(id);
            return View(hr);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HRId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] HR hr)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\HR\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            hr.Image = @"\Images\HR\" + fileName + extention;

            _hr.Create(hr);
            TempData["success"] = "Hr was added successfully to database";
            return RedirectToAction("Index");
        }

        // GET: AdminController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HR hr = _hr.GetById(id);
            return View(hr);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HRId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] HR hr)
        {
            if (id != hr.HRId)
            {
                return NotFound();
            }

            hr = _hr.Update(hr);
            TempData["success"] = "Hr was updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HR hr = _hr.GetById(id);
            return View(hr);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(HR hr)
        {
            hr = _hr.Delete(hr);
            return RedirectToAction(nameof(Index));
        }
    }
}
