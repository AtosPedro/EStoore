using EStoore.Domain.Entities;
using EStoore.Domain.Interfaces;
using EStoore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Infrastructure.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(EStooreDbContext context) : base(context) { }

        public async override Task<IEnumerable<Material>> GetAll()
        {
            return await Context.Materials.AsNoTracking().Include(m => m.Supplier)
                .OrderBy(ob => ob.Name)
                .ToListAsync();
        }

        public async override Task<Material> GetById(int id)
        {
            return await Context.Materials.AsNoTracking().Include(m => m.Supplier)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Material>> GetMaterialsBySupplier(int supplierId)
        {
            return await Context.Materials.AsNoTracking()
                .Where(m => m.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task<List<Material>> SerachMaterialsWithSupplier(string query)
        {
            return await Context.Materials.AsNoTracking()
                .Include(m => m.Supplier)
                .Where(m => m.Name == query ||
                        m.Description == query ||
                        m.Code == query ||
                        m.FiscalCode == query)
                .ToListAsync();
        }
    }
}
