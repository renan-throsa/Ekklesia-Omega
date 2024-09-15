using AutoMapper;
using Ekkleisa.Business.Abstractions;
using Ekkleisa.Business.Models;
using Ekkleisa.Repository.Contract.IRepositories;

namespace Ekkleisa.Business.Implementation.Business
{
    public sealed class OccasionBusiness : BaseBusiness, IOccasionBusiness
    {
        private readonly IOccasionRepository _occasionRepository;

        public OccasionBusiness(IOccasionRepository occasionRepository, IMapper mapper) : base(mapper)
        {
            _occasionRepository = occasionRepository;
        }

        public OperationResultModel FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultModel> Insert(SaveOccasionModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultModel> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultModel> Update(EditOccasionModel model)
        {
            throw new NotImplementedException();
        }
    }
}
