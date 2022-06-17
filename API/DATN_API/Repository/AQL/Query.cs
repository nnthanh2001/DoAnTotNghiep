using Contracts.AQL;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AQL
{
    public class Query : IQuery
    {
        private readonly IMongoClient _mongoClient;
        public Query(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }


        public async Task<TEntity> Add<TEntity>(string database, string table, TEntity doc)
        {
            var db = _mongoClient.GetDatabase(database);
            var collection = db.GetCollection<TEntity>(table);
            await collection.InsertOneAsync(doc);
            return doc;
        }

        public async Task<bool> Delete<TEntity>(string database, string table, FilterDefinition<TEntity> filter)
        {
            var db = _mongoClient.GetDatabase(database);
            var collection = db.GetCollection<TEntity>(table);
            var result = await collection.DeleteOneAsync(filter);
            return result.IsAcknowledged;

        }

        public async Task<List<TEntity>> GetAll<TEntity>(string database, string table, FilterDefinition<TEntity> filter = null, SortDefinition<TEntity> sort = null, int limit = 0)
        {
            var db = _mongoClient.GetDatabase(database);
            var collection = db.GetCollection<TEntity>(table);
            filter ??= Builders<TEntity>.Filter.Empty;
            var all = collection.Find(filter);
            if (sort != null)
            {
                all = all.Sort(sort);
            }
            if (limit > 0)
            {
                all = all.Limit(limit);
            }
            return await all.ToListAsync();
        }

        public async Task<List<TEntity>> GetPaging<TEntity>(string database, string table, FilterDefinition<TEntity> filter, FilterDefinition<TEntity> sort, int pageIndex = 1, int pageSize = 10)
        {
            var db = _mongoClient.GetDatabase(database);
            var collection = db.GetCollection<TEntity>(table);
            filter ??= Builders<TEntity>.Filter.Empty;
            var totalItem = collection.Find(filter).Count();
            var totalPage = (totalItem / pageSize) + 1;
            var result = collection.Find(filter).Skip(pageSize * (pageIndex - 1)).Limit(pageSize);
            return await result.ToListAsync();
        }

        public async Task<TEntity> GetId<TEntity>(string database, string table, FilterDefinition<TEntity> filter)
        {
            var db = _mongoClient.GetDatabase(database);
            var collection = db.GetCollection<TEntity>(table);
            //var fil = Builders<TEntity>.Filter.Eq("_id", filter);
            var data =await collection.Find(filter).SingleOrDefaultAsync();
            return data;
        }

        public async Task<bool> Update<TEntity>(string database, string table, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            var db = _mongoClient.GetDatabase(database);
            var collection = db.GetCollection<TEntity>(table);
            return collection.UpdateOne(filter, update).IsAcknowledged;
        }
    }
}
