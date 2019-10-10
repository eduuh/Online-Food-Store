using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Feedback
    {
        [Key]
        [BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="Your name is required")]
        public string Name { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="your email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            ErrorMessage ="The email address is not entered in a correct format")]
        public string Email { get; set; }
        [Required]
        [StringLength(4000,ErrorMessage ="The messase is required")]
        public string Message{ get; set; }
        
        
        public bool Contantme { get; set; }
    }
}
