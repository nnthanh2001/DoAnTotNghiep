using Entities.OwnerModels.PetHotelModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Category
{
    public interface ICategoryBal
    {
        Task<List<CategoryModel>> GetCategoryParent();
        Task<List<CategoryModel>> GetCategoryChild();
        Task<List<CategoryModel>> GetCategoryByOderNo();
        
    }
}
