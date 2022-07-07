using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}
