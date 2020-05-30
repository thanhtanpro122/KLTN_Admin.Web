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
    public class VehicleController : BaseController
    {
        private readonly IVehicleService _vehicleService;
        private readonly IAgentService _agentService;

        public VehicleController(IVehicleService vehicleService, IAgentService agentService, IMapper mapper) : base(mapper)
        {
            _vehicleService = vehicleService;
            _agentService = agentService;
        }

        public IActionResult Index(string searchString, int? page)
        {
            var model = _mapper.Map<List<VehicleViewModel>>(_vehicleService.GetListVehicle());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult NewVehicle()
        {
            var addtionalAgentData = _agentService.GetAddtionlAgentData();
            ViewBag.VehicleTypes = addtionalAgentData.VehicleAndOrderTypes.Where(e => e.Type == Consts.LoaiXe);

            ViewBag.ListAgent = _mapper.Map<List<AgentViewModel>>(_agentService.GetAllAgent());


            return View();
        }

        [HttpPost]
        public IActionResult NewVehicle(VehicleAddViewModel data)
        {
            var check = _vehicleService.AddVehicleAndSeatMap(_mapper.Map<VehicleAddSharedModel>(data));
            if (!check)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}