using BusinessLogicLayer.Owners.PetHotel.Condition;
using Contracts.AQL;
using Contracts.Owners.PetHotel.Category;
using Contracts.Owners.PetHotel.Invoice;
using Contracts.Owners.PetHotel.Login;
using Contracts.Owners.PetHotel.Page;
using Contracts.Owners.PetHotel.Product;
using Contracts.Owners.PetHotel.Service;
using Contracts.Owners.PetHotel.Staff;
using Contracts.Owners.PetHotel.Status;
using Contracts.Owners.PetHotel.User;
using Contracts.RepositoryWrapper;
using Repository.Owners.PetHotel.Category;
using Repository.Owners.PetHotel.Condition;
using Repository.Owners.PetHotel.Invoice;
using Repository.Owners.PetHotel.Login;
using Repository.Owners.PetHotel.Page;
using Repository.Owners.PetHotel.Product;
using Repository.Owners.PetHotel.Service;
using Repository.Owners.PetHotel.Status;
using Repository.Owners.PetHotel.User;

namespace Repository.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        IUserRepository _userRepository;
        IProductRepository _productRepository;
        IServiceRepository _serviceRepository;
        IInvoiceRepository _invoiceRepository;
        IRoleRepository _roleRepository;
        IStatusRepository _statusRepository;
        IUserFormRepository _userFormRepository;
        IPetTypeRepository _petTypeRepository;
        
        IPageRepository _pageRepository;
        IConditionRepository _conditionRepository;
        ICategoryRepository _categoryRepository;
        ILoginRepository _loginRepository;

        private readonly IQuery query;
        public RepositoryWrapper(IQuery Query)
        {
            query = Query;
        }
        public IUserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(query);
                }
                return _userRepository;
            }
        }

        public IProductRepository productRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(query);
                }
                return _productRepository;
            }
        }

        public IServiceRepository serviceRepository
        {
            get
            {
                if (_serviceRepository == null)
                {
                    _serviceRepository = new ServiceRepository(query);
                }
                return _serviceRepository;
            }
        }

        public IInvoiceRepository invoiceRepository
        {
            get
            {
                if (_invoiceRepository == null)
                {
                    _invoiceRepository = new InvoiceRepository(query);
                }
                return _invoiceRepository;
            }
        }
        public IRoleRepository roleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(query);
                }
                return _roleRepository;
            }
        }

        public IStatusRepository statusRepository
        {
            get
            {
                if (_statusRepository == null)
                {
                    _statusRepository = new StatusRepository(query);
                }
                return _statusRepository;
            }
        }

        public IUserFormRepository userFormRepository
        {
            get
            {
                if (_userFormRepository == null)
                {
                    _userFormRepository = new UserFormRepository(query);
                }
                return _userFormRepository;
            }
        }

        public IPetTypeRepository petTypeRepository
        {
            get
            {
                if (_petTypeRepository == null)
                {
                    _petTypeRepository = new PetTypeRepository(query);
                }
                return _petTypeRepository;
            }
        }

       

        public IPageRepository pageRepository
        {
            get
            {
                if (_pageRepository == null)
                {
                    _pageRepository = new PageRepository(query);
                }
                return _pageRepository;
            }
        }

        public IConditionRepository conditionRepository
        {
            get
            {
                if (_conditionRepository == null)
                {
                    _conditionRepository = new ConditionRepository(query);
                }
                return _conditionRepository;
            }
        }

        public ICategoryRepository categoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(query);
                }
                return _categoryRepository;

            }
        }

        public ILoginRepository loginRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    _loginRepository = new LoginRepository(query);
                }
                return _loginRepository;

            }
        }
    }
}
