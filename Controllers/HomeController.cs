using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebHomework.Models;


namespace WebHomework.Controllers
{
    public class User
    {
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        public string UserPad { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeSql _employee;

        public HomeController(ILogger<HomeController> logger,IEmployeeSql employee)
        {
            _logger = logger;
            _employee = employee;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserName == "admin" && user.UserPad == "123456")
                {
                    var claims = new[] {
                        new Claim(ClaimTypes.Name, "admin")
                        ,new Claim(ClaimTypes.Role,"admin")
                        };
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme));
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,new AuthenticationProperties { }).Wait();
                    if(claimsPrincipal.Identity.IsAuthenticated)
                        return Redirect("/admin/index");
                }
                else
                {
                    var ems = _employee.GetAllEmployees();
                    foreach (var i in ems)
                    {
                        if (i.UserName == user.UserName && i.Passward == user.UserPad)
                        {
                            var claims = new[] {
                            new Claim(ClaimTypes.Name, i.UserName)
                            ,new Claim(ClaimTypes.Role,"user")
                            ,new Claim(ClaimTypes.Sid,i.EmpId)
                            };
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme));
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimsPrincipal).Wait();
                           if(claimsPrincipal.Identity.IsAuthenticated)
                            return RedirectToAction("index", "user", new { id = i.EmpId })  ;
                        }
                    }
                }
            }
            ModelState.AddModelError("UserName", "用户名或密码错误");
            return View("Login");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(Url.Action("Login", "home"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
