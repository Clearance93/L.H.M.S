using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class ParamedicController : Controller
    {
        private readonly IParamedicRepository _para;
        private readonly IWebHostEnvironment _environment;

        public ParamedicController(IParamedicRepository para, IWebHostEnvironment environment)
        {
            _para = para;
            _environment = environment;
        }
        [Authorize(Roles = "Admin, Paramedic, Doctor")]
        // GET: AdminController1
        public async Task<IActionResult> Index()
        {
            List<Paramedic> paramedics = _para.GetAll();
            return View(paramedics);
        }

        // GET: AdminController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Paramedic para = _para.GetById(id);
            return View(para);
        }

        // GET: AdminController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParamedicId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Paramedic para)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Paramedics\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            para.Image = @"\Images\Paramedics\" + fileName + extention;

            _para.Create(para);
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

            Paramedic para = _para.GetById(id);
            return View(para);
        }

        // POST: AdminController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParamedicId, FirstName, LastName, EmailAddress, HomeAddress, Phonenumber, Image")] Paramedic para)
        {
            if (id != para.ParamedicId)
            {
                return NotFound();
            }

            para = _para.Update(para);
            TempData["success"] = "Paramedic was updated successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Paramedic para = _para.GetById(id);
            return View(para);
        }

        // POST: AdminController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Paramedic para)
        {
            para = _para.Delete(para);
            return RedirectToAction(nameof(Index));
        }
    }
}
