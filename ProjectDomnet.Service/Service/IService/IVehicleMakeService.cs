using ProjectDomnet.Common;
using ProjectDomnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Service.Service.IService
{
    public interface IVehicleMakeService
    {
        Task CreateMakeAsync(VehicleMake entity);
        Task DeleteMakeAsync(VehicleMake entity);
        Task EditMakeAsync(VehicleMake entity);
        Task<VehicleMake> GetMakeByIdAsync(int id);
        Task<(List<VehicleMake>, int)> GetAllAsync(Page page);
    }
}
