using Demo.DataAccessLayer.Entities;
using Demo.PeresentationLayer.Helpers;
using Demo.PeresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Demo.PeresentationLayer.Controllers
{

    public class AccountController : Controller
    {
        //Property
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //constructor
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        //Actions

        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    IsAgree = model.IsAgree,
                };
                var Result = await _userManager.CreateAsync(user, model.Password);
                if (Result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in Result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);


            }
            return View(model);
        }

        #endregion


        #region Login

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    bool flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {

                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Password is Not Correct");

                }
                ModelState.AddModelError(string.Empty, "Email is Not Existed");
            }
            return View(model);
        }

        #endregion


        #region Sign Out

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        #endregion


        #region Forget Password

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (User != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPassLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);


                    var email = new Email()
                    {
                        Subject = "Reset Your Password",
                        To = model.Email,
                        Body = resetPassLink
                    };
                    EmailSettings.Send(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
                ModelState.AddModelError(string.Empty, "Email is Not Existed");
            }
            return View(model);
        }


        #endregion


        #region CheckYourInbox
        public IActionResult CheckYourInbox()
        {
            return View();
        }

        #endregion


        #region ResetPassword

        public IActionResult ResetPassword(string email, string token)
        {
            TempData["token"] = token;
            TempData["email"] = email;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string email = TempData["email"] as string;
                string token = TempData["token"] as string;

                var user = await _userManager.FindByEmailAsync(email);


                var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        #endregion


    }
}
