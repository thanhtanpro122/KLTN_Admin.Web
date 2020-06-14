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
    public class RouteController : BaseController
    {
        private readonly IRouteService _routeService;
        private readonly ILocationService _locationService;
        private readonly IVehicleService _vehicleService;
        private readonly IAgentService _agentService;
        private readonly IConstService _constService;

        public RouteController(IRouteService routeService, ILocationService locationService, IVehicleService vehicleService, IAgentService agentService, IConstService constService, IMapper mapper) : base(mapper)
        {
            _routeService = routeService;
            _locationService = locationService;
            _vehicleService = vehicleService;
            _agentService = agentService;
            _constService = constService;
        }
        public IActionResult Index(string agentId, string vehicleId, DateTime startDate, int? page)
        {
            var routes = _mapper.Map<List<RouteViewModel>>(_routeService.GetListRoute());          
            if (agentId != null)
            {
                page = 1;
                routes = routes.Where(x => x.VehicleAgent.Id == agentId).ToList();
            }
            if (vehicleId != null)
            {
                page = 1;
                routes = routes.Where(x => x.Vehicle.Id == vehicleId).ToList();
            }
            var datevalid = new DateTime(0001, 1, 1);
            //if (startDate.Date != datevalid)
            //{
            //    page = 1;
            //    routes = routes.Where(x => x.DepartureDate.Date == startDate.Date).ToList();
            //}
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(routes.ToPagedList(pageNumber, pageSize));
        }

        public JsonResult GetListVehicle()
        {
            var vehicles = _vehicleService.GetListVehicle();
            return Json(vehicles);
        }

        public JsonResult GetListAgent()
        {
            var agents = _agentService.GetAllAgent();
            return Json(agents);
        }

        public JsonResult GetDataVehicleAndListStation(string vehicleId, int order)
        {
            var data = _vehicleService.GetVehicleById(vehicleId);
            if (data == null)
            {
                return Json(null);
            }
            if (order == 2)
            {
                data.Stations = data.Stations.OrderByDescending(e => e.OrderRouteToStation).ToArray();
            }
            else
            {
                data.Stations = data.Stations.OrderBy(e => e.OrderRouteToStation).ToArray();
            }
            
            
            return Json(data);
        }

        public JsonResult GetListLocation()
        {
            var locations= _locationService.GetListLocation();
            return Json(locations);
        }

        [HttpGet]
        public IActionResult NewRoute()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewRoute(RouteAddViewModel route)
        {
            if(route.CheckCorrectRoute == 2)
            {
                route.IsCorrectRoute = false;
            }
            else
            {
                route.IsCorrectRoute = true;
            }

            var checkCreate = _routeService.AddRouteDetailAndRouteSchedule(_mapper.Map<RouteAddSharedModel>(route));
            if (checkCreate)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult Create(RouteAddViewModel route)
        //{
        //    //route.DepartureDate = route.DepartureDate.Date;
        //    //route.Status = 0;
        //    var vehicle = _vehicleService.GetVehicleById(route.VehicleId);
        //    if (vehicle == null)
        //    {
        //        return NotFound();
        //    }

        //    route.StartLocation = new LocationViewModel()
        //    {
        //        Id = vehicle.StartLocation.Id
        //    };
        //    route.EndLocation = new LocationViewModel()
        //    {
        //        Id = vehicle.EndLocation.Id
        //    };
        //    //route.StartLocation.Id = vehicle.StartLocation.Id;
        //    //route.EndLocation.Id = vehicle.EndLocation.Id;
        //    route.Vehicle = new VehicleViewModel()
        //    {
        //        Id = vehicle.Id
        //    };

        //    var listconst = _mapper.Map<List<ConstViewModel>>(_constService.GetListConst());
        //    var constSelect = listconst.FirstOrDefault(e => e.Type == Consts.TrangThaiHanhTrinh && e.Value == ConstValues.TrangThaiHanhTrinh.ChuaDi);

        //    //route.Status = new ConstViewModel()
        //    //{
        //    //    Id = constSelect.Id
        //    //};

        //    var flag = _routeService.CreateRoute(_mapper.Map<RouteSharedModel>(route));
        //    if (!flag)
        //    {
        //        return NotFound();
        //    }
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var route = _mapper.Map<RouteViewModel>(_routeService.GetRouteById(id));
            if (route == null)
            {
                return NotFound();
            }
            //if (route.Vehicle != null)
            //{
            //    var vehicle = _vehicleService.GetVehicleById(route.Vehicle.Id);
            //    //route.NameVehicle = vehicle.Name;
            //    //route.Agent = vehicle.Agent;
            //    //route.LicensePlates = vehicle.LicensePlates;
            //}
            return Json(route);
        }
        [HttpPost]
        public IActionResult Edit(RouteViewModel route)
        {
            //route.DepartureDate = route.DepartureDate.Date;
            var vehicle = _vehicleService.GetVehicleById(route.Vehicle.Id);
            if (vehicle == null)
            {
                return NotFound();
            }
            //route.StartLocation = vehicle.StartLocation;
            //route.EndLocation = vehicle.EndLocation;

            var flag = _routeService.EditRoute(_mapper.Map<RouteSharedModel>(route));
            if (!flag)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var flag = _routeService.DeleteRoute(id);
            if (!flag)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(string id)
        {
            var route = _mapper.Map<RouteViewModel>(_routeService.GetRouteById(id));
            if (route == null)
            {
                return NotFound();
            }

            //var listconst = _mapper.Map<List<ConstViewModel>>(_constService.GetListConst());
            //var constSelect = listconst.FirstOrDefault(e => e.Type == Consts.TrangThaiHanhTrinh && e.Value == ConstValues.TrangThaiHanhTrinh.DaDi);

            //route.Status = constSelect;
            var flag = _routeService.EditRoute(_mapper.Map<RouteSharedModel>(route));
            if (!flag)
            {
                return NotFound();
            }
            //còn làm tiếp bên bảng đặt vé

            return RedirectToAction("Index");
        }
    }
}