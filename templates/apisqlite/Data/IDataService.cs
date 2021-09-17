using System.Linq.Expressions;
using ApiSqlite.Models;

namespace ApiSqlite.Data
{
    public interface IDataService<T> where T : Entity
    {
        Task<T> Add(T item);
        Task<List<T>> Get();
        Task<T?> Get(string id);
        Task<List<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task Delete(T item);
        Task<T> Update(T item);
    }
}