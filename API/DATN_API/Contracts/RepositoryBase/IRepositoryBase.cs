using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryBase
{
    public interface IRepositoryBase<TEntity>
    {
        Task<TEntity> Add(string database, string table, TEntity doc);
        Task<bool> Update(string database, string table, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
        Task<bool> Delete<TEntity>(string database, string table, FilterDefinition<TEntity> filter);
        Task<List<TEntity>> GetPaging<TEntity>(string database, string table, FilterDefinition<TEntity> filter, FilterDefinition<TEntity> sort, int pageIndex = 1, int pageSize = 10);
        Task<List<TEntity>> GetAll(string database, string table);
        Task<TEntity> GetId(string database, string table, FilterDefinition<TEntity> filter);
    }
}
