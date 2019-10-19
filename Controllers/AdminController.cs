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
  [Authorize(Roles = "someotherroles")]
  public class AdminController : Controller
  {
    private UserManager<IdentityUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
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
    public async Task<IActionResult> AddNewRole(AddRoleViewModel addrole)
    {
      if (!ModelState.IsValid) return View(addrole);

      var newRole = new IdentityRole()
      {
        Name = addrole.RoleName
      };


      var result = await _roleManager.CreateAsync(newRole);
      if (result.Succeeded)
        return RedirectToAction("RoleManagement", _roleManager.Roles);
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError("", error.Description);
      }
      return View(addrole);
    }
    public async Task<IActionResult> EditRole(string id){
      var role = await _roleManager.FindByIdAsync(id);
      if(role == null)
        return RedirectToAction("RoleManagement", _roleManager.Roles);
      var editroleviewmodel = new EditRoleViewModel
      {
        Id = role.Id,
        RoleName = role.Name,
        Users = new List<string>()
      };
      foreach(var user in _userManager.Users){
          if(await _userManager.IsInRoleAsync(user,role.Name))
          editroleviewmodel.Users.Add(user.UserName);
      }
      return View(editroleviewmodel);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteRole(string id){
      IdentityRole role = await _roleManager.FindByIdAsync(id);
      if(role != null){
        var result=await _roleManager.DeleteAsync(role);
        if(result.Succeeded)
          return RedirectToAction("RoleManagement", _roleManager.Roles);
          ModelState.AddModelError("","something went wrong while deleting this");
        
      }else{
        ModelState.AddModelError("","This role can't be found");
      }
      return View("RoleManagement",_roleManager.Roles);
    }

    public async Task<IActionResult> AddUserToRole(string roleid){
      var role = await _roleManager.FindByIdAsync(roleid);

      if(role ==null)
         return RedirectToAction("RoleManagement",_roleManager.Roles);

      var adduserTorolemodel = new UserRoleViewModel { Roleid = role.Id };
      foreach(var user in _userManager.Users){
        if(!await _userManager.IsInRoleAsync(user,role.Name)){
          adduserTorolemodel.Users.Add(user);
        }
      }
        return View(adduserTorolemodel);
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
        ModelState.AddModelError("", error.Description);
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
        ModelState.AddModelError("", "User not updated, something went wrong");

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
          ModelState.AddModelError("", "Something Went Wrong while Deleting the user");
      }
      else
      {
        ModelState.AddModelError("", "This user can't be found");
      }

      return View("UserManagement", _userManager.Users);
    }

  }
}