using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IRouteService
    {
        List<RouteSharedModel> GetListRoute();

        RouteSharedModel GetRouteById(string routeId);

        bool CreateRoute(RouteSharedModel route);

        bool EditRoute(RouteSharedModel route);

        bool DeleteRoute(string routeId);
    }
}
