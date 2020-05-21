using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KLTN_Admin.Web.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IAdminService _adminService;
        
        public DashboardController(IAdminService adminService, IMapper mapper) : base(mapper)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            var username = Request.Cookies["Username"];
            var password = Request.Cookies["Password"];
            var isAdmin = Request.Cookies["IsAdmin"];
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return View();
            }

            if(isAdmin == "0")
            {

            }
            else
            {
                var token = _adminService.Signin(username, password);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(AdminViewModel admin)
        {
            var token = _adminService.Signin(admin.UserName, admin.Password);
            if (string.IsNullOrEmpty(token))
            {
                TempData["Mesage"] = "";
                return RedirectToAction("Login");
            }

            var options = new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(15),
                Expires = DateTime.Now.AddDays(15)
            };

            Response.Cookies.Append("UserName", admin.UserName, options);
            Response.Cookies.Append("AdminType", admin.AdminType.ToString(), options);
            Response.Cookies.Append("Token", token, options);

            return RedirectToAction("Index");
        }

    }
}