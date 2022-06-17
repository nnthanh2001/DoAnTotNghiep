using DataAccessLayer.Owners.PetHotel.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Page
{
    public interface IPageRepository
    {
        Task<List<PageModel>> GetAll();
    }
}
