using Entities;
using Entities.OwnerModels.PetHotelModel.Category;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Product;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel
{
    public interface IProductBal
    {
        Task<ProductBaseModel> Add(ProductBaseModel doc);
        Task<bool> Update(ProductBaseModel doc, string _id);
        Task<bool> Delete(string _id);
        Task<List<ProductModel>> GetProduct();
        Task<List<ProductModel>> GetTop();
        Task<List<ProductModel>> GetBest();
        Task<ProductModel> GetId(string _id);
        Task<List<ProductModel>> GetProductByCategory(int id);
        Task<ProductFormModel> EditProduct(string _id);
        Task<ProductFormModel> AddProduct();

    }
}
