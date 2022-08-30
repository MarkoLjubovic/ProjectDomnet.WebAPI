using AutoMapper;
using ProjectDomnet.Models;
using ProjectDomnet.WebAPI.ProjectDtos.VehicleMakeDto;
using ProjectDomnet.WebAPI.ProjectDtos.VehicleModelDto;

namespace ProjectDomnet.WebAPI.MapperConfig
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleMake, CreateVehicleMake>().ReverseMap();
            CreateMap<VehicleMake, EditVehicleMake>().ReverseMap();
            CreateMap<VehicleModel, CreateVehicleModel>().ReverseMap();
            CreateMap<VehicleModel, EditVehicleModel>().ReverseMap();
        }
    }
}
