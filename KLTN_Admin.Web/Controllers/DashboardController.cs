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
            var username = Request.Cookies["UserName"];
            var adminType = Request.Cookies["AdminType"];
            var adminId = Request.Cookies["AdminId"];
            var token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(adminId) && string.IsNullOrEmpty(token))
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(AdminViewModel admin)
        {
            var data = _adminService.Signin(admin.UserName, admin.Password);
            if (string.IsNullOrEmpty(data[0]))
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
            Response.Cookies.Append("Token", data[0], options);
            Response.Cookies.Append("AdminId", data[1], options);
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("AdminType");
            Response.Cookies.Delete("Token");
            Response.Cookies.Delete("AdminId");
            return RedirectToAction("Login");
        }

        public ActionResult ChangePassword(string passold, string passnew)
        {
            return Json(null);
        }

    }
}