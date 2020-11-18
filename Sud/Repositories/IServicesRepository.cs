using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Repositories
{
    public interface IServicesRepository
    {
        IEnumerable<Services> Services { get; }
        Services GetById(int? id);
        Task<Services> GetByIdAsync(int? id);
        bool Exists(int id);
        IEnumerable<Services> GetAll();
        Task<IEnumerable<Services>> GetAllAsync();
        void Add(Services services);
        void Update(Services services);
        void Remove(Services services);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
