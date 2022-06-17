using Contracts.AQL;
using Contracts.Owners.PetHotel.Page;
using DataAccessLayer.Owners.PetHotel.Page;
using Entities.Database;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Page
{
    public class PageRepository : RepositoryBase<PageModel>, IPageRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Page.ToString();
        IQuery query;
        public PageRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<List<PageModel>> GetAll() => query.GetAll<PageModel>(db, table);

    }
}
