using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.Models
{
    public class Teams
    {
        public int Id { get; set; }
        [DisplayName("Agent Team")]
        [MaxLength(30)]
        public string? Team { get; set; }
    }
}
