using BusinessLogicLayer.Owners.PetHotel;
using Contracts.RepositoryWrapper;
using Entities;
using Entities.OwnerModels.PetHotelModel.Category;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Product;
using Entities.OwnerModels.PetHotelModel.Status;
using Entities.OwnerModels.Request;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public int randomID()
        {
            Random r = new Random();
            int n = r.Next();
            return n;
        }
        public Task<ProductBaseModel> Add(ProductBaseModel doc)
        {

            doc.productID = "SP" + randomID();
            doc.productHandle = handler(doc.productName);
            return repository.productRepository.Add(doc);
        }
        public Task<bool> Delete(string _id)
        {
            var checkid = Builders<ProductModel>.Filter.Eq(q => q._id, _id);
            return repository.productRepository.Delete(checkid);
        }
        public async Task<List<ProductModel>> GetProduct(string k = "")
        {



            var filter = Builders<ProductModel>.Filter.Empty;
            var mongoBuilder = Builders<ProductModel>.Filter;
            if (!string.IsNullOrEmpty(k))
            {
                k = "/.*" + k + ".*/i";
                filter = filter & mongoBuilder.Regex(y => y.productName, new BsonRegularExpression(k));
            }
            var sort = Builders<ProductModel>.Sort.Descending("_id");
            var productList = await repository.productRepository.GetProduct(sort, filter);
            foreach (var product in productList)
            {


                if (product.statusID > 0)
                {
                    var filterStatusID = Builders<StatusModel>.Filter.Eq(q => q.statusID, product.statusID);

                    var status = await repository.statusRepository.GetId(filterStatusID);

                    if (status != null)
                    {
                        product.statusName = status.statusName;
                    }
                }
                if (product.petTypeID > 0)
                {
                    var filterPetTypeID = Builders<PetTypeModel>.Filter.Eq(q => q.petTypeID, product.petTypeID);
                    var petType = await repository.petTypeRepository.GetId(filterPetTypeID);
                    if (petType != null)
                    {
                        product.petTypeName = petType.petTypeName;
                    }

                }

                if (product.categoryID > 0)
                {
                    var filterCategoryID = Builders<CategoryModel>.Filter.Eq(q => q.categoryID, product.categoryID);
                    var category = await repository.categoryRepository.GetId(filterCategoryID);
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

            if (doc.productID == "")
            {
                doc.productID = "SP" + randomID();
            }
            var handle = doc.productHandle = handler(doc.productName);
            var checkid = Builders<ProductBaseModel>.Filter.Eq(q => q._id, _id);
            var update = Builders<ProductBaseModel>.Update.Set(p => p.productName, doc.productName)
                .Set(p => p.productID, doc.productID)
                .Set(p => p.quantity, doc.quantity)
                .Set(p => p.categoryID, doc.categoryID)
                .Set(p => p.petTypeID, doc.petTypeID)
                .Set(p => p.price, doc.price)
                .Set(p => p.image, doc.image)
                .Set(p => p.statusID, doc.statusID)
                .Set(p => p.description, doc.description)
                .Set(handle, doc.productHandle);


            var result = repository.productRepository.Update(checkid, update);

            return result;
        }
        public Task<List<ProductModel>> GetTop()
        {
            var limit = 8;
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
            var limit = 2;
            var sortStatus = Builders<StatusModel>.Sort.Descending("statusID");

            var statusList = await repository.statusRepository.GetAll(sortStatus, limit);
            var petTypeList = await repository.petTypeRepository.GetAll();
           
            var sort = Builders<CategoryModel>.Sort.Descending("categoryID");
            var categoryList = await repository.categoryRepository.GetTopCategory(sort);

            var addProduct = new ProductFormModel
            {
                categoryList = categoryList,
                petTypeList = petTypeList,
                statusList = statusList
            };


            return addProduct;
        }
        public async Task<List<ProductModel>> GetProductByCategory(int id = 0, string k = "")
        {
            var productList = new List<ProductModel>();
            var filterKeyword = Builders<ProductModel>.Filter.Empty;
            var mongoBuilder = Builders<ProductModel>.Filter;
            var filterCategory = Builders<ProductModel>.Filter.Eq(q => q.categoryID, id);
            var sort = Builders<ProductModel>.Sort.Descending("_id");

            if (id == 0 &&  k == null)
            {
                productList = await repository.productRepository.GetAll();
            }
            else
            {
                if (!string.IsNullOrEmpty(k))
                {

                    k = "/.*" + k + ".*/i";
                    filterKeyword = filterKeyword & mongoBuilder.Regex(y => y.productName, new BsonRegularExpression(k));
                    productList = await repository.productRepository.GetProduct(sort, filterKeyword);
                }
                else
                {
                    if (id > 0)
                    {
                        productList = await repository.productRepository.GetListProductById(filterCategory);
                    }
                    else
                    {
                        if( id>0 && !string.IsNullOrEmpty(k))
                        {
                            k = "/.*" + k + ".*/i";
                            filterKeyword = filterKeyword & mongoBuilder.Regex(y => y.productName, new BsonRegularExpression(k));

                            productList = await repository.productRepository.GetListProductById(filterCategory);
                            productList = await repository.productRepository.GetProduct(sort, filterKeyword);

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
           
           
            
            if (id > 0 && !string.IsNullOrEmpty(k))
            {
               
                k = "/.*" + k + ".*/i";
                filterKeyword = filterKeyword & mongoBuilder.Regex(y => y.productName, new BsonRegularExpression(k));
               
                var productListFilter = await repository.productRepository.GetListProductById(filterCategory);
                if (productListFilter.Count > 0)
                {
                    //productList = await productListFilter.Where(q => q.productName == filterKeyword);
                }    
               
            }


            return productList;

        }
        public string handler(string text)
        {
            var chuyendoi = LoaiDau(text).ToLower();
            string strPattern = @"[\s]+";
            Regex rgx = new Regex(strPattern);
            string Ouput = rgx.Replace(chuyendoi, "-");
            return Ouput;
        }
        public string LoaiDau(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty)
                        .Replace('đ', 'd').Replace('Đ', 'D');


        }

    }
}
