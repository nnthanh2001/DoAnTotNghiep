using BusinessLogicLayer.BusinessWrapper;
using BusinessLogicLayer.Owners.PetHotel;
using BusinessLogicLayer.Owners.PetHotel.Category;
using BusinessLogicLayer.Owners.PetHotel.Invoice;
using BusinessLogicLayer.Owners.PetHotel.Login;
using BusinessLogicLayer.Owners.PetHotel.Product;
using BusinessLogicLayer.Owners.PetHotel.Service;
using BusinessLogicLayer.Owners.PetHotel.Status;
using BusinessLogicLayer.Owners.PetHotel.User;
using Contracts.RepositoryWrapper;
using DataAccessLayer.Owners.PetHotel;
using DataAccessLayer.Owners.PetHotel.Category;
using DataAccessLayer.Owners.PetHotel.Invoice;
using DataAccessLayer.Owners.PetHotel.Login;
using DataAccessLayer.Owners.PetHotel.Product;
using DataAccessLayer.Owners.PetHotel.Service;
using DataAccessLayer.Owners.PetHotel.Status;
using DataAccessLayer.Owners.PetHotel.User;

namespace DataAccessLayer.BusinessWrapper
{
    public class BusinessWrapper : IBusinessWrapper
    {
        IUserBal _user;
        IProductBal _product;
        IServiceBal _serivice;
        IInvoiceBal _invoice;
        IRoleBal _role;
        IStatusBal _status;
        IUserFormBal _userForm;
        ICategoryBal _category;
        ILoginBal _login;

        readonly IRepositoryWrapper repository;

        public BusinessWrapper(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public IUserBal user
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserDal(repository);
                }
                return _user;
            }
        }

        public IProductBal product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductDal(repository);
                }
                return _product;
            }
        }

        public IServiceBal service
        {
            get
            {
                if (_serivice == null)
                {
                    _serivice = new ServiceDal(repository);
                }
                return _serivice;
            }
        }

        public IInvoiceBal invoice
        {
            get
            {
                if (_invoice == null)
                {
                    _invoice = new InvoiceDal(repository);
                }
                return _invoice;
            }
        }

        public IRoleBal role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleDal(repository);
                }
                return _role;
            }
        }

        public IStatusBal status
        {
            get
            {
                if (_status == null)
                {
                    _status = new StatusDal(repository);
                }
                return _status;
            }
        }

        public ICategoryBal category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryDal(repository);
                }
                return _category;
            }
        }

        public ILoginBal login
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginDal(repository);
                }
                return _login;
            }
        }

        public IUserFormBal userForm
        {
            get
            {
                if (_userForm == null)
                {
                    _userForm = new UserFormDal(repository);
                }
                return _userForm;
            }
        }
    }
}
