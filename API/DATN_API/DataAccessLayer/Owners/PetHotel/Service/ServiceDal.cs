using BusinessLogicLayer.Owners.PetHotel.Service;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel;
using Entities.OwnerModels.PetHotelModel.Condition;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Service
{
    public class ServiceDal : IServiceBal
    {
        IRepositoryWrapper repository;

        public ServiceDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public Task<ServiceModel> Add(ServiceModel doc)
        {
            return repository.serviceRepository.Add(doc);
        }

        public Task<bool> Delete(string _id)
        {
            var filter = Builders<ServiceModel>.Filter.Eq(q => q._id, _id);
            return repository.serviceRepository.Delete(filter);
        }

        public async Task<ServiceFormModel> EditService(string _id)
        {
            var statusList = await repository.statusRepository.GetAll();
            var conditionList = await repository.conditionRepository.GetAll();

            var filter = Builders<ServiceFormModel>.Filter.Eq(q => q._id, _id);
            var service = await repository.serviceRepository.GetServiceFormById(filter);




            if (conditionList.Count > 0)
            {
                var priceBycondition = conditionList.Where(x => x.conditionID == service.conditionID).FirstOrDefault();
                if (priceBycondition != null)
                {
                    service.condition = priceBycondition.condition;
                    service.price = priceBycondition.price;

                }
            }
            if (statusList.Count > 0)
            {
                var status = statusList.Where(x => x.statusID == service.statusID).FirstOrDefault();
                if (status != null)
                {
                    status.select = "selected";
                    service.statusName = status.statusName;
                }
            }


            service.statusList = statusList;
            service.conditionList = conditionList;


            return service;
        }

        public async Task<List<ServiceModel>> GetAll()
        {
            var serviceList = await repository.serviceRepository.GetAll();
            var statusList = await repository.statusRepository.GetAll();
            var conditionList = await repository.conditionRepository.GetAll();

            foreach (var service in serviceList)
            {

                if (statusList.Count > 0)
                {
                    var status = statusList.Where(x => x.statusID == service.statusID).FirstOrDefault();
                    if (status != null)
                    {
                        service.statusName = status.statusName;
                    }
                }
                if (conditionList.Count > 0)
                {
                    var condition = conditionList.Where(x => x.conditionID == service.conditionID).FirstOrDefault();
                    if (condition != null)
                    {
                        service.condition = condition.condition;
                        service.price = condition.price;
                    }
                }

            }
            return serviceList;
        }

        public async Task<ServiceModel> GetId(string _id)
        {
            var statusList = await repository.statusRepository.GetAll();
            var priceByconditionList = await repository.conditionRepository.GetAll();

            var filter = Builders<ServiceModel>.Filter.Eq(q => q._id, _id);
            var service = await repository.serviceRepository.GetId(filter);




            if (priceByconditionList.Count > 0)
            {
                var priceBycondition = priceByconditionList.Where(x => x.conditionID == service.conditionID).FirstOrDefault();
                if (priceBycondition != null)
                {
                    service.condition = priceBycondition.condition;
                    service.price = priceBycondition.price;

                }
            }
            if (statusList.Count > 0)
            {
                var status = statusList.Where(x => x.statusID == service.statusID).FirstOrDefault();
                if (status != null)
                {
                    status.select = "selected";
                    service.statusName = status.statusName;
                }
            }

            return service;
        }

        public async Task<List<ServiceModel>> GetTop()
        {
            var statusList = await repository.statusRepository.GetAll();

            var limit = 3;
            var sort = Builders<ServiceModel>.Sort.Ascending("serviceID");
            var serviceList = await repository.serviceRepository.GetTopService(sort, limit);

            foreach (var service in serviceList)
            {
                if (statusList.Count > 0)
                {
                    var status = statusList.Where(x => x.statusID == service.statusID).FirstOrDefault();
                    if (status != null)
                    {
                        service.statusName = status.statusName;
                    }
                }
            }

            return serviceList;
        }

        public async Task<bool> Update(ServiceModel service, string _id)
        {
            var checkid = Builders<ServiceModel>.Filter.Eq(q => q._id, _id);
            var update = Builders<ServiceModel>.Update.Set(p => p.serviceName, service.serviceName).Set(p => p.unit, service.unit).Set(p => p.description, service.description).Set(p => p.condition, service.condition).Set(p => p.price, service.price).Set(p => p.statusName, service.statusName).Set(p => p.statusID, service.statusID);

            return await repository.serviceRepository.Update(checkid, update);
        }
    }
}
