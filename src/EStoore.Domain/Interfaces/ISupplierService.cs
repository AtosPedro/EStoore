using EStoore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.Interfaces
{
    public interface ISupplierService : IDisposable
    {
        Task<Supplier> Add(Supplier entity);
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task<Supplier> Update(Supplier entity);
        Task<bool> Remove(Supplier entity);
        Task<IEnumerable<Supplier>> Search(string Name);
    }
}
