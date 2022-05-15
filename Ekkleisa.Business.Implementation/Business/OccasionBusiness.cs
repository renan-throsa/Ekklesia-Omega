using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Validations;
using System;

namespace Ekkleisa.Business.Implementation.Business
{
    public sealed class OccasionBusiness : BusinessCrud<Occasion, OccasionDTO>, IOccasionBusiness, IDisposable
    {
        public OccasionBusiness(IOccasionRepository repository, IMapper mapper, OccasionValidation validations) : base(repository, mapper, validations)
        {
        }

        public void Dispose()
        {

        }
    }
}
