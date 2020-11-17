using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly ApplicationDbContext db;

        public ServicesRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<Services> Services => db.Services.Include(x => x.Clothes); //include here
        public void Add(Services services)
        {
            db.Add(services);
        }
        public IEnumerable<Services> GetAll()
        {
            return db.Services.ToList();
        }
        public async Task<IEnumerable<Services>> GetAllAsync()
        {
            return await db.Services.ToListAsync();
        }
        public Services GetById(int? id)
        {
            return db.Services.FirstOrDefault(p => p.Id == id);
        }
        public async Task<Services> GetByIdAsync(int? id)
        {
            return await db.Services.FirstOrDefaultAsync(p => p.Id == id);
        }
        public bool Exists(int id)
        {
            return db.Clothes.Any(p => p.Id == id);
        }
        public void Remove(Services services)
        {
            db.Remove(services);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
        public void Update(Services services)
        {
            db.Update(services);
        }
    }
}
