using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDziennik.Models
{
    public class MarkView
    {
        public List<Mark> Marks { get; set; }
        public string FirstName { get; set; }

        public string StudentId { get; set; }
        public string LastName { get; set; }
    }
}
