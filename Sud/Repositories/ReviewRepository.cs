using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Repositories
{
    public class ReviewRepository : IReviewRepository

    {
        private readonly ApplicationDbContext db;
        public ReviewRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<Reviews> Reviews => db.Reviews.Include(x => x.Clothes);
        public void Add(Reviews review)
        {
            db.Reviews.Add(review);
        }

        public IEnumerable<Reviews> GetAll()
        {
            return db.Reviews.ToList();
        }

        public async Task<IEnumerable<Reviews>> GetAllAsync()
        {
            return await db.Reviews.ToListAsync();
        }

        public Reviews GetById(int? id)
        {
            return db.Reviews.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Reviews> GetByIdAsync(int? id)
        {
            return await db.Reviews.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return db.Reviews.Any(p => p.Id == id);
        }

        public void Remove(Reviews review)
        {
            db.Reviews.Remove(review);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Update(Reviews review)
        {
            db.Reviews.Update(review);
        }
    }
}
