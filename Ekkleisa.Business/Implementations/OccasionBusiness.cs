using AutoMapper;
using Ekklesia.Application.Abstractions;
using Ekklesia.Application.Infrastructure;
using Ekklesia.Application.Models;

namespace Ekklesia.Application.Implementations
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
