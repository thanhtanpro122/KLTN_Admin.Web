using System;
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
    public class OperatingController : BaseController
    {
        private readonly IRouteService _routeService;
        public OperatingController(IRouteService routeService, IMapper mapper) : base(mapper)
        {
            _routeService = routeService;
        }
        public IActionResult Index(string routeId, DateTime startDate,int? page)
        {
            if (String.IsNullOrWhiteSpace(Request.Cookies["AdminId"]))
            {
                return NotFound();
            }
            var routeDepartures = _mapper.Map<List<RouteDepartureViewModel>>(_routeService.GetRouteDepartures(Request.Cookies["AdminId"]));
            if (routeId != null)
            {
                page = 1;
                routeDepartures = routeDepartures.Where(x => x.Route.Id == routeId).ToList();
            }
            var datevalid = new DateTime(0001, 1, 1);
            if (startDate != datevalid)
            {
                page = 1;
                routeDepartures = routeDepartures.Where(x => x.DepartureDate.Date == startDate.Date && x.DepartureDate.Month == startDate.Month && x.DepartureDate.Year == startDate.Year).ToList();
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(routeDepartures.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Payment(string id, string bookingCode, int? page)
        {
            var bookings = _mapper.Map<List<BookingViewModel>>(_routeService.GetBookingsByRouteDepartureId(id));
            if (!String.IsNullOrWhiteSpace(bookingCode))
            {
                page = 1;
                bookings = bookings.Where(x => x.BookingCode == bookingCode).ToList();
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(bookings.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult PaymentToBookingCode(string bookingCode)
        {
            var flag = _routeService.PaymentToBookingCode(bookingCode);
            if (!flag)
            {
                return NotFound();
            }
            return Json(null);
        }

        public IActionResult RemoveToBookingCode(string bookingCode)
        {
            var flag = _routeService.RemoveToBookingCode(bookingCode);
            if (!flag)
            {
                return NotFound();
            }
            return Json(null);
        }

        public IActionResult RemoveToBookingId(string bookingId)
        {
            var flag = _routeService.RemoveToBookingId(bookingId);
            if (!flag)
            {
                return NotFound();
            }
            return Json(null);
        }
    }
}