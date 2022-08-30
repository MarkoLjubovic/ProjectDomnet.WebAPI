using ProjectDomnet.Common;
using ProjectDomnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Repository.Repository.IRepository
{
    public interface IVehicleModelRepository
    {
        Task<VehicleModel> GetModelByIdAsync(int id);
        Task CreateModelAsync(VehicleModel entity);
        Task DeleteModelAsync(VehicleModel entity);
        Task EditModelAsync(VehicleModel entity);
        Task<(List<VehicleModel>, int)> GetAllAsync(Page page);
    }
}
