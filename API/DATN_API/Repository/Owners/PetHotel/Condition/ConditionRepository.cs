using BusinessLogicLayer.Owners.PetHotel.Condition;
using Contracts.AQL;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Condition;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Condition
{
    public class ConditionRepository : RepositoryBase<ConditionModel>, IConditionRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.PriceByCondition.ToString();

        IQuery query;
        public ConditionRepository(IQuery query) : base(query)
        {
            this.query = query;
        }
        public Task<List<ConditionModel>> GetAll() => query.GetAll<ConditionModel>(db, table);
    }
}
