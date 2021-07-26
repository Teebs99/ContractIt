using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryListItem
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public TypeOfWork JobType { get; set; }

        [Required]
        public double PriceRange { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
