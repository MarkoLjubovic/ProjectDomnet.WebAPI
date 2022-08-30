using Autofac;
using AutoMapper;
using ProjectDomnet.Repository.Repository;
using ProjectDomnet.Repository.Repository.IRepository;
using ProjectDomnet.Service.Service;
using ProjectDomnet.Service.Service.IService;
using ProjectDomnet.WebAPI.MapperConfig;

namespace ProjectDomnet.WebAPI.AutoFacCommon
{
    public class AutoFacCommon:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().SingleInstance();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().SingleInstance();
            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>().SingleInstance();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>().SingleInstance();

            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        }
    }
}
