using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Infra.Context;

namespace TruthOrDare.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Attributes
        protected readonly DataContext _context;
        #endregion

        public Repository(DataContext context)
        {
            _context = context;
        }

        public virtual TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual IEnumerable<TEntity> Create(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            var dbSet = _context.Set<TEntity>();

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            entity = dbSet.Remove(entity).Entity;
            _context.SaveChanges();
            return entity;
        }

        public virtual TEntity Delete(Guid id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return entity == null ? null : Delete(entity);
        }

        public virtual TEntity Read(Guid id)
        {
           var entity = _context.Set<TEntity>().Find(id);
           return entity;
        }

        public virtual TEntity Read(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public virtual IEnumerable<TEntity> ReadAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).ToList();
        }


        public IEnumerable<TEntity> Read(int skip, int take, string sort, string sortDir, Expression<Func<TEntity, bool>> filter, ref int records)
        {
            var query = _context.Set<TEntity>().Where(filter).ToList();

            records = query.Count();

            if (records <= 0) return query;

            Func<TEntity, object> selector = p => p.GetType().GetProperty(sort).GetValue(p, null);

            if (sortDir == "DESC")
                return query.OrderByDescending(selector).Skip(((skip < 1 ? 1 : skip) - 1) * take).Take(take).ToList();

            return query.OrderBy(selector).Skip(((skip < 1 ? 1 : skip) - 1) * take).Take(take).ToList();
        }

        public virtual TEntity Where(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter).SingleOrDefault();
        }

        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter).ToList();
        }


        protected virtual IQueryable<TEntity> GetQueryable
        (
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null,
            int? take = null,
            string orderBy = null,
            string includeProps = null,
            bool asNoTracking = true
        )
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = query.OrderBy(x => x.GetType().GetProperty(orderBy).GetValue(0, null));
            }

            if (!string.IsNullOrWhiteSpace(includeProps))
            {
                query = includeProps.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (q, p) => q.Include(p));
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && take.Value > 0)
            {
                query = query.Take(take.Value);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
