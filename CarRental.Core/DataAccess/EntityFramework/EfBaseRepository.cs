﻿using CarRental.Core.Entities.Abstract;
using CarRental.DataAccess;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.DataAccess.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = new TContext())
            {
                var deletedEntity = await context.Set<TEntity>().FindAsync(id);
                context.Set<TEntity>().Remove(deletedEntity);
                var data = await context.SaveChangesAsync();
                if (data > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsyncPagination(int pageNumber ,int pageSize,Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null ? await context.Set<TEntity>().Skip((pageNumber -1) * pageSize).Take(pageSize).ToListAsync() : await context.Set<TEntity>().Where(filter).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {


                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
