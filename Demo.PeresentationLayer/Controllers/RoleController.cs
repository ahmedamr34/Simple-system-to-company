using Demo.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using Demo.PeresentationLayer.Models;

namespace Demo.PeresentationLayer.Controllers
{
    public class RoleController : Controller
    {
        //property
        private readonly RoleManager<IdentityRole> _roleManager;

        //constructor
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        ////Actions


        ////Index
        public async Task<IActionResult> Index(string SearchValue)
        {
            var Roles = Enumerable.Empty<IdentityRole>().ToList();

            if (string.IsNullOrEmpty(SearchValue))
                Roles.AddRange(_roleManager.Roles);
            else
                Roles.Add(await _roleManager.FindByNameAsync(SearchValue));

            return View(Roles);
        }


        ////Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(Role);
                TempData["Message"] = "Employee Created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(Role);
        }




        ////Details
        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(ViewName, role);
        }



        ////Edit
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, IdentityRole UpdatedRole)
        {
            if (id != UpdatedRole.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {

                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    role.Name=UpdatedRole.Name;
             

                    await _roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(UpdatedRole);
                }
            }
            return View(UpdatedRole);
        }



        ////Delete
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IdentityRole DeletedRole)
        {
            if (id != DeletedRole.Id)
                return BadRequest();
            try
            {
                var role = await _roleManager.FindByIdAsync(id);

                await _roleManager.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(DeletedRole);
            }

        }


    }
}
