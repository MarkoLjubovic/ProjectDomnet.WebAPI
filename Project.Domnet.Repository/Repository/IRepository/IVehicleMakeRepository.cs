
using ProjectDomnet.Common;
using ProjectDomnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Repository.Repository.IRepository
{
    public interface IVehicleMakeRepository
    {
        Task CreateMake(VehicleMake entity);
        Task DeleteMake(VehicleMake entity);
        Task EditMake(VehicleMake entity);
        Task<VehicleMake> GetMakeById(int id);
        Task<IEnumerable<VehicleMake>> GetAll();
        Task<(List<VehicleMake>, int)> VehicleMakePagingAndSorting(PagingSorting pagingSorting);
    }
}
