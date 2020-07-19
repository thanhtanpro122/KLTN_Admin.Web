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
        private readonly IAgentService _agentService;

        public DashboardController(IAdminService adminService,IAgentService agentService, IMapper mapper) : base(mapper)
        {
            _adminService = adminService;
            _agentService = agentService;
        }
        public IActionResult Index()
        {
            if (String.IsNullOrWhiteSpace(Request.Cookies["AdminId"]))
            {
                return NotFound();
            }
            ViewBag.Agent = _mapper.Map<List<AgentViewModel>>(_agentService.GetAllAgent(Request.Cookies["AdminId"]));
            return View();
        }
        public IActionResult ThongKe(string agentId, DateTime fromdate, DateTime todate)
        {
            return Json(null);
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
            if (data == null || string.IsNullOrEmpty(data[0]))
            {
                ViewBag.LoginMessage = "Invalid username or password";
                return View();
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
            Response.Cookies.Append("isRootAdmin", data[2], options);
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
            var adminId = Request.Cookies["AdminId"];
            if (string.IsNullOrWhiteSpace(adminId))
            {
                return Json(new { status = 401 });
            }
            var flag = _adminService.ChangePassword(adminId, passold, passnew);
            if (!flag)
            {
                return Json(new { status = 200 });
            }
            return Json(new { status = 204 });
        }

    }
}