using Entities.OwnerModels.PetHotelModel.Category;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Category
{
    public interface ICategoryRepository
    {
        Task<CategoryModel> Add(CategoryModel doc);
        Task<bool> Update(FilterDefinition<CategoryModel> filter, UpdateDefinition<CategoryModel> update);
        Task<bool> Delete(FilterDefinition<CategoryModel> filter);
        Task<CategoryModel> GetId(FilterDefinition<CategoryModel> filter);
        Task<List<CategoryModel>> GetAll();
        Task<List<CategoryModel>> GetTopCategory(SortDefinition<CategoryModel> sort = null, int limit = 0);

    }
}
