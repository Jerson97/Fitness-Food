using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string lastname { get; set; }
        public Addres Addres { get; set; }
        public int status { get; set; }
    }
}
