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
        private readonly IAgentService _agentService;

        public AdminController(IAdminService adminService, IAgentService agentService, IMapper mapper) : base(mapper)
        {
            _adminService = adminService;
            _agentService = agentService;
        }

        public IActionResult Index(string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            var model = _mapper.Map<List<AdminViewModel>>(_adminService.GetAllAdmins());
            var adminLogin = model.FirstOrDefault(e => e.Id == Request.Cookies["AdminId"]);
            if (adminLogin != null)
            {
                model.Remove(adminLogin);
            }
            var listManagement = _mapper.Map<List<ManagementViewModel>>(_adminService.GetAllManagement());
            foreach (var item in model)
            {
                var agentNames = new List<string>();
                var agentRoot = new List<string>();

                foreach(var management in listManagement)
                {
                    if(item.Id == management.AdminId)
                    {
                        agentNames.Add(management.AgentName);
                        if (management.Isroot)
                        {
                            agentRoot.Add(management.AgentName);
                        }
                    }
                }

                item.AgentName = agentNames.ToArray();
                item.RootAgent = agentRoot.ToArray();
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.UserName.Contains(searchString)).ToList();
            }
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
            admin.AdminType = 1;

            var adminNew = _adminService.CreateAdmin(_mapper.Map<AdminSharedModel>(admin));
            if (adminNew == null)
            {
                return NotFound();
            }

            foreach(var item in admin.AgentId)
            {
                var management = new ManagementViewModel()
                {
                    AgentId = item,
                    IsCreator = Request.Cookies["AdminId"],
                    Isroot = false,
                    AdminId = adminNew.Id
                };
                foreach(var isroot in admin.IsRoot)
                {
                    if (item == isroot)
                    {
                        management.Isroot = true;
                    }
                    var flag = _adminService.CreateManagement(_mapper.Map<ManagementSharedModel>(management));
                    if (!flag)
                    {
                        return NotFound();
                    }
                }
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
            var agentNames = new List<string>();
            var agentRoot = new List<string>();
            var listManagement = _mapper.Map<List<ManagementViewModel>>(_adminService.GetManagementByAdminId(admin.Id));
            if (listManagement != null)
            {
                foreach (var management in listManagement)
                {
                    //var agent = _mapper.Map<AgentViewModel>(_agentService.GetAgentById(management.Agent));
                    if (management.Isroot)
                    {
                        agentRoot.Add(management.AgentName);
                    }
                    agentNames.Add(management.AgentName);
                }
            }
            admin.AgentName = agentNames.ToArray();
            admin.RootAgent = agentRoot.ToArray();
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

        public IActionResult SpecifyAgent(AgentForAdminViewModel model)
        {
            var addedAgent = _agentService.CreateAgent(_mapper.Map<AgentSharedModel>(model));
            var agentNew = _mapper.Map<AgentViewModel>(addedAgent);
            if (agentNew == null)
            {
                return Json(null);
            }
            return Json(new { agentNew, isRoot = model.AsRoot });
        }

        public IActionResult LoadPartialSelectAgent()
        {
            var model = _mapper.Map<List<AgentViewModel>>(_agentService.GetAllAgent());

            return PartialView("Partials/_SelectAgent", model);
        }
    }
}