using BusinessLogicLayer.Owners.PetHotel.Status;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Status
{
    public class StatusDal : IStatusBal
    {
        readonly IRepositoryWrapper repository;

        public StatusDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public Task<List<StatusModel>> GetAll()
        {
            return repository.statusRepository.GetAll();
        }
    }
}
