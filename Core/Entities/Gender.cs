using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Gender : ClaseBase
    {
        public string Sex { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
