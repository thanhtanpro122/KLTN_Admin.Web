﻿using System;
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
            if (String.IsNullOrWhiteSpace(Request.Cookies["AdminId"]))
            {
                return NotFound();
            }
            var model = _mapper.Map<List<VehicleViewModel>>(_vehicleService.GetListVehicle(Request.Cookies["AdminId"]));
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult NewVehicle()
        {
            var addtionalAgentData = _agentService.GetAddtionlAgentData();
            ViewBag.VehicleTypes = addtionalAgentData.VehicleAndOrderTypes.Where(e => e.Type == Consts.LoaiXe);

            if (String.IsNullOrWhiteSpace(Request.Cookies["AdminId"]))
            {
                return NotFound();
            }
            ViewBag.ListAgent = _mapper.Map<List<AgentViewModel>>(_agentService.GetAllAgent(Request.Cookies["AdminId"]));


            return View();
        }

        [HttpGet]
        public IActionResult GetMap(string agentId, string vehicleType)
        {
            if (string.IsNullOrWhiteSpace(agentId) || string.IsNullOrWhiteSpace(vehicleType))
            {
                return BadRequest();
            }

            var map = _vehicleService.GetMapByAgentAndVehicleType(agentId, vehicleType);
            if (map == null)
            {
                return Json(null);
            }

            var mapViewModel = _mapper.Map<MapViewModel>(map);
            return Json(new 
            { 
                orderType = mapViewModel.OrderType.Value,
                width = mapViewModel.Width,
                height = mapViewModel.Height
            });
        }

        [HttpPost]
        public IActionResult NewVehicle(VehicleAddViewModel data)
        {
            var seatMap = new List<(int, string)>();
            data.IsOnline = false;
            if (!String.IsNullOrEmpty(data.CheckIsOnline))
            {
                data.IsOnline = true;
                foreach (var pair in data.NumberSeats)
                {
                    var temp = pair.Split('-', StringSplitOptions.RemoveEmptyEntries);
                    if (int.TryParse(temp[0], out var index))
                    {
                        if (temp != null && temp.Length == 2)
                        {
                            seatMap.Add((index, temp[1]));
                        }
                        else
                        {
                            seatMap.Add((index, string.Empty));
                        }
                    }
                }
            }
            var check = _vehicleService.AddVehicleAndSeatMap(_mapper.Map<VehicleAddSharedModel>(data), seatMap);
            if (!check)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}