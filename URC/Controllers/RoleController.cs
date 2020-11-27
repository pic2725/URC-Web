/**
 *
  Author:    Daniel Pak & Kyungyoon Kim
  Date:      August 28th, 2020
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

  We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents

     RoleController

 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using URC.Const;

namespace URC.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(ILogger<AdminController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //POST: Role/Add/{Username}
        [Authorize(Roles = RoleConst.ADMIN)]
        [HttpPost]
        public async Task<IActionResult> Add(string id, [Bind("newRole")] string newRole)
        {
            /*if (!await _roleManager.RoleExistsAsync(newRole))
                await _roleManager.CreateAsync(new IdentityRole { Name = newRole });*/

            var userIdentity = await _userManager.FindByIdAsync(id);

            if (userIdentity == null)
                return NotFound($"Cannot find user [{id}]");

            var roles = await _userManager.GetRolesAsync(userIdentity);

            if (roles.Contains(newRole))
                return Json("Already has it.");

            return Json(await _userManager.AddToRoleAsync(userIdentity, newRole));
        }

        //DELETE: Role/Add/{Username}
        [Authorize(Roles = RoleConst.ADMIN)]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, [Bind("deleteRole")] string deleteRole)
        {
            var userIdentity = await _userManager.FindByIdAsync(id);

            if (userIdentity == null)
                return NotFound($"Cannot find user [{id}]");

            var roles = await _userManager.GetRolesAsync(userIdentity);

            if (!roles.Contains(deleteRole))
                return Json("Already deleted.");

            return Json(await _userManager.RemoveFromRoleAsync(userIdentity, deleteRole));
        }
    }
}