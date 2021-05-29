using GlomilAssesment.Models.ORM.Context;
using GlomilAssesment.Models.ORM.Entities;
using GlomilAssesment.Models.VM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace GlomilAssesment.Controllers
{
    public class LoginController : Controller
    {
        private readonly GlomilContext _context;

        public LoginController(GlomilContext context, IMemoryCache memoryCache)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);


                if (user != null)
                {
                    var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Sid,user.ID.ToString()),
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.UserData , "User")
                };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);



                    _context.SaveChanges();



                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        if (HttpContext.User.Claims.ToArray()[2].Value == "User")
                        {


                            TempData["UserID"] = HttpContext.User.Claims.ToArray()[0].Value;
                            TempData["UserName"] = HttpContext.User.Claims.ToArray()[1].Value;
                        }

                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "E-Mail or Password wrong!";
                    return View();
                }

            }
            else
            {
                return View();
            }


        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserRegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.BornYear = model.BornYear;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "UserLogin");
            }

            return View();


        }
    }
}

