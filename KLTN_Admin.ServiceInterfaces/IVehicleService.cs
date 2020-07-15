using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IVehicleService
    {
        List<VehicleShareModel> GetListVehicle(string adminId);

        VehicleDetailSharedModel GetVehicleById(string vehicleId);

        bool CreateVehicle(VehicleShareModel vehicle);

        bool EditVehicle(VehicleShareModel vehicle);

        bool DeleteVehicle(string vehicleId);

        bool AddVehicleAndSeatMap(VehicleAddSharedModel data, List<(int, string)> seatMap);

        MapSharedModel GetMapByAgentAndVehicleType(string agentId, string vehicleType);
    }
}
