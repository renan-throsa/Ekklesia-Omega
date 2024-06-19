using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekkleisa.Business.Implementation.Business
{
    public sealed class OccasionBusiness : BusinessCrud<Occasion, OccasionDTO>, IOccasionBusiness, IDisposable
    {
        public OccasionBusiness(IOccasionRepository repository, IMapper mapper, OccasionValidation occasionValidation, ILogger<OccasionBusiness> logger) :
            base(repository, mapper, occasionValidation, logger)
        {
        }

        public override IEnumerable<OccasionDTO> All()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
