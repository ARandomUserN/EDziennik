using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDziennik.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int value { get; set; }
        public string description { get; set; }
        public ApplicationUser student { get; set; }
    }
}
