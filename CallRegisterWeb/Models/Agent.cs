using System.ComponentModel;

namespace CallRegisterWeb.Models
{
    public class Agent
    {
        public int Id { get; set; }
        [DisplayName("Agent Name")]
        public string Name { get; set; }
        [DisplayName("Agent Team")]
        public string Team { get; set; }
    }
}
