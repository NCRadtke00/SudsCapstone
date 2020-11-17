using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Repositories
{
    public class ClotheRepository : IClotheRepository
    {
        private readonly ApplicationDbContext db;
        public ClotheRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<Clothes> Clothes => db.Clothes.Include(p => p.Services).Include(p => p.Reviews); //include here
        public IEnumerable<Clothes> PopularItem => db.Clothes.Where(p => p.IsPopularItem).Include(p => p.Services);
        public void Add(Clothes clothes)
        {
            db.Add(clothes);
        }
        public IEnumerable<Clothes> GetAll()
        {
            return db.Clothes.ToList();
        }
        public async Task<IEnumerable<Clothes>> GetAllAsync()
        {
            return await db.Clothes.ToListAsync();
        }
        public async Task<IEnumerable<Clothes>> GetAllIncludedAsync()
        {
            return await db.Clothes.Include(p => p.Services).Include(p => p.Reviews).ToListAsync();
        }
        public IEnumerable<Clothes> GetAllIncluded()
        {
            return db.Clothes.Include(p => p.Services).Include(p => p.Reviews).ToList();
        }
        public Clothes GetById(int? id)
        {
            return db.Clothes.FirstOrDefault(p => p.Id == id);
        }
        public async Task<Clothes> GetByIdAsync(int? id)
        {
            return await db.Clothes.FirstOrDefaultAsync(p => p.Id == id);
        }
        public Clothes GetByIdIncluded(int? id)
        {
            return db.Clothes.Include(p => p.Services).Include(p => p.Reviews).FirstOrDefault(p => p.Id == id);
        }
        public async Task<Clothes> GetByIdIncludedAsync(int? id)
        {
            return await db.Clothes.Include(p => p.Services).Include(p => p.Reviews).FirstOrDefaultAsync(p => p.Id == id);
        }
        public bool Exists(int id)
        {
            return db.Clothes.Any(p => p.Id == id);
        }
        public void Remove(Clothes clothes)
        {
            db.Remove(clothes);
        }
        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public void Update(Clothes clothes)
        {
            db.Update(clothes);
        }
    }
}
