using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string RoleDescriptions { get; set; }    
    }
}
