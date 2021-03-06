﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TripPlanet.Models;
using TripPlanet.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace TripPlanet.Controllers
{
    public class AccountController : Controller
    {
        private readonly TripPlanetDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TripPlanetDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var thisPlanner = _db.Planners.FirstOrDefault(planner => planner.UserName == User.Identity.Name);
                return View(thisPlanner);
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        public IActionResult Details()
        {
            var thisPlanner = _db.Planners.FirstOrDefault(planner => planner.UserName == User.Identity.Name);
            ViewBag.ThisPlanner = thisPlanner;

            var role = (from r in _db.Roles where r.Name.Contains("admin") select r).FirstOrDefault();
            var users = _db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
            if (users.Find(x => x.Id == thisPlanner.UserId) != null)
            {
                ViewBag.Admin = users;
            }
            return View(thisPlanner);
        }

        public IActionResult RegisterLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string firstName, string lastName, DateTime birthdate, string hometown)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            Planner planner = new Planner(firstName, lastName, birthdate, hometown);
            planner.UserId = user.Id;
            planner.UserName = user.UserName;
            _db.Planners.Add(planner);
            _db.SaveChanges();

            if (result.Succeeded)
            {
                return await RegisterLogin(user, model.Password);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterLogin(ApplicationUser user, string password)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user.Email, password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Trips");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Trips");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }

        //public static async Task<IdentityResult> DeleteUserAccount(UserManager<ApplicationUser> userManager, string userEmail, TripPlanetDbContext context)
        //{
        //    IdentityResult rc = new IdentityResult();

        //    if ((userManager != null) && (userEmail != null) && (context != null))
        //    {
        //        var user = await userManager.FindByEmailAsync(userEmail);
        //        var logins = user.Logins;
        //        var rolesForUser = await userManager.GetRolesAsync(user);

        //        using (var transaction = context.Database.BeginTransaction())
        //        {
        //            foreach (var login in logins.ToList())
        //            {
        //                await userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
        //            }

        //            if (rolesForUser.Count() > 0)
        //            {
        //                foreach (var item in rolesForUser.ToList())
        //                {
        //                    // item should be the name of the role
        //                    var result = await userManager.RemoveFromRoleAsync(user, item);
        //                }
        //            }
        //            rc = await userManager.DeleteAsync(user);
        //            transaction.Commit();
        //        }
        //    }
        //    return rc;
        //}
    }
}