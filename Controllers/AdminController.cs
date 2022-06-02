using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _admin;
        private readonly IWebHostEnvironment _environment;

        public AdminController(IAdminRepository admin, IWebHostEnvironment environment)
        {
            _admin = admin;
            _environment = environment;
        }
        [Authorize(Roles ="Admin")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<Admin> admins = _admin.GetAll();
            return View(admins);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Admin admin = _admin.GetById(id);
            return View(admin);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Admin admin)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Admin\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            admin.Image = @"\Images\Admin\" + fileName + extention;

            _admin.Create(admin);
            TempData["success"] = "Admin was added successfully to database";
            return RedirectToAction("Index");
        }

        // GET: AdminController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Admin admin = _admin.GetById(id);
            return View(admin);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Admin admin)
        {
            if (id != admin.AdminId)
            {
                return NotFound();
            }

            admin = _admin.Update(admin);
            TempData["success"] = "Admin was updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin admin = _admin.GetById(id);
            return View(admin);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Admin admin)
        {
            admin = _admin.Delete(admin);
            return RedirectToAction(nameof(Index));
        }
    }
}
