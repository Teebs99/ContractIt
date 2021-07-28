using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum TypeOfWork
    {
        Electrical,
        Plumbing,
        Landscaping,
        Miscellaneous 
    }
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public TypeOfWork JobType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double PriceRange { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        
        [ForeignKey(nameof(Contractor))]
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}
