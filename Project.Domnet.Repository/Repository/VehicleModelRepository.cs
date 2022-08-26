using Microsoft.EntityFrameworkCore;
using ProjectDomnet.Common;
using ProjectDomnet.Repository.Repository.IRepository;
using ProjectDomnet.DAL.Data;
using ProjectDomnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Repository.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ProjectDbContext _db;
        public VehicleModelRepository(ProjectDbContext db)
        {
            _db = db;
        }
        public async Task CreateModel(VehicleModel entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteModel(VehicleModel entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditModel(VehicleModel entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<VehicleModel>> GetAll()
        {
            return await _db.VehicleModels.ToListAsync();
        }

        public async Task<VehicleModel> GetModelById(int id)
        {
            return await _db.VehicleModels.Include(i=>i.VehicleMake).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<(List<VehicleModel>, int)> VehicleModelPagingAndSorting(PagingSorting pagingSorting)
        {
            IQueryable<VehicleModel> vehicleModels;

            if (!String.IsNullOrEmpty(pagingSorting.PFilter))
                vehicleModels = _db.VehicleModels.Where(a => a.ModelName.Contains(pagingSorting.PFilter)).AsQueryable();
            else
                vehicleModels = _db.VehicleModels.AsQueryable();

            switch (pagingSorting.SOrder)
            {
                case "name":
                    vehicleModels = vehicleModels.OrderBy(a => a.ModelName);
                    break;
                case "abrv":
                    vehicleModels = vehicleModels.OrderBy(a => a.ModelAbrv);
                    break;
                default:
                    vehicleModels = vehicleModels.OrderBy(a => a.ModelName);
                    break;
            }

            int pgCounter = await vehicleModels.CountAsync();
            int totalPages = (int)Math.Ceiling(pgCounter / (double)3);

            if (totalPages > 0)
            {
                totalPages--;
            }
            return (await vehicleModels.Skip(pagingSorting.PSize * (int)pagingSorting.PIndex).Take(pagingSorting.PSize).ToListAsync(), totalPages);
        }
    }
}
