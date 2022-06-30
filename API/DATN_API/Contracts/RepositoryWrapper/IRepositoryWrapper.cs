using BusinessLogicLayer.Owners.PetHotel.Condition;
using Contracts.Owners.PetHotel.Category;
using Contracts.Owners.PetHotel.Invoice;
using Contracts.Owners.PetHotel.Login;
using Contracts.Owners.PetHotel.Order;
using Contracts.Owners.PetHotel.Page;
using Contracts.Owners.PetHotel.Product;
using Contracts.Owners.PetHotel.Service;
using Contracts.Owners.PetHotel.Staff;
using Contracts.Owners.PetHotel.Status;
using Contracts.Owners.PetHotel.User;

namespace Contracts.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository userRepository { get; }
        IProductRepository productRepository { get; }
        IServiceRepository serviceRepository { get; }
        IInvoiceRepository invoiceRepository { get; }
        IRoleRepository roleRepository { get; }
        IStatusRepository statusRepository { get; }
        IUserFormRepository userFormRepository { get; }
        IPetTypeRepository petTypeRepository { get; }
        IOrderRepository orderRepository { get; }
        IPageRepository pageRepository { get; }
        IConditionRepository conditionRepository { get; }
        ICategoryRepository categoryRepository { get; }
        ILoginRepository loginRepository { get; }


    }
}
