using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class PorterController : Controller
    {
        private readonly IPorterRepository _porter;
        private readonly IWebHostEnvironment _environment;

        public PorterController(IPorterRepository porter, IWebHostEnvironment environment)
        {
            _porter = porter;
            _environment = environment;
        }
        [Authorize(Roles = "Admin, Paramedic, Doctor")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<Porter> porter = _porter.GetAll();
            return View(porter);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Porter porter = _porter.GetById(id);
            return View(porter);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Position, Department, ContractType, DateStarted, StreetName, Surbub, City_Town, ZipCode, Country, Image")] Porter porter)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Porter\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            porter.Image = @"\Images\Porter\" + fileName + extention;

            _porter.Create(porter);
            TempData["success"] = "Porter was added successfully to database";
            return RedirectToAction("Index");
        }

        // GET: AdminController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Porter porter = _porter.GetById(id);
            return View(porter);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName, LastName, Position, Department, ContractType, DateStarted, StreetName, Surbub, City_Town, ZipCode, Country, Image")] Porter porter)
        {
            if (id != porter.Id)
            {
                return NotFound();
            }

            porter = _porter.Update(porter);
            TempData["success"] = "Porter was updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Porter porter = _porter.GetById(id);
            return View(porter);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Porter porter)
        {
            porter = _porter.Delete(porter);
            return RedirectToAction(nameof(Index));
        }
    }
}
