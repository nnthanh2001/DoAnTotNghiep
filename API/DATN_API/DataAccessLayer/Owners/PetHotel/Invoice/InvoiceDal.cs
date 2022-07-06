using BusinessLogicLayer.Owners.PetHotel.Invoice;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Invoice;
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

        public Task<OrderModel> Add(OrderModel doc)
        {
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            doc.status = "Đang xác nhận";
            doc.payment = "Thanh toán sau khi nhận hàng";
            doc.date = currentDate;
            return repository.invoiceRepository.Add(doc);
        }

        public Task<bool> Delete(int invoiceID)
        {
            var filter = Builders<InvoiceModel>.Filter.Eq(q => q.invoiceID, invoiceID);
            return repository.invoiceRepository.Delete(filter);
        }

        public Task<List<OrderModel>> GetAll()
        {
            var sort = Builders<OrderModel>.Sort.Descending("_id");
            return repository.invoiceRepository.GetAll(sort);
        }

        public Task<OrderModel> GetId(string id)
        {
            var filter = Builders<OrderModel>.Filter.Eq(q => q._id, id);
            return repository.invoiceRepository.GetId(filter);
        }

        public Task<bool> Update(FilterDefinition<InvoiceModel> filter, UpdateDefinition<InvoiceModel> update)
        {
            throw new NotImplementedException();
        }
    }
}
