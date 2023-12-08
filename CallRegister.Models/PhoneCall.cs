using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.Models
{
    public class PhoneCall
    {
        public int Id { get; set; }
        public string? Agent { get; set; }
        public DateOnly AllocatedDate { get; set; }
        public DateOnly DateDue { get; set; }
        public DateOnly DateCompleted { get; set; }
        public bool Internal { get; set; }
        [Display(Name="Product Type")]
        public string? ProductType { get; set; }
    }
}
