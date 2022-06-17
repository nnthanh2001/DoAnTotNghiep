using BusinessLogicLayer.Owners.PetHotel.Product;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Product
{
    public class PetTypeDal : IPetTypeBal
    {
        readonly IRepositoryWrapper repository;

        public PetTypeDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public Task<List<PetTypeModel>> GetAll()
        {
            return repository.petTypeRepository.GetAll();
        }
    }
}
