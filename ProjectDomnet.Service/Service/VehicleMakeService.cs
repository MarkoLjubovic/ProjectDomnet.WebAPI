using ProjectDomnet.Common;
using ProjectDomnet.Repository.Repository.IRepository;
using ProjectDomnet.Models;
using ProjectDomnet.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Service.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected readonly IVehicleMakeRepository _vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task CreateMakeAsync(VehicleMake entity)
        {
            await _vehicleMakeRepository.CreateMakeAsync(entity);
        }

        public async Task DeleteMakeAsync(VehicleMake entity)
        {
            await _vehicleMakeRepository.DeleteMakeAync(entity);
        }

        public async Task EditMakeAsync(VehicleMake entity)
        {
            await _vehicleMakeRepository.EditMakeAsync(entity);
        }

        public async Task<(List<VehicleMake>, int)> GetAllAsync(Sorting sorting, Paging paging, Filtering filtering)
        {
            return await _vehicleMakeRepository.GetAllAsync(sorting, paging, filtering);
        }

        public Task<VehicleMake> GetMakeByIdAsync(int id)
        {
            return _vehicleMakeRepository.GetMakeByIdAync(id);
        }

    }
}
