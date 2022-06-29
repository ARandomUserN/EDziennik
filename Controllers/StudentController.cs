using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDziennik.Models
{
    public class StudentController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StudentController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Index()
        {
            var students = await _userManager.Users.ToListAsync();
            var studentsList = new List<StudentsViewModel>();
            foreach(ApplicationUser user in students)
            {
                var roles = await GetUserRoles(user);
                Console.WriteLine(roles);
                if (roles.Contains("Student"))
                {
                    StudentsViewModel st = new StudentsViewModel();
                    st.UserId = user.Id;
                    st.FirstName = user.FirstName;
                    st.LastName = user.LastName;
                    studentsList.Add(st);
                }
            }
            return View(studentsList);
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}
