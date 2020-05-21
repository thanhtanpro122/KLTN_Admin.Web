using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.Services
{
    public class LocationService : ServiceBase, ILocationService
    {
        public LocationService() : base()
        {

        }
        public bool CreateLocation(LocationSharedModel location)
        {
            var request = new RestRequest("/location", Method.POST, DataFormat.Json);
            request.AddJsonBody(location);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool DeleteLocation(string locationId)
        {
            var request = new RestRequest("/location/{location_id}", Method.DELETE);
            request.AddUrlSegment("location_id", locationId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool EditLocation(LocationSharedModel location)
        {
            var request = new RestRequest("/location/{location_id}", Method.PATCH, DataFormat.Json);
            request.AddJsonBody(location);
            request.AddUrlSegment("location_id", location.Id);
            var response = _client.Execute(request);
            var statusCode = response.StatusCode;
            if ((int)statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public List<LocationSharedModel> GetListLocation()
        {
            var request = new RestRequest("/location", Method.GET);
            return _client.Execute<List<LocationSharedModel>>(request).Data;
        }

        public LocationSharedModel GetLocationById(string locationId)
        {
            var request = new RestRequest("/location/{location_id}", Method.GET);
            request.AddUrlSegment("location_id", locationId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<LocationSharedModel>(response.Content);
        }
    }
}
