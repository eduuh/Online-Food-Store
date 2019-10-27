using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace PieShop.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Please enter the role name")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public List<string> Users { get; set; }
    }
}