using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Addres
    {
        public int Id { get; set; }
        public string Street { get; set; }  //calle
        public string Department { get; set; } //depa
        public string City { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
