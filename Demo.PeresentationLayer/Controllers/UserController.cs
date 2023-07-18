using Demo.DataAccessLayer.Entities;
using Demo.PeresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Demo.PeresentationLayer.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //property
        private readonly UserManager<ApplicationUser> _userManager;

        //Constructor
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        ////Actions


        ////Index
        public async Task<IActionResult> Index(string SearchValue)
        {
            var Users = Enumerable.Empty<ApplicationUser>().ToList();

            if (string.IsNullOrEmpty(SearchValue))
                Users.AddRange(_userManager.Users);
            else
                Users.Add(await _userManager.FindByEmailAsync(SearchValue));

            return View(Users);
        }



        ////Details
        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var User = await _userManager.FindByIdAsync(id);

            if (User == null)
                return NotFound();

            return View(ViewName, User);
        }



        ////Edit
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, ApplicationUser UpdatedUser)
        {
            if (id != UpdatedUser.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {

                try
                {
                    var user = await _userManager.FindByIdAsync(id);

                    user.UserName = UpdatedUser.UserName;
                    user.PhoneNumber = UpdatedUser.PhoneNumber;


                   await _userManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(UpdatedUser);
                }
            }
            return View(UpdatedUser);
        }



        ////Delete
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, ApplicationUser DeletedUser)
        {
            if (id != DeletedUser.Id)
                return BadRequest();
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                await _userManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(DeletedUser);
            }

        }



    }
}
