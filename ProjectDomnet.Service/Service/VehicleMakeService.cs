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

        public async Task CreateMake(VehicleMake entity)
        {
            await _vehicleMakeRepository.CreateMake(entity);
        }

        public async Task DeleteMake(VehicleMake entity)
        {
            await _vehicleMakeRepository.DeleteMake(entity);
        }

        public async Task EditMake(VehicleMake entity)
        {
            await _vehicleMakeRepository.EditMake(entity);
        }

        public async Task<IEnumerable<VehicleMake>> GetAll()
        {
            return await _vehicleMakeRepository.GetAll();
        }

        public Task<VehicleMake> GetMakeById(int id)
        {
            return _vehicleMakeRepository.GetMakeById(id);
        }

        public async Task<(List<VehicleMake>, int)> VehicleMakePagingAndSorting(PagingSorting pagingSorting)
        {
            return await _vehicleMakeRepository.VehicleMakePagingAndSorting(pagingSorting);
        }
    }
}
