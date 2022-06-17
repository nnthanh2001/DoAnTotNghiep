using Contracts.AQL;
using Contracts.RepositoryBase;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.RepositoryBase
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    {
        readonly IQuery query;
        public RepositoryBase(IQuery query)
        {
            this.query = query;
        }
        public Task<TEntity> Add(string database, string table, TEntity doc) => query.Add(database, table, doc);
        public Task<bool> Delete<TEntity1>(string database, string table, FilterDefinition<TEntity1> filter) => query.Delete(database, table, filter);
        public Task<List<TEntity>> GetAll(string database, string table) => query.GetAll<TEntity>(database, table);
        public Task<List<TEntity>> GetPaging<TEntity>(string database, string table, FilterDefinition<TEntity> filter, FilterDefinition<TEntity> sort, int pageIndex = 1, int pageSize = 10) 
            => query.GetPaging<TEntity>(database, table, filter, sort, pageIndex, pageSize);
        public Task<TEntity> GetId(string database, string table, FilterDefinition<TEntity> filter) => query.GetId(database, table, filter);
        public Task<bool> Update(string database, string table, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update) => query.Update(database, table, filter, update); 
        
    }
}
