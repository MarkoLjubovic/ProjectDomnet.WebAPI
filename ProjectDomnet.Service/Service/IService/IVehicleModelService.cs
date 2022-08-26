using ProjectDomnet.Common;
using ProjectDomnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Service.Service.IService
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> GetAll();
        Task<VehicleModel> GetModelById(int id);
        Task CreateModel(VehicleModel entity);
        Task DeleteModel(VehicleModel entity);
        Task EditModel(VehicleModel entity);
        Task<(List<VehicleModel>, int)> VehicleModelPagingSorting(PagingSorting pagingSorting);
    }
}
