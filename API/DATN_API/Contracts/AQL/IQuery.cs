using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.AQL
{
    public interface IQuery
    {
        Task<TEntity> Add<TEntity>(string database, string table, TEntity doc);
        Task<bool> Update<TEntity>(string database, string table, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
        Task<bool> Delete<TEntity>(string database, string table, FilterDefinition<TEntity> filter);
        Task<List<TEntity>> GetAll<TEntity>(string database, string table, FilterDefinition<TEntity> filter = null, SortDefinition<TEntity> sort = null, int limit = 0);
        Task<List<TEntity>> GetPaging<TEntity>(string database, string table, FilterDefinition<TEntity> filter, FilterDefinition<TEntity> sort, int pageIndex = 1, int pageSize = 10);
        Task<TEntity> GetId<TEntity>(string database, string table, FilterDefinition<TEntity> filter);
        Task<List<TEntity>> GetListById<TEntity>(string database, string table, FilterDefinition<TEntity> filter);
        Task<List<TEntity>> GetByCondition<TEntity>(string database, string table, FilterDefinition<TEntity> filter);
    }
}
