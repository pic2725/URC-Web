using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;
using URC.Const;
using URC.Models;

namespace URC.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly StudentDB _contextStudent;
        private readonly URCcontext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StudentsController(URCcontext context, StudentDB contextStudent, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _contextStudent = contextStudent;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /*public async Task<IActionResult> Find(string words)
        {
            var students = from s in _context.Students
                           select s;

            if (!String.IsNullOrEmpty(words))
            {
                students = students.Where(s => s.StudentSkills.Contains(words));
            }
            else
            {
                return View(students);
            }

            return View(await students.ToListAsync());
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Find([Bind("words")] string words)
        {
            var students = from s in _contextStudent.Students
                           select s;

            if (words != null)
            {
                var wordList = words.Split(",").Select(e => e.Trim());
                students = students.Where(s => wordList.Contains(s.StudentSkills));
            }

            return Json(students);
        }

        private bool ContainSkills(Student s, string[] wordList)
        {
            foreach (var word in wordList)
            {
                if (s.StudentSkills.Contains(word.Trim()))
                    return true;
            }

            return false;
        }

        [Authorize(Roles = RoleConst.PROFESSOR)]
        public IActionResult Search()
        {
            return View();
        }

        // GET: Students
        [Authorize(Roles = RoleConst.ADMIN + ", " + RoleConst.PROFESSOR)]
        public async Task<IActionResult> Index(string searchString, string searchTarget)
        {
            var students = from m in _contextStudent.Students
                                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchTarget.Equals("UID"))
                {
                    students = students.Where(s => s.Uid.Contains(searchString));
                }
                if (searchTarget.Equals("EMAILADDRESS"))
                {
                    students = students.Where(s => s.EmailAddress.Contains(searchString));
                }
                if (searchTarget.Equals("GPA"))
                {
                    students = students.Where(s => s.GPA >= Int32.Parse(searchString));
                }
                if (searchTarget.Equals("DEGREEPLAN"))
                {
                    students = students.Where(s => s.DegreePlan.Contains(searchString));
                }
                if (searchTarget.Equals("HOURSPERWEEK"))
                {
                    students = students.Where(s => s.HoursPerWeek >= Int32.Parse(searchString));
                }
                if (searchTarget.Equals("SKILLS"))
                {
                    students = students.Where(s => s.StudentSkills.Contains(searchString));
                }
                if (searchTarget.Equals("COMPLETEDCOURSE"))
                {
                    students = students.Where(s => s.StudentCompletedCourses.Contains(searchString));
                }
                if (searchTarget.Equals("INTEREST"))
                {
                    students = students.Where(s => s.StudentInterests.Contains(searchString));
                }
            }

            return View(await students.ToListAsync());
        }

        // GET: Students/Details/5
        [Authorize(Roles = RoleConst.STUDENT + ", " + RoleConst.PROFESSOR)]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _contextStudent.Students
                .FirstOrDefaultAsync(m => m.Uid == id);
            if (student == null)
            {
                return NotFound();
            }

            if (User.IsInRole(RoleConst.PROFESSOR))
            {
                return View(student);
            }

            var user = await _userManager.GetUserAsync(User);
            if (student.EmailAddress.ToUpper() == user.Email.ToUpper())
            {
                return View(student);
            }

            return RedirectToAction("Index");
        }

        // GET: Students/DashBoard
        [Authorize(Roles = RoleConst.STUDENT)]
        public async Task<IActionResult> DashBoard()
        {
            var user = await _userManager.GetUserAsync(User);

            ViewData["AppliedOpportunity"] =  _contextStudent.AppliedOpportunities.Where(s => s.StudentEmail.Contains(user.Email)).ToList();

            return View(await _contextStudent.Students.Where(it => it.EmailAddress.ToUpper() == user.Email.ToUpper()).ToListAsync());
        }

        // GET: Students/StatusWindow
        [Authorize(Roles = RoleConst.ADMIN + ", " + RoleConst.PROFESSOR)]
        public async Task<IActionResult> StatusWindow()
        {
            var user = await _userManager.GetUserAsync(User);
            var students = await _contextStudent.Students.ToListAsync();
            var appliedOpportunities = await _contextStudent.AppliedOpportunities.Where(s => s.ProfessorEmail.Contains(user.Email)).ToListAsync();

            ViewData["AppliedOpportunity"] = appliedOpportunities;

            

            return View();
        }


        // GET: Students/Create
        [Authorize(Roles = RoleConst.STUDENT)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Uid,FirstName,LastName,EmailAddress,PhoneNumber,Resume,DegreePlan,GPA,HoursPerWeek,personalStatement,ExpectedGraduationDate,ApplicationDate,Active,StudentSkills,StudentCompletedCourses,StudentInterests")] Student student)
        {
            if (ModelState.IsValid)
            {
                var time = DateTime.Now;
                student.ApplicationDate = time;

                _contextStudent.Add(student);
                await _contextStudent.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = RoleConst.STUDENT)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _contextStudent.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (student.EmailAddress.ToUpper() == user.Email.ToUpper())
            {
                return View(student);
            }

            return RedirectToAction("Index");
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Uid,FirstName,LastName,EmailAddress,PhoneNumber,Resume,DegreePlan,GPA,HoursPerWeek,personalStatement,ExpectedGraduationDate,ApplicationDate,Active,StudentSkills,StudentCompletedCourses,StudentInterests")] Student student)
        {
            if (id != student.Uid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contextStudent.Update(student);
                    await _contextStudent.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Uid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = RoleConst.STUDENT)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _contextStudent.Students
                .FirstOrDefaultAsync(m => m.Uid == id);
            if (student == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (student.EmailAddress.ToUpper() == user.Email.ToUpper())
            {
                return View(student);
            }

            return RedirectToAction("Index");
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _contextStudent.Students.FindAsync(id);
            _contextStudent.Students.Remove(student);
            await _contextStudent.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _contextStudent.Students.Any(e => e.Uid == id);
        }
    }
}