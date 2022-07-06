using Entities.OwnerModels.PetHotelModel.Client.Statistical;
using Entities.OwnerModels.PetHotelModel.Statistical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Statistical
{
    public interface IStatisticalBal
    {
        Task<List<StatisticalModel>> GetAll();
        Task<StatisticalModel> GetId(string _id);
        Task<StatisticalPage> GetStatisticalByMonth(string month);
    }
}
