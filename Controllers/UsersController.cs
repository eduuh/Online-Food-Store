using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInmanager;
        private readonly UserManager<IdentityUser> _usermanager;

        public UsersController(UserManager<IdentityUser> usermanger)
        {
            _usermanager = usermanger;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<IdentityUser> Get()
        {
            return _usermanager.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IdentityUser Get(string id)
        {
            return _usermanager.Users.FirstOrDefault(p => p.Id == id);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email

                };
                var result = await _usermanager.CreateAsync(newUser, model.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(x => x.Description);
                    return BadRequest(new RegisterResult(){Errors = errors,Successful = false});
                }

            }

            return Ok(new RegisterResult()
            {
                Successful = true
            });
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
