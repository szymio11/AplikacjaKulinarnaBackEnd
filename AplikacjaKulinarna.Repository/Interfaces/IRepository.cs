using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;

namespace AplikacjaKulinarna.Repository.Interfaces
{
    public interface IRepository<T>  where T : BaseEntity   
    {
        Task<bool> Exist(Expression<Func<T, bool>> match);
        Task<T> AddAsyn(T t);
        Task<int> DeleteAsyn(T entity);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsyn();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Guid id);
        Task<int> SaveAsync();
        Task<T> UpdateAsyn(T t, object key);
    }
}