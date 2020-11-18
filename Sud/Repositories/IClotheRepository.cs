using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sud.Models;

namespace Sud.Repositories
{
    public interface IClotheRepository
    {
        IEnumerable<Clothes> Clothes { get; }
        IEnumerable<Clothes> PopularItem { get; }
        Clothes GetById(int? id);
        Task<Clothes> GetByIdAsync(int? id);
        Clothes GetByIdIncluded(int? id);
        Task<Clothes> GetByIdIncludedAsync(int? id);
        bool Exists(int id);
        IEnumerable<Clothes> GetAll();
        Task<IEnumerable<Clothes>> GetAllAsync();
        IEnumerable<Clothes> GetAllIncluded();
        Task<IEnumerable<Clothes>> GetAllIncludedAsync();
        void Add(Clothes clothes);
        void Update(Clothes clothes);
        void Remove(Clothes clothes);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
