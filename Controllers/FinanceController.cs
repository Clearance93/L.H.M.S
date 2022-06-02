using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class FinanceController : Controller
    {
        private readonly IFinanceRepository _finance;
        private readonly IWebHostEnvironment _environment;

        public FinanceController(IFinanceRepository finance, IWebHostEnvironment environment)
        {
            _finance = finance;
            _environment = environment;
        }
        [Authorize(Roles = "Finance")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<Finance> finance = _finance.GetAll();
            return View(finance);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Finance finance = _finance.GetById(id);
            return View(finance);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinanceId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Finance finance)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Finance\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            finance.Image = @"\Images\Finance\" + fileName + extention;

            _finance.Create(finance);
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

            Finance finance = _finance.GetById(id);
            return View(finance);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinanceId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Finance finance)
        {
            if (id != finance.FinanceId)
            {
                return NotFound();
            }

            finance = _finance.Update(finance);
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

            Finance finance = _finance.GetById(id);
            return View(finance);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Finance finance)
        {
            finance = _finance.Delete(finance);
            return RedirectToAction(nameof(Index));
        }
    }
}
