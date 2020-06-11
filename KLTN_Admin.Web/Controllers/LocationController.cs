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
    public class LocationController : BaseController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService, IMapper mapper) : base(mapper)
        {
            _locationService = locationService;
        }

        public IActionResult Index(int? page, string searchString)
        {
            var model = _mapper.Map<List<LocationViewModel>>(_locationService.GetListLocation());

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.searchString = searchString;
                page = 1;
                model = model.Where(s => s.Address.Contains(searchString)).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult Create(LocationViewModel location)
        {
            var checkcreateLocation = _locationService.CreateLocation(_mapper.Map<LocationSharedModel>(location));
            if (!checkcreateLocation)
            {
                ViewBag.Message = "Địa chỉ đã có trong Database";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var CheckDelete = _locationService.DeleteLocation(id);
            if (!CheckDelete)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}