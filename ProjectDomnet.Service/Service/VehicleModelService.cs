using ProjectDomnet.Repository.Repository.IRepository;
using ProjectDomnet.Models;
using ProjectDomnet.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDomnet.Common;

namespace ProjectDomnet.Service.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        protected readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }
        public async Task CreateModelAsync(VehicleModel entity)
        {
            await _vehicleModelRepository.CreateModelAsync(entity);
        }

        public async Task DeleteModelAsync(VehicleModel entity)
        {
            await _vehicleModelRepository.DeleteModelAsync(entity);
        }

        public async Task EditModelAsync(VehicleModel entity)
        {
            await _vehicleModelRepository.EditModelAsync(entity);
        }

        public async Task<VehicleModel> GetModelByIdAsync(int id)
        {
            return await _vehicleModelRepository.GetModelByIdAsync(id);
        }

        public async Task<(List<VehicleModel>, int)> GetAllAsync(Page page)
        {
            return await _vehicleModelRepository.GetAllAsync(page);
        }
    }
}
