using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName {  get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
    }
}
