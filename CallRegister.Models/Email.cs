﻿using System.ComponentModel.DataAnnotations;

namespace CallRegister.Models
{
    public class Email
    {

        public int Id { get; set; }
        public string? Agent { get; set; }
        public DateOnly AllocatedDate { get; set; }
        public DateOnly DateDue { get; set; }
        public DateOnly DateCompleted { get; set; }
        public bool Internal { get; set; }
        [Display(Name = "Product Type")]
        public string? ProductType { get; set; }

    }
}
