using Entities.OwnerModels.PetHotelModel.Login;
using Entities.OwnerModels.PetHotelModel.User;
using Entities.OwnerModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Login
{
    public interface ILoginBal
    {
        Task<RequestModel<UserModel>> GetId(LoginModel login);
    }
}
