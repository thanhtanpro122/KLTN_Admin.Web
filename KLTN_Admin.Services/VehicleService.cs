using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.Services
{
    public class VehicleService : ServiceBase, IVehicleService
    {
        public VehicleService() : base()
        {

        }

        public bool CreateVehicle(VehicleShareModel vehicle)
        {
            throw new NotImplementedException();
        }

        public bool DeleteVehicle(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public bool EditVehicle(VehicleShareModel vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehicleShareModel> GetListVehicle()
        {
            var request = new RestRequest("/vehicle", Method.GET);
            return _client.Execute<List<VehicleShareModel>>(request).Data;
        }

        public VehicleShareModel GetVehicleById(string vehicleId)
        {
            var request = new RestRequest("/vehicle/{vehicle_id}", Method.GET);
            request.AddUrlSegment("vehicle_id", vehicleId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<VehicleShareModel>(response.Content);
        }
    }
}
