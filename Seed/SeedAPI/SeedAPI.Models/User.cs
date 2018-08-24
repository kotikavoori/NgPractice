using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeedAPI.Models
{
    internal class User : IdentityUser
    {
        public string Name { get; set; }
    }
}