using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallRegister.Models
{
    public class Email
    {

        public int Id { get; set; }
        [Display(Name = "Agent Name")]
        public string? Agent { get; set; }
        public DateTime? AllocatedDate { get; set; }
        public DateTime? DateDue { get; set; }
        public DateTime? DateCompleted { get; set; }
        public bool Internal { get; set; }
        public bool Complete { get; set; }
        [Display(Name = "Product Type")]
        public int? ProductsId { get; set; }
        [ForeignKey("ProductsId")]
        public Products? Products { get; set; }

    }
}
