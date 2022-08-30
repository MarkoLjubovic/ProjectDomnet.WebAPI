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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly ProjectDbContext _db;
        public VehicleMakeRepository(ProjectDbContext db)
        {
            _db = db;
        }
        public async Task CreateMakeAsync(VehicleMake entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteMakeAync(VehicleMake entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditMakeAsync(VehicleMake entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<VehicleMake> GetMakeByIdAync(int id)
        {
            return await _db.VehicleMakes.FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<(List<VehicleMake>, int)> GetAllAsync(Page page)
        {
            IQueryable<VehicleMake> vehicleMakes;

            if (!String.IsNullOrEmpty(page.PgFilter))
                vehicleMakes = _db.VehicleMakes.Where(a => a.Name.Contains(page.PgFilter)).AsQueryable();
            else
                vehicleMakes = _db.VehicleMakes.AsQueryable();

            switch (page.SortOrder)
            {
                case "name":
                    vehicleMakes = vehicleMakes.OrderBy(a => a.Name);
                    break;
                case "abrv":
                    vehicleMakes = vehicleMakes.OrderBy(a => a.MakeAbrv);
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(a => a.Name);
                    break;
            }

            int pgCounter = await vehicleMakes.CountAsync();
            int totalPages = (int)Math.Ceiling(pgCounter / (double)4);

            if (totalPages > 0)
            {
                totalPages--;
            }
            return (await vehicleMakes.Skip(page.PgSize * (int)page.PgIndex).Take(page.PgSize).ToListAsync(), totalPages);
        }
    }
}
