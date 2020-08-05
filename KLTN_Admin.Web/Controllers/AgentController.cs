using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KLTN_Admin.Common.Consts;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using KLTN_Admin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KLTN_Admin.Web.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService, IMapper mapper) : base(mapper)
        {
            _agentService = agentService;
        }
        public IActionResult Index(string searchString, int? page)
        {
            if (String.IsNullOrWhiteSpace(Request.Cookies["AdminId"]))
            {
                return NotFound();
            }
            var model = _mapper.Map<List<AgentViewModel>>(_agentService.GetAllAgent(Request.Cookies["AdminId"]));
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult NewAgent()
        {
            AttachAddtionalDataToView();
            return View();
        }

        [HttpPost]
        public IActionResult NewAgent(AgentAddViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            var flag = _agentService.AddAgentDetail(_mapper.Map<AgentAddSharedModel>(model));
            if (!flag)
            {
                return NotFound();
            }
            //AttachAddtionalDataToView();
            return RedirectToAction("Index");
        }

        private void AttachAddtionalDataToView()
        {
            var addtionalAgentData = _agentService.GetAddtionlAgentData();
            ViewBag.OrderTypes = addtionalAgentData.VehicleAndOrderTypes.Where(e => e.Type == Consts.KieuXepLoaiDanhSo);
            var vehicleTypes = addtionalAgentData.VehicleAndOrderTypes.Where(e => e.Type == Consts.LoaiXe);
            ViewBag.TypeXeThuong = vehicleTypes.FirstOrDefault(e => e.Value == ConstValues.LoaiXe.XeThuong).Id;
            ViewBag.TypeXeGiuong = vehicleTypes.FirstOrDefault(e => e.Value == ConstValues.LoaiXe.XeGiuongNam).Id;

        }
    }
}