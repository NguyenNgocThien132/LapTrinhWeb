using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;

namespace _2001207118_NguyenNgocThien.Identity
{
    public class AppUser :IdentityUser
    {
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}