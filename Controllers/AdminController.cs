using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
        [Authorize]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        } 
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel userinfo)
        {
            if (!ModelState.IsValid) return View(userinfo);

            var user = new IdentityUser()
            {
                UserName = userinfo.Username,
                Email = userinfo.Email
            };

            var result = await _userManager.CreateAsync(user, userinfo.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Usermanagement", _userManager.Users);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

            return View(userinfo);

        }

        public IActionResult Usermanagement()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return RedirectToAction("Usermanagement", _userManager.Users);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string username, string email)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                user.UserName = username;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Usermanagement", _userManager.Users);
                ModelState.AddModelError("","User not updated, something went wrong");

                return View(user);
            }

            return RedirectToAction("Usermanagement", _userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userid)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userid);
            if (user != null)
            {

                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Usermanagement");
                else
                    ModelState.AddModelError("","Something Went Wrong while Deleting the user");
            }
            else
            {
                ModelState.AddModelError("","This user can't be found");
            }

            return View("UserManagement", _userManager.Users);
        }
        
    }
}