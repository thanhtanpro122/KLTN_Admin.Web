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

        public bool AddVehicleAndSeatMap(VehicleAddSharedModel data, List<(int, string)> seatMap)
        {
            var request = new RestRequest("/vehicle/addvehicleandseatmap", Method.POST, DataFormat.Json);
            request.AddJsonBody(new
            {
                VehicleData = data,
                SeatMap = seatMap
            });

            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public MapSharedModel GetMapByAgentAndVehicleType(string agentId, string vehicleType)
        {
            var request = new RestRequest("/mapbyagent", Method.GET);
            request.AddParameter("agentId", agentId);
            request.AddParameter("vehicleType", vehicleType);

            return ExecuteRequest<MapSharedModel>(request);
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

        public List<VehicleShareModel> GetListVehicle(string adminId)
        {
            var request = new RestRequest("/vehicle-by-agent/{admin_id}", Method.GET);
            request.AddUrlSegment("admin_id", adminId);
            return _client.Execute<List<VehicleShareModel>>(request).Data;
        }

        public VehicleDetailSharedModel GetVehicleById(string vehicleId)
        {
            var request = new RestRequest("/vehicle/{vehicle_id}", Method.GET);
            request.AddUrlSegment("vehicle_id", vehicleId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<VehicleDetailSharedModel>(response.Content);
        }
    }
}
