using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.Models.ViewModels
{
    public class AgentVM
    {
        public Agent Agent { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TeamsList { get; set; }

    }
}
