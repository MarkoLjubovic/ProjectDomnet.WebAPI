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
        public async Task CreateModel(VehicleModel entity)
        {
            await _vehicleModelRepository.CreateModel(entity);
        }

        public async Task DeleteModel(VehicleModel entity)
        {
            await _vehicleModelRepository.DeleteModel(entity);
        }

        public async Task EditModel(VehicleModel entity)
        {
            await _vehicleModelRepository.EditModel(entity);
        }

        public async Task<IEnumerable<VehicleModel>> GetAll()
        {
            return await _vehicleModelRepository.GetAll();
        }

        public async Task<VehicleModel> GetModelById(int id)
        {
            return await _vehicleModelRepository.GetModelById(id);
        }

        public async Task<(List<VehicleModel>, int)> VehicleModelPagingSorting(PagingSorting pagingSorting)
        {
            return await _vehicleModelRepository.VehicleModelPagingAndSorting(pagingSorting);
        }
    }
}
