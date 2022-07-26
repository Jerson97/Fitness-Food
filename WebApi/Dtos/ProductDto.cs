using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int IdPlans { get; set; }
    }
}
