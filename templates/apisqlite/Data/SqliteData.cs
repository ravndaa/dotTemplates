using System.Linq.Expressions;
using ApiSqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlite.Data
{
    public class SqliteData<T> : IDataService<T> where T : Entity
    {
        private readonly SqlLiteDbContext _db;
        private readonly DbSet<T> _items;
        public SqliteData(SqlLiteDbContext db)
        {
            _db = db;
            _items = db.Set<T>();
        }
        public async Task<T> Add(T item)
        {
            var res =_items.Add(item);
            await _db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task Delete(T item)
        {
            _items.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<List<T>> Get()
        {
            return await _items.ToListAsync();
        }

        public async Task<T?> Get(string id)
        {
            var idasint = int.Parse(id);
            var res = await _items.FindAsync(idasint);
            return res;
        }

        public async Task<List<T>> GetWhere(Expression<System.Func<T, bool>> predicate)
        {
            return await _items.Where(predicate).ToListAsync();
        }

        public async Task<T> Update(T item)
        {
            var res = _items.Update(item);
            await _db.SaveChangesAsync();
            return res.Entity;
        }
    }
}