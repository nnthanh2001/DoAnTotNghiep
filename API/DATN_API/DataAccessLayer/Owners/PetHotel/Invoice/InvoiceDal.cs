using BusinessLogicLayer.Owners.PetHotel.Invoice;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Invoice;
using Entities.OwnerModels.PetHotelModel.Product;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Invoice
{
    public class InvoiceDal : IInvoiceBal
    {
        readonly IRepositoryWrapper repository;

        public InvoiceDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }

        public async Task<OrderModel> Add(OrderModel doc)
        {
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            doc.date = currentDate;

            foreach (var product in doc.productList)
            {

                var productId = Builders<ProductModel>.Filter.Eq(q => q._id, product._id);
                var productIdBase = Builders<ProductBaseModel>.Filter.Eq(q => q._id, product._id);

                var productInStock = await repository.productRepository.GetId(productId);
                productInStock.quantity -= product.quantity;
                var update = Builders<ProductBaseModel>.Update.Set(q => q.quantity, productInStock.quantity);
                var updateStockProduct = await repository.productRepository.Update(productIdBase, update);
            }
            return await repository.invoiceRepository.Add(doc);
        }

        public async Task<bool> Delete(int invoiceID)
        {
            var filter = Builders<InvoiceModel>.Filter.Eq(q => q.invoiceID, invoiceID);
            return await repository.invoiceRepository.Delete(filter);
        }
        public async Task<List<OrderModel>> GetOrderByCustomer(string userId = "")
        {

            var filter = Builders<OrderModel>.Filter.Eq(q => q.shipping.userId, userId);

            var sort = Builders<OrderModel>.Sort.Descending("_id");
            var result = await repository.invoiceRepository.GetListOrderByName(filter, sort);



            return result;

        }
        public async Task<List<OrderModel>> GetAll()
        {
            var sort = Builders<OrderModel>.Sort.Descending("_id");
            return await repository.invoiceRepository.GetAll(sort);
        }

        public async Task<OrderModel> GetId(string id)
        {
            var filter = Builders<OrderModel>.Filter.Eq(q => q._id, id);
            return await repository.invoiceRepository.GetId(filter);
        }
        public async Task<List<OrderModel>> GetOrderByDay(string date = "")
        {
            var filter = Builders<OrderModel>.Filter.Empty;
            var mongoBuilder = Builders<OrderModel>.Filter;
            if (!string.IsNullOrEmpty(date))
            {
                date = "/.*" + date + ".*/i";
                filter = filter & mongoBuilder.Regex(y => y.date, new BsonRegularExpression(date));
            }
            var sort = Builders<OrderModel>.Sort.Descending("_id");
            var result = await repository.invoiceRepository.GetListOrderByDate(filter, sort);
            return result;
        }
        public async  Task<bool> Update(string _id)
        {
            var checkid = Builders<OrderModel>.Filter.Eq(q => q._id, _id);
            var update = Builders<OrderModel>.Update.Set(p => p.status, "Đang giao hàng");
            var updateOrder =  repository.invoiceRepository.Update(checkid, update);
            
            return await updateOrder;
        }
    }
}
