using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TruthOrDare.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> Create(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity Delete(Guid id);
        TEntity Read(Guid id);
        TEntity Read(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> ReadAll(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TEntity> Read(int skip, int take, string sort, string sortDir, Expression<Func<TEntity, bool>> filter, ref int records);

        TEntity Where(Expression<Func<TEntity, bool>> filter);
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    }
}
