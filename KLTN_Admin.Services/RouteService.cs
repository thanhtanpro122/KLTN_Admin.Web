using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.Services
{
    public class RouteService : ServiceBase, IRouteService
    {
        public RouteService() : base()
        {

        }

        public bool CreateRoute(RouteSharedModel route)
        {
            var request = new RestRequest("/route", Method.POST, DataFormat.Json);
            request.AddJsonBody(route);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool DeleteRoute(string routeId)
        {
            var request = new RestRequest("/route/{route_id}", Method.DELETE);
            request.AddUrlSegment("route_id", routeId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool EditRoute(RouteSharedModel route)
        {
            var request = new RestRequest("/route/{route_id}", Method.PATCH, DataFormat.Json);
            request.AddJsonBody(route);
            request.AddUrlSegment("route_id", route.Id);
            var response = _client.Execute(request);
            var statusCode = response.StatusCode;
            if ((int)statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public List<RouteSharedModel> GetListRoute()
        {
            var request = new RestRequest("/route", Method.GET);
            return _client.Execute<List<RouteSharedModel>>(request).Data;
        }

        public RouteSharedModel GetRouteById(string routeId)
        {
            var request = new RestRequest("/route/{route_id}", Method.GET);
            request.AddUrlSegment("route_id", routeId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<RouteSharedModel>(response.Content);
        }
    }
}
