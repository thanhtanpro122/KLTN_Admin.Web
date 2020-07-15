using AutoMapper;
using KLTN_Admin.SharedModels;
using KLTN_Admin.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ProfileMappings
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<AdminSharedModel, AdminViewModel>().ReverseMap();

            CreateMap<LocationSharedModel, LocationViewModel>().ReverseMap();

            CreateMap<RouteSharedModel, RouteViewModel>().ReverseMap();

            CreateMap<AgentSharedModel, AgentViewModel>().ReverseMap();

            CreateMap<ManagementSharedModel, ManagementViewModel>().ReverseMap();

            CreateMap<VehicleShareModel, VehicleViewModel>().ReverseMap();

            CreateMap<ConstSharedModel, ConstViewModel>().ReverseMap();

            CreateMap<AgentAddSharedModel, AgentAddViewModel>().ReverseMap();

            CreateMap<VehicleAddSharedModel, VehicleAddViewModel>().ReverseMap();

            CreateMap<MapSharedModel, MapViewModel>().ReverseMap();

            CreateMap<RouteAddSharedModel, RouteAddViewModel>().ReverseMap();

            CreateMap<RouteDepartureSharedModel, RouteDepartureViewModel>().ReverseMap();

            CreateMap<RouteScheduleSharedModel, RouteScheduleViewModel>().ReverseMap();

            CreateMap<BookingSharedModel, BookingViewModel>().ReverseMap();
        }
    }
}
