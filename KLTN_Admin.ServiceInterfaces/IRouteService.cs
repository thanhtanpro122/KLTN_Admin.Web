using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IRouteService
    {
        List<RouteSharedModel> GetListRoute(string adminId);

        RouteSharedModel GetRouteById(string routeId);

        bool CreateRoute(RouteSharedModel route);

        bool EditRoute(RouteSharedModel route);

        bool DeleteRoute(string routeId);

        bool AddRouteDetailAndRouteSchedule(RouteAddSharedModel data);

        List<RouteDepartureSharedModel> GetRouteDepartures(string adminId);

        List<BookingSharedModel> GetBookingsByRouteDepartureId(string routeDepartureId);

        bool PaymentToBookingCode(string bookingCode);

        bool RemoveToBookingCode(string bookingCode);

        bool RemoveToBookingId(string bookingId);
    }
}
