using EStoore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.Interfaces
{
    public interface IMaterialService : IDisposable
    {
        Task<Material> Add(Material entity);
        Task<IEnumerable<Material>> GetAll();
        Task<Material> GetById(int id);
        Task<Material> Update(Material entity);
        Task<bool> Remove(Material entity);
        Task<IEnumerable<Material>> Search(string name);
        Task<IEnumerable<Material>> GetMaterialsBySupplier(int supplierId);
        Task<IEnumerable<Material>> SerachMaterialsWithSupplier(string query);
    }
}
