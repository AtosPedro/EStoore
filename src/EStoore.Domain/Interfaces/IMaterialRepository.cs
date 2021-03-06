using EStoore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        new Task<IEnumerable<Material>> GetAll();
        new Task<Material> GetById(int id);
        Task<List<Material>> GetMaterialsBySupplier(int supplierId);
        Task<List<Material>> SerachMaterialsWithSupplier(string query);
    }
}
