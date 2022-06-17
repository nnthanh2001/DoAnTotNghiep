using BusinessLogicLayer.Owners.PetHotel.Category;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Category;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Category
{
    public class CategoryDal : ICategoryBal
    {
        readonly IRepositoryWrapper repository;
        public CategoryDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public Task<List<CategoryModel>> GetCategoryByOderNo()
        {
            var limit = 18;
            var sort = Builders<CategoryModel>.Sort.Ascending("oderNo");
            return repository.categoryRepository.GetTopCategory(sort, limit);
        }

        public Task<List<CategoryModel>> GetCategoryChild()
        {
            var limit = 15;
            var sort = Builders<CategoryModel>.Sort.Descending("categoryID");
            return repository.categoryRepository.GetTopCategory(sort, limit);
        }

        public Task<List<CategoryModel>> GetCategoryParent()
        {
            var limit = 3;
            var sort = Builders<CategoryModel>.Sort.Ascending("categoryParent");

            return repository.categoryRepository.GetTopCategory(sort, limit);
        }

    }
}
