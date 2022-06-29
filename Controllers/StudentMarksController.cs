using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDziennik.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EDziennik.Models
{
    public class StudentMarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentMarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentMarks
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var marks = await (from m in _context.Mark where m.studentId == userId select m).ToListAsync();
            return View(marks);
        }
    }

}
