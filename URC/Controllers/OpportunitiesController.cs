/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      Sep 23th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     OpportunitiesController

 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Linq;
using System.Threading.Tasks;
using URC.Const;
using URC.Models;

namespace URC.Controllers
{
    [Authorize]
    public class OpportunitiesController : Controller
    {
        private readonly URCcontext _context;
        private readonly StudentDB _contextStudent;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public OpportunitiesController(URCcontext context, StudentDB contextStudent,  UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _contextStudent = contextStudent;
            _userManager = userManager;
            _roleManager = roleManager;
            
        }

        // GET: Opportunities/Index
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString, string searchTarget, int? page)
        {
            var opportunities = from m in _context.Opportunities
                                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchTarget.Equals("TITLE"))
                {
                    opportunities = opportunities.Where(s => s.ProjectName.Contains(searchString));
                }
                if (searchTarget.Equals("PROFESSOR"))
                {
                    opportunities = opportunities.Where(s => s.ProfessorName.Contains(searchString));
                }
                if (searchTarget.Equals("DEPARTMENT"))
                {
                    opportunities = opportunities.Where(s => s.Department.Contains(searchString));
                }
                if (searchTarget.Equals("DESCRIPTION"))
                {
                    opportunities = opportunities.Where(s => s.Description.Contains(searchString));
                }
            }

            return View(await opportunities.ToListAsync());
        }

        /*public async Task<IActionResult> Index(int? page)
        {
            var pageSize = 4;
            var currentPage = page ?? 1;
            var totalElement = _context.Opportunities.Count();

            var opportunities = from m in _context.Opportunities
                                select m;

            if (!String.IsNullOrEmpty())

                return View(new Paged<Opportunity>(
                    totalElement,
                    Convert.ToInt32(Math.Ceiling((double)totalElement / pageSize)),
                    currentPage,
                    pageSize,
                    await _context.Opportunities.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync()));
        }*/

        // GET: Opportunities/List
        [Authorize(Roles = RoleConst.ADMIN + ", " + RoleConst.PROFESSOR)]
        public async Task<IActionResult> List()
        {
            if (User.IsInRole(RoleConst.ADMIN))
            {
                return View(await _context.Opportunities.ToListAsync());
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);
                return View(await _context.Opportunities.Where(it => it.ProfessorEmail.ToUpper() == user.Email.ToUpper()).ToListAsync());
            }
        }

        // GET: Opportunities/List
        [Authorize(Roles = RoleConst.PROFESSOR)]
        public async Task<IActionResult> DashBoard()
        {
            var user = await _userManager.GetUserAsync(User);

            var opportunity = await _context.Opportunities.Where(s => s.ProfessorName.ToUpper() == user.UserName.ToUpper()).ToListAsync();
            ViewData["Opportunity"] = opportunity;

            var appliedOpportunity = await _contextStudent.AppliedOpportunities.ToListAsync();
            ViewData["AppliedOpportunity"] = appliedOpportunity;

            var pendingList = await _contextStudent.AppliedOpportunities.Where(s => s.ProfessorEmail.Contains(user.Email)).ToListAsync();
            ViewData["PendingList"] = pendingList;

            return View(await _context.Opportunities.Where(it => it.ProfessorEmail.ToUpper() == user.Email.ToUpper()).ToListAsync());
        }

        // GET: Opportunities/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities
                .FirstOrDefaultAsync(m => m.OpportunityID == id);

            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }


        //TODO: send View bag message if the data is already exist
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SetData(int input)
        {

            if (ModelState.IsValid)
            {
                AppliedOpportunity newList = new AppliedOpportunity();

                var opportunity = await _context.Opportunities.FirstOrDefaultAsync(m => m.OpportunityID == input);
                var user = await _userManager.GetUserAsync(User);

                string isEmail = user.Email.ToLower();
                DateTime appliedDate = DateTime.Now;

                
                if(!AppliedOpportunityExists(input, isEmail))
                {

                    newList.OpportunitiyID = opportunity.OpportunityID.ToString();
                    newList.StudentEmail = _contextStudent.Students.Find(isEmail).EmailAddress;
                    newList.AppliedDate = appliedDate;
                    newList.Status = StatusConst.PENDING;
                    newList.OpportunitiyName = opportunity.ProjectName;
                    newList.OpportunityDepartment = opportunity.Department;
                    newList.OpportunityProfessor = opportunity.ProfessorName;
                    newList.ProfessorEmail = opportunity.ProfessorEmail;

                    _contextStudent.AppliedOpportunities.Add(newList);
                    await _contextStudent.SaveChangesAsync();


                    /*ViewBag.modalTitle = "Successfully Applied the Opportunity";
                    ViewBag.modalP = "Please check your status in your DashBoard.";
                    ViewBag.appliedDate = DateTime.Now;*/

                    ViewData["Title"] = "Successfully Applied the Opportunity";
                    ViewData["Body"] = "Please check your status in your DashBoard.";

                }
                else
                {
                    ViewData["Title"] = "Successfully Applied the Opportunity";
                    ViewData["Body"] = "Please check your status in your DashBoard.";

                    /*ViewBag.modalTitle = "ttt";
                    ViewBag.modalP = "ttt";
                    ViewBag.appliedDate = DateTime.Now;*/
                }
                

                
            }

            return RedirectToAction("DashBoard", "Students");
            

        }




        // GET: Opportunities/Create
        [Authorize(Roles = RoleConst.ADMIN + ", " + RoleConst.PROFESSOR)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = RoleConst.ADMIN + ", " + RoleConst.PROFESSOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpportunityID,ProjectName,ProfessorName,ProfessorEmail,Department,Description,AssociatedImag,StudentMentor,BeginningDate,EndDate,Pay,Filled")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        [Authorize(Roles = RoleConst.ADMIN + ", " + RoleConst.PROFESSOR)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities.FindAsync(id);

            if (!User.IsInRole(RoleConst.ADMIN))
            {
                var user = await _userManager.GetUserAsync(User);
                if (opportunity.ProfessorEmail.ToUpper() != user.Email.ToUpper())
                {
                    return RedirectToAction("List");
                }
            }

            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = RoleConst.ADMIN + ", " + RoleConst.PROFESSOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpportunityID,ProjectName,ProfessorName,ProfessorEmail,Department,Description,AssociatedImag,StudentMentor,BeginningDate,EndDate,Pay,Filled")] Opportunity opportunity)
        {
            if (id != opportunity.OpportunityID)
            {
                return NotFound("Cannot find id");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(opportunity.OpportunityID))
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
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        [Authorize(Roles = RoleConst.ADMIN)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities
                .FirstOrDefaultAsync(m => m.OpportunityID == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [Authorize(Roles = RoleConst.ADMIN)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);
            _context.Opportunities.Remove(opportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunities.Any(e => e.OpportunityID == id);
        }

        private bool AppliedOpportunityExists(int id, string email)
        {
            return _contextStudent.AppliedOpportunities.Any(e => e.OpportunitiyID.Contains(id.ToString()) && e.StudentEmail.Contains(email));
        }
    }
}