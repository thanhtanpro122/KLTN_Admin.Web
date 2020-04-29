using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using KLTN_Admin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KLTN_Admin.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService, IMapper mapper) : base(mapper)
        {
            _adminService = adminService;
        }

        public IActionResult Index(int? page)
        {
            var model = _mapper.Map<List<AdminViewModel>>(_adminService.GetAllAdmins());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult Create(AdminViewModel admin)
        {
            var checkusername = _adminService.CheckUserName(admin.UserName);
            if (checkusername)
            {
                return NotFound();
            }
            admin.Status = 2;

            var flag = _adminService.CreateAdmin(_mapper.Map<AdminSharedModel>(admin));
            if (!flag)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var admin = _mapper.Map<AdminViewModel>(_adminService.GetAdminById(id));
            if (admin == null)
            {
                return NotFound();
            }
            return Json(admin);
        }

        [HttpPost]
        public IActionResult Edit(AdminViewModel admin)
        {
            var checkUpdate = _adminService.EditAdmin(_mapper.Map<AdminSharedModel>(admin));
            if (!checkUpdate)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var CheckDelete = _adminService.DeleteAdmin(id);
            if (!CheckDelete)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}