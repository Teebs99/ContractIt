using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }
        public TypeOfWork JobType { get; set; }
        public double PriceRange { get; set; }
        public string Description { get; set; }
        

    }
}
