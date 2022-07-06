using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Plans : ClaseBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public int IdCategory { get; set; }
        public Category Category  { get; set; }

    }
}
