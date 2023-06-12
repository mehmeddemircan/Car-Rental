
using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess
{
    public interface IBaseRepository<TEntity> where TEntity : class , IEntity , new()
    {

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity ,bool>> filter = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter); 

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
        
        Task<bool> DeleteAsync(int id);


        Task<IEnumerable<TEntity>> GetListAsyncPagination(int pageNumber,int pageSize,Expression<Func<TEntity, bool>> filter = null);  

        TEntity Get(Expression<Func<TEntity, bool>> filter);

    }
}
