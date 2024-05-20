using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        public string UserName {  get; set; }=string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
