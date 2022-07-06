using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  class Product : ClaseBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int IdPlans { get; set; }
        public Plans Plans { get; set; }
    }
}
