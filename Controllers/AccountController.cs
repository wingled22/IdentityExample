using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentitySample.Entities;
using IdentitySample.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentitySample.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {

         private UserManager<AppUser> _usrMngr;
        private SignInManager<AppUser> _signInMngr;
        private readonly sampleDbContext _context;
        private readonly ILogger<AccountController> _logger;
        //LMSCContext context,

        public AccountController( sampleDbContext context,
                UserManager<AppUser> usrMngr, SignInManager<AppUser> signInMngr,  ILogger<AccountController> logger)
        {
            _context = context;
            _usrMngr = usrMngr;
            _signInMngr = signInMngr;
            // _mapper = mapper;
            _logger = logger;

        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                if (currentUser.IsInRole("Admin"))
                {
                    _logger.LogInformation("Logged in usertype : ADMIN");

                    return RedirectToAction("Index", "Page", new { area = "Admin" });
                }
                if (currentUser.IsInRole("Student") || currentUser.IsInRole("College") || currentUser.IsInRole("Junior High School") || currentUser.IsInRole("Senior High School"))
                {
                    _logger.LogInformation("Logged in usertype : STUDENT");
                    return RedirectToAction("Index", "StudentSearch", new { area = "Student" });
                }

                if (currentUser.IsInRole("Teacher"))
                {
                    _logger.LogInformation("Logged in usertype : FACULTY");
                    return RedirectToAction("Index", "TeacherSearch", new { area = "Teacher" });
                }

            }

            return View();
        }

    
    }
}