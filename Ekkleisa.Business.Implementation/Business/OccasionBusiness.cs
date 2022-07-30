using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Microsoft.Extensions.Logging;
using System;

namespace Ekkleisa.Business.Implementation.Business
{
    public sealed class OccasionBusiness : BusinessCrud<Occasion, OccasionDTO>, IOccasionBusiness, IDisposable
    {
        public OccasionBusiness(IOccasionRepository repository, IMapper mapper, OccasionValidation validations, ILogger<OccasionBusiness> logger) :
            base(repository, mapper, validations, logger)
        {
        }

        public void Dispose()
        {

        }
    }
}
