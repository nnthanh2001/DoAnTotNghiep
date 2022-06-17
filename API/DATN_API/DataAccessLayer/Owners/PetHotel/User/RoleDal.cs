using BusinessLogicLayer.Owners.PetHotel.User;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.User
{
    public class RoleDal : IRoleBal
    {
        readonly IRepositoryWrapper repository;

        public RoleDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public Task<List<RoleModel>> GetAll()
        {
            return repository.roleRepository.GetAll();
        }
    }
}
