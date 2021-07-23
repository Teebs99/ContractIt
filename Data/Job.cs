using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        //[ForeignKey(nameof(Contractor))]
        //public int ContractorId { get; set; }
        //public Contractor Contractor { get; set; }
        //[ForeignKey(nameof(Category))]
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}
