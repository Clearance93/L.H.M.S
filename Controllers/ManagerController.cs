using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerRepository _manager;
        private readonly IWebHostEnvironment _environment;

        public ManagerController(IManagerRepository manager, IWebHostEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }
        [Authorize(Roles = "Manager")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<Manager> manager = _manager.GetAll();
            return View(manager);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Manager manager = _manager.GetById(id);
            return View(manager);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManagerId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Manager manager)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Manager\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            manager.Image = @"\Images\Manager\" + fileName + extention;

            _manager.Create(manager);
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

            Manager manager = _manager.GetById(id);
            return View(manager);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManagerId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Manager manager)
        {
            if (id != manager.ManagerId)
            {
                return NotFound();
            }

            manager = _manager.Update(manager);
            TempData["success"] = "Manager was updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manager manager = _manager.GetById(id);
            return View(manager);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Manager manager)
        {
            manager = _manager.Delete(manager);
            return RedirectToAction(nameof(Index));
        }
    }
}
