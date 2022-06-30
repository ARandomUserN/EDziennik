using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDziennik.Models
{
    public class Mark
    {
        public int Id { get; set; }
        [Range(1, 6)]
        public int value { get; set; }
        public string description { get; set; }
        public string studentId { get; set; }
        public ApplicationUser student { get; set; }
    }
}
