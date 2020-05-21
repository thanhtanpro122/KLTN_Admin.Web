using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface ILocationService
    {
        List<LocationSharedModel> GetListLocation();

        LocationSharedModel GetLocationById(string locationId);

        bool CreateLocation(LocationSharedModel admin);

        bool EditLocation(LocationSharedModel admin);

        bool DeleteLocation(string locationId);
    }
}
