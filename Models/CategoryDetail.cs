using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public TypeOfWork JobType { get; set; }
        public double PriceRange { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        
    }
}
