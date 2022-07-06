using BusinessLogicLayer.Owners.PetHotel.Statistical;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Client.Statistical;
using Entities.OwnerModels.PetHotelModel.Statistical;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Statistical
{
    public class StatisticalDal : IStatisticalBal
    {
        IRepositoryWrapper repository;

        public StatisticalDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public async Task<List<StatisticalModel>> GetAll()
        {
            var statisticalList = await repository.statisticalRepository.GetAll();
            if (statisticalList != null && statisticalList.Count > 0)
            {
                foreach(var statistical in statisticalList)
                {
                    statistical.turnover = statistical.totalIncome - statistical.totalCost;
                }    
                
            }
            return statisticalList;
        }
        public async Task<StatisticalModel> GetId(string _id)
        {

            var filter = Builders<StatisticalModel>.Filter.Eq(q => q._id, _id);
            var statisticalPerDay = await repository.statisticalRepository.GetId(filter);
            return statisticalPerDay;

        }
        public async Task<StatisticalPage> GetStatisticalByMonth(string m)
        {
            var month = m + "/2022";

            var filter = Builders<StatisticalModel>.Filter.Empty;
            var mongoBuilder = Builders<StatisticalModel>.Filter;

            var filterOrder = Builders<OrderModel>.Filter.Empty;
            var mongoBuilderOrder = Builders<OrderModel>.Filter;

            var filOrderToday = DateTime.Now.ToString("dd/MM/yyyy");
            var filterOrderToday = Builders<OrderModel>.Filter.Empty;
            if (!string.IsNullOrEmpty(month))
            {
                month = "/.*" + month + ".*/i";
                filter = filter & mongoBuilder.Regex(y => y.date, new BsonRegularExpression(month));
                filterOrder = filterOrder & mongoBuilderOrder.Regex(y => y.date, new BsonRegularExpression(month));
                
            }
            if (!string.IsNullOrEmpty(filOrderToday))
            {
                filOrderToday = "/.*" + filOrderToday + ".*/i";
                filterOrderToday = filterOrderToday & mongoBuilderOrder.Regex(y => y.date, new BsonRegularExpression(filOrderToday));
            }
            var orderList = await repository.orderRepository.GetListOrderById(filterOrder);
            var statisticalPerMonth = await repository.statisticalRepository.GetListStatisticalById(filter);
            var orderListToDay = await repository.orderRepository.GetListOrderById(filterOrderToday);


            var statisticalPage = new StatisticalPage();
                
            statisticalPage.totalOrder = orderList.Count();
            statisticalPage.statisticalList = statisticalPerMonth;
            statisticalPage.totalOfAllBill = statisticalPerMonth.Sum(q => q.turnover);
            statisticalPage.totalMoneyToDay = orderListToDay.Sum(q => q.subTotal);


            return statisticalPage;

        }
    }
}
