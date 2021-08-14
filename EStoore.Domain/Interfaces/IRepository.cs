using EStoore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Remove(TEntity entity);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
