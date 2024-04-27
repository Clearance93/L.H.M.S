using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class ITController : Controller
    {
        private readonly IITRepository _it;
        private readonly IWebHostEnvironment _environment;

        public ITController(IITRepository it, IWebHostEnvironment environment)
        {
            _it = it;
            _environment = environment;
        }
        [Authorize(Roles = "IT")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<IT> it = _it.GetAll();
            return View(it);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IT it = _it.GetById(id);
            return View(it);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ITId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] IT it)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\IT\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            it.Image = @"\Images\IT\" + fileName + extention;

            _it.Create(it);
            TempData["success"] = "IT was added successfully to database";
            return RedirectToAction("Index");
        }

        // GET: AdminController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IT it = _it.GetById(id);
            return View(it);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ITId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] IT it)
        {
            if (id != it.ITId)
            {
                return NotFound();
            }

            it = _it.Update(it);
            TempData["success"] = "IT was updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IT it = _it.GetById(id);
            return View(it);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IT it)
        {
            it = _it.Delete(it);
            return RedirectToAction(nameof(Index));
        }
    }
}
