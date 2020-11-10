using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class IdentityController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public async Task<IActionResult> Signup()
        //{
        //    var model = new SignupViewModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Signup(SignupViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if((await _userManager.FindByNameAsync(model.UserName))== null)
        //        {
        //            var user = new IdentityUser
        //            {
        //                UserName = model.UserName
        //            };
        //            var result = await _userManager.CreateAsync(user,model.Password);

        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Signin");
        //            }
        //            ModelState.AddModelError("Signup", string.Join("", result.Errors.Select(s => s.Description)));
        //            return View(model);
        //        }
        //    }
        //    return View(model);
        //}

        public IActionResult Signin()
        {
            return View(new SigninViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SigninViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Redirect("/");
                }
                ModelState.AddModelError("Login", "Cannot Login");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Signout()
        {
                await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
