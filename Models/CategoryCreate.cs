using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryCreate
    {
        [Required]
        public TypeOfWork JobType { get; set; }

        [Required]
        public double PriceRange { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Please enter a more vivid description of the job.")]
        [MaxLength(250, ErrorMessage = "Please make the description more concise.")]
        public string Description { get; set; }
        public int ContractorId { get; set; }

    }
}
