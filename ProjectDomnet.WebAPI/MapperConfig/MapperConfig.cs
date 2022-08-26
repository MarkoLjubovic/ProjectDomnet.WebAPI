using AutoMapper;
using ProjectDomnet.Models;
using ProjectDomnet.WebAPI.ProjectDtos.VehicleMakeDto;
using ProjectDomnet.WebAPI.ProjectDtos.VehicleModelDto;

namespace ProjectDomnet.WebAPI.MapperConfig
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<VehicleMake, CreateVehicleMake>().ReverseMap();
            CreateMap<VehicleMake, EditVehicleMake>().ReverseMap();
            CreateMap<VehicleModel, CreateVehicleModel>().ReverseMap();
            CreateMap<VehicleModel, EditVehicleModel>().ReverseMap();
        }
    }
}
