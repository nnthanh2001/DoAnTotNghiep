using BusinessLogicLayer.Owners.PetHotel;
using Contracts.RepositoryWrapper;
using Entities;
using Entities.OwnerModels.PetHotelModel.Category;
using Entities.OwnerModels.PetHotelModel.Product;
using Entities.OwnerModels.PetHotelModel.Status;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel
{
    public class ProductDal : IProductBal
    {
        readonly IRepositoryWrapper repository;
        public ProductDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public Task<ProductBaseModel> Add(ProductBaseModel doc)
        {
            return repository.productRepository.Add(doc);
        }
        public Task<bool> Delete(string _id)
        {
            var checkid = Builders<ProductModel>.Filter.Eq(q => q._id, _id);
            return repository.productRepository.Delete(checkid);
        }
        public async Task<List<ProductModel>> GetProduct()
        {
            var productList = await repository.productRepository.GetProduct();
            var petTypeList = await repository.petTypeRepository.GetAll();

            var statusList = await repository.statusRepository.GetAll();
            var categoryList = await repository.categoryRepository.GetAll();


            foreach (var product in productList)
            {

                if (statusList.Count > 0)
                {
                    var status = statusList.Where(x => x.statusID == product.statusID).FirstOrDefault();
                    if (status != null)
                    {
                        product.statusName = status.statusName;
                    }
                }

                if (petTypeList.Count > 0)
                {
                    var petType = petTypeList.Where(x => x.petTypeID == product.petTypeID).FirstOrDefault();
                    if (petType != null)
                    {
                        product.petTypeName = petType.petTypeName;
                    }

                }

                if (categoryList.Count > 0)
                {
                    var category = categoryList.Where(x => x.categoryID == product.categoryID).FirstOrDefault();
                    if (category != null)
                    {
                        product.categoryName = category.categoryName;
                    }
                }

            }
            return productList;
        }
        public async Task<ProductModel> GetId(string _id)
        {
            var filter = Builders<ProductModel>.Filter.Eq(q => q._id, _id);
            var product = await repository.productRepository.GetId(filter);



            var statusId = product.statusID;
            var categoryId = product.categoryID;
            var petTypeId = product.petTypeID;




            if (statusId > 0)
            {
                var filterStatusID = Builders<StatusModel>.Filter.Eq(q => q.statusID, statusId);

                var status = await repository.statusRepository.GetId(filterStatusID);

                if (status != null)
                {
                    product.statusName = status.statusName;
                }
            }

            if (petTypeId > 0)
            {
                var filterPetTypeID = Builders<PetTypeModel>.Filter.Eq(q => q.petTypeID, petTypeId);
                var petType = await repository.petTypeRepository.GetId(filterPetTypeID);
                if (petType != null)
                {
                    product.petTypeName = petType.petTypeName;
                }

            }

            if (categoryId > 0)
            {
                var filterCategoryID = Builders<CategoryModel>.Filter.Eq(q => q.categoryID, categoryId);
                var category = await repository.categoryRepository.GetId(filterCategoryID);
                if (category != null)
                {
                    product.categoryName = category.categoryName;
                }
            }
            return product;


        }
        public Task<bool> Update(ProductBaseModel doc, string _id)
        {
            var checkid = Builders<ProductBaseModel>.Filter.Eq(q => q._id, _id);
            var update = Builders<ProductBaseModel>.Update.Set(p => p.productName, doc.productName)
                .Set(p => p.productID, doc.productID)
                .Set(p => p.quantity, doc.quantity)
                .Set(p => p.categoryID, doc.categoryID)
                .Set(p => p.petTypeID, doc.petTypeID)
                .Set(p => p.price, doc.price)
                .Set(p => p.statusID, doc.statusID)
                .Set(p => p.description, doc.description);

            return repository.productRepository.Update(checkid, update);
        }
        public Task<List<ProductModel>> GetTop()
        {
            var limit = 4;
            var sort = Builders<ProductModel>.Sort.Descending("productID");

            return repository.productRepository.GetTopProduct(sort, limit);
        }
        public Task<List<ProductModel>> GetBest()
        {
            var limit = 1;
            var sort = Builders<ProductModel>.Sort.Descending("bestProduct");

            var productList = new ProductModel();

            if (productList.usingExpired == true)
            {
                if (productList.bestProduct == 1)
                { return repository.productRepository.GetTopProduct(sort, limit); }
                return repository.productRepository.GetTopProduct(sort, limit);

            }
            return repository.productRepository.GetTopProduct(sort, limit);

        }
        public async Task<List<CategoryModel>> GetCategoryByOderNo()
        {
            return await repository.categoryRepository.GetAll();
        }
        public async Task<ProductFormModel> EditProduct(string _id)
        {
            var statusList = await repository.statusRepository.GetAll();
            var petTypeList = await repository.petTypeRepository.GetAll();
            var categoryList = await repository.categoryRepository.GetAll();



            var filter = Builders<ProductFormModel>.Filter.Eq(q => q._id, _id);
            var product = await repository.productRepository.GetProductFormById(filter);



            if (statusList.Count > 0)
            {
                var status = statusList.Where(x => x.statusID == product.statusID).FirstOrDefault();
                if (status != null)
                {
                    status.select = "selected";
                    product.statusName = status.statusName;
                }
            }

            if (petTypeList.Count > 0)
            {
                var petType = petTypeList.Where(x => x.petTypeID == product.petTypeID).FirstOrDefault();
                if (petType != null)
                {
                    petType.select = "selected";
                    product.petTypeName = petType.petTypeName;
                }

            }

            if (categoryList.Count > 0)
            {
                var category = categoryList.Where(x => x.categoryID == product.categoryID).FirstOrDefault();
                if (category != null)
                {
                    category.select = "selected";
                    product.categoryName = category.categoryName;
                }
            }

            product.categoryList = categoryList;
            product.petTypeList = petTypeList;
            product.statusList = statusList;


            return product;
        }

        public async Task<ProductFormModel> AddProduct()
        {
            var statusList = await repository.statusRepository.GetAll();
            var petTypeList = await repository.petTypeRepository.GetAll();
            var categoryList = await repository.categoryRepository.GetAll();

            var addProduct = new ProductFormModel
            {
                categoryList = categoryList,
                petTypeList = petTypeList,
                statusList = statusList
            };


            return addProduct;
        }
    }
}
