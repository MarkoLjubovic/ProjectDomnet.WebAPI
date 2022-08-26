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
        public async Task CreateMake(VehicleMake entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMake(VehicleMake entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditMake(VehicleMake entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<VehicleMake>> GetAll()
        {
            return await _db.VehicleMakes.ToListAsync();
        }

        public async Task<VehicleMake> GetMakeById(int id)
        {
            return await _db.VehicleMakes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<(List<VehicleMake>, int)> VehicleMakePagingAndSorting(PagingSorting pagingSorting)
        {
            IQueryable<VehicleMake> vehicleMakes;

            if (!String.IsNullOrEmpty(pagingSorting.PFilter))
                vehicleMakes=_db.VehicleMakes.Where(a=>a.Name.Contains(pagingSorting.PFilter)).AsQueryable();
            else
                vehicleMakes=_db.VehicleMakes.AsQueryable();

            switch (pagingSorting.SOrder)
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

            int pgCounter=await vehicleMakes.CountAsync();
            int totalPages = (int)Math.Ceiling(pgCounter / (double)3);

            if(totalPages > 0)
            {
                totalPages--;
            }
            return (await vehicleMakes.Skip(pagingSorting.PSize * (int)pagingSorting.PIndex).Take(pagingSorting.PSize).ToListAsync(), totalPages);
        }
    }
}
