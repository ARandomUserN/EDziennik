using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDziennik.Data;
using EDziennik.Models;
using Microsoft.AspNetCore.Authorization;

namespace EDziennik.Controllers
{
    public class MarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Index(string userId)
        {

            var marks = await (from m in _context.Mark where m.studentId == userId select m).ToListAsync();
            var student = await (from s in _context.Users where s.Id == userId select s).ToListAsync();
            try
            {
                var markView = new MarkView();
                markView.Marks = marks.ToList();
                markView.FirstName = student.Select(n => n.FirstName).First();
                markView.LastName = student.Select(n => n.LastName).First();
                markView.StudentId = student.Select(n => n.Id).First();

                List<MarkView> mkV = new List<MarkView>();
                mkV.Add(markView);
                return View(mkV);
            }
            catch(Exception e)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            

            
        }

        // GET: Marks/Details/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Details(int? id, string userId)
        {
            if (id == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            var mark = await _context.Mark
                .Include(m => m.student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            ViewData["userId"] = userId;
            return View(mark);
        }

        // GET: Marks/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(string userId)
        {
            ViewData["userId"] = userId;
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([Bind("Id,value,description,studentId")] Mark mark)
        {
            if (ModelState.IsValid)
            {

                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { userId = mark.studentId });
            }
            ViewData["studentId"] = new SelectList(_context.Users, "Id", "Id", mark.studentId);
            return RedirectToAction("Index", new { userId = mark.studentId });
        }

        // GET: Marks/Edit/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int? id, string userId)
        {
            if (id == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            ViewData["userId"] = userId;
            ViewData["studentId"] = new SelectList(_context.Users, "Id", "Id", mark.studentId);
            return View();
        }

        [Authorize(Roles = "Teacher")]
        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,value,description,studentId")] Mark mark)
        {
            if (id != mark.Id)
            {
                return RedirectToAction("PageNotFound", "Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
                    {
                        return RedirectToAction("PageNotFound", "Error");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { userId = mark.studentId });
            }
            ViewData["studentId"] = new SelectList(_context.Users, "Id", "Id", mark.studentId);
            return RedirectToAction("Index", new { userId = mark.studentId });
        }
        [Authorize(Roles = "Teacher")]

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int id, string userId)
        {
            
            var mark = await _context.Mark
                .Include(m => m.student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            ViewData["userId"] = userId;
            return View();
        }
        [Authorize(Roles = "Teacher")]
        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Mark.FindAsync(id);
            var st = mark.studentId;
            _context.Mark.Remove(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { userId = st });
        }

        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }
    }
}
