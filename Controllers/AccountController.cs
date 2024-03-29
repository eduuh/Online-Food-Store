﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInmanager;
        private readonly UserManager<IdentityUser> _usermanager;

        public AccountController(SignInManager<IdentityUser> signInmanager, UserManager<IdentityUser> usermanger)
        {
            _signInmanager = signInmanager;
            _usermanager = usermanger;
        }
    

        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Signup(RegisterViewModel registerviewmodel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = registerviewmodel.Username
                };
                var result = await _usermanager.CreateAsync
                    (user, registerviewmodel.PassWord);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(registerviewmodel);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);
            var user = await
                _usermanager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await
                    _signInmanager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "User name/password not found");
            return View(loginViewModel);

        }

        [HttpPost]
       public async Task<IActionResult> Logout()
        {
            await _signInmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
