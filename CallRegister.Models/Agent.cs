using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallRegister.Models
{
    public class Agent
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Agent Name")]
        public string? Name { get; set; }
        [DisplayName("Agent Team")]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        [ValidateNever]
        //navigation property
        public Teams Teams { get; set; }
    }
}
