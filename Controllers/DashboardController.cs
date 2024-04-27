using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IPatient_FileRepository _file;

        public DashboardController(IPatient_FileRepository file)
        {
            _file = file;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Patient_File> file = _file.GetAll();
            return View(file);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Patient_File file = _file.GetPatientById(id);
            return View(file);
        }
    }
}
