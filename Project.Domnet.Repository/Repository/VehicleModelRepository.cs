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
        public async Task CreateModelAsync(VehicleModel entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteModelAsync(VehicleModel entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditModelAsync(VehicleModel entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<VehicleModel> GetModelByIdAsync(int id)
        {
            return await _db.VehicleModels.Include(i=>i.VehicleMake).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<(List<VehicleModel>, int)> GetAllAsync(Page page)
        {
            IQueryable<VehicleModel> vehicleModels;

            if (!String.IsNullOrEmpty(page.PgFilter))
                vehicleModels = _db.VehicleModels.Where(a => a.ModelName.Contains(page.PgFilter)).AsQueryable();
            else
                vehicleModels = _db.VehicleModels.AsQueryable();

            switch (page.SortOrder)
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
            int totalPages = (int)Math.Ceiling(pgCounter / (double)4);

            if (totalPages > 0)
            {
                totalPages--;
            }
            return (await vehicleModels.Skip(page.PgSize * (int)page.PgIndex).Take(page.PgSize).ToListAsync(), totalPages);
        }
    }
}
