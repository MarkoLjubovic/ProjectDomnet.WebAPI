
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
        Task CreateMakeAsync(VehicleMake entity);
        Task DeleteMakeAync(VehicleMake entity);
        Task EditMakeAsync(VehicleMake entity);
        Task<VehicleMake> GetMakeByIdAync(int id);
        Task<(List<VehicleMake>, int)> GetAllAsync(Sorting sorting, Paging paging, Filtering filtering);
    }
}
