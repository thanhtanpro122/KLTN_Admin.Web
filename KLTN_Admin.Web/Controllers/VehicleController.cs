﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KLTN_Admin.Web.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService, IMapper mapper) : base(mapper)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index(string searchString, int? page)
        {
            var model = _mapper.Map<List<VehicleViewModel>>(_vehicleService.GetListVehicle());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }
    }
}