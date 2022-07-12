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
            
            var statisticalList = new List<StatisticalModel>();
            var statisticalPage = new StatisticalPage();




            var curentOrderDate = new List<OrderModel>();
           

            var curentDate = DateTime.Now.Day;
            var curentMonth = DateTime.Now.Month;
            for(var i = 1; i <= curentMonth;i++ )
            {

                
                m = i.ToString();

                var month = m + "/2022";
                var filter = Builders<OrderModel>.Filter.Empty;
                var mongoBuilder = Builders<OrderModel>.Filter;
                if (!string.IsNullOrEmpty(month))
                {
                    var monthFilter = "/.*" + month + ".*/i";
                    filter = filter & mongoBuilder.Regex(y => y.date, new BsonRegularExpression(monthFilter));
                }
                var sort = Builders<OrderModel>.Sort.Descending("_id");
                var statisticalPerMonth = await repository.invoiceRepository.GetListOrderByDate(filter, sort);

                var statistical = new StatisticalModel
                {
                    month = month,
                    nuberOfOrder = statisticalPerMonth.Count(),
                    totalIncome = statisticalPerMonth.Sum(q => q.subTotal),
                    totalCost = 50000000 
            };
                //statistical.totalCost = statistical.costList.Sum(q => q.costPrice);

                if(i == curentMonth)
                {
                    var currentDate =DateTime.Parse( curentDate + "/" + m + "/2022").ToString("dd/MM/yyyy");
                    curentOrderDate = statisticalPerMonth.Where(x => DateTime.Parse(x.date).ToString("dd/MM/yyyy").Equals(currentDate)).ToList();
                }    

                statisticalList.Add(statistical);
            }




            statisticalPage.totalOrderToDay = curentOrderDate.Count();
            statisticalPage.totalOfAllBill = statisticalList.Sum(q => q.totalIncome);
            statisticalPage.totalMoneyToDay = curentOrderDate.Sum(q => q.subTotal);
            statisticalPage.statisticalList = statisticalList;

            return statisticalPage;
        }




    }
}
