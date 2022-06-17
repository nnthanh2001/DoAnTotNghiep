using BusinessLogicLayer.Owners.PetHotel;
using BusinessLogicLayer.Owners.PetHotel.Category;
using BusinessLogicLayer.Owners.PetHotel.Invoice;
using BusinessLogicLayer.Owners.PetHotel.Login;
using BusinessLogicLayer.Owners.PetHotel.Product;
using BusinessLogicLayer.Owners.PetHotel.Service;
using BusinessLogicLayer.Owners.PetHotel.Status;
using BusinessLogicLayer.Owners.PetHotel.User;

namespace BusinessLogicLayer.BusinessWrapper
{
    public interface IBusinessWrapper
    {
        IUserBal user { get; }
        IProductBal product { get; }
        
        IServiceBal service { get; } 
        IInvoiceBal invoice { get; } 
        IRoleBal role { get; }
        IStatusBal status { get; }
        IUserFormBal userForm { get; }
        ICategoryBal category { get; }
        ILoginBal login { get; }
    }
}
