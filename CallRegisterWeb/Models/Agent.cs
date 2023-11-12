using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CallRegisterWeb.Models
{
    public class Agent
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Agent Name")]
        public string Name { get; set; }
        [DisplayName("Agent Team")]
        [MaxLength(30)]
        public string Team { get; set; }
    }
}
