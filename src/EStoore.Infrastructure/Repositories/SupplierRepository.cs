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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository 
    {
        public SupplierRepository(EStooreDbContext context) : base(context) { }

        public async override Task<IEnumerable<Supplier>> GetAll()
        {
            return await Context.Suppliers.AsNoTracking().Include(m => m.Materials)
                .OrderBy(ob => ob.Name)
                .ToListAsync();
        }

        public async override Task<Supplier> GetById(int id)
        {
            return await Context.Suppliers.AsNoTracking().Include(m => m.Materials)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
