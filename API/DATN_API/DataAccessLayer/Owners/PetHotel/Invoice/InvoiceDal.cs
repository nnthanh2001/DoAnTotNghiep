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
            return repository.invoiceRepository.Add(doc);
        }

        public Task<bool> Delete(int invoiceID)
        {
            var filter = Builders<InvoiceModel>.Filter.Eq(q => q.invoiceID, invoiceID);
            return repository.invoiceRepository.Delete(filter);
        }

        public Task<List<InvoiceModel>> GetAll()
        {
            return repository.invoiceRepository.GetAll();
        }

        public Task<InvoiceModel> GetId(int invoiceID)
        {
            var filter = Builders<InvoiceModel>.Filter.Eq(q => q.invoiceID, invoiceID);
            return repository.invoiceRepository.GetId(filter);
        }

        public Task<bool> Update(FilterDefinition<InvoiceModel> filter, UpdateDefinition<InvoiceModel> update)
        {
            throw new NotImplementedException();
        }
    }
}
