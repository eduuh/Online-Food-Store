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
using Remotion.Linq.Utilities;

namespace PieShop.Controllers
{ 
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private  RoleManager<IdentityUser> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager,RoleManager<IdentityUser> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        } 
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult RoleManagement()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public IActionResult AddNewRole() => View();
        [HttpPost]
        public async Task<IActionResult> AddNewRole (AddRoleViewModel addrole)
        {
            if (!ModelState.IsValid) return View(addrole);

            var newRole = new IdentityRole(){
            Name = addrole.RoleName};


            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }


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