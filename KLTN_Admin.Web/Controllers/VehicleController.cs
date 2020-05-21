using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KLTN_Admin.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace KLTN_Admin.Web.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IAdminService _adminService;

        public VehicleController(IAdminService adminService, IMapper mapper) : base(mapper)
        {
            _adminService = adminService;
        }
    }
}