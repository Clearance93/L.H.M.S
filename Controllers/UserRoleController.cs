using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleRepository _user;

        public UserRoleController(IUserRoleRepository user)
        {
            _user = user;
        }

        // GET: UserRoleController
        public async Task<IActionResult> Index()
        {
            List<UserRole> roles = _user.GetAll();
            return View(roles);
        }

        // GET: UserRoleController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            UserRole roles = _user.GetById(id);
            return View(roles);
        }

        // GET: UserRoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRoleController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: UserRoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRoleController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRole role = _user.GetById(id);  
            return View(role);
        }

        // POST: UserRoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, UserRole role)
        {
            role = _user.Delete(role);
            return RedirectToAction(nameof(Index));
        }
    }
}
