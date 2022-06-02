using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class CalanderController : Controller
    {
        private readonly IDoctorRespository _doctor;

        public CalanderController(IDoctorRespository doctor)
        {
            _doctor = doctor;
        }
        [Authorize(Roles ="Admin, Doctor")]
        public async Task<IActionResult> Index()
        {
            List<Doctor> doc = _doctor.GetAll();
            return View(doc);
        }
    }
}
