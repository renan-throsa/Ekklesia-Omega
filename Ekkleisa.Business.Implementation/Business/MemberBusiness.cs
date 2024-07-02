using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ekkleisa.Business.Implementation.Business
{
    public class MemberBusiness : BusinessCrud<Member, MemberDTO>, IMemberBusiness, IDisposable
    {

        public MemberBusiness(IMemberRepository memberRepository, IMapper mapper, MemberValidation memberValidations, ILogger<MemberBusiness> logger) :
     base(memberRepository, mapper, memberValidations, logger)
        {

        }

        public override IEnumerable<MemberDTO> All()
        {

            _logger.LogInformation($"Listing {typeof(MemberDTO).FullName}");
            var entities = _repository.All(m => new Member() { Id = m.Id, Name = m.Name, Phone = m.Phone });
            return _mapper.Map<IEnumerable<MemberDTO>>(entities);
        }


        public override Response Browse(BaseFilter<Member, MemberDTO> filter)
        {
            _logger.LogInformation($"Searching with filter:{filter}");
            Func<IEnumerable<Member>, IEnumerable<MemberDTO>> mapTo = (entities) => _mapper.Map<IEnumerable<MemberDTO>>(entities);

            ValidationResult result = _filterValidator.Validate(filter, options => options.IncludeRuleSets(OperationType.Default.ToString()));

            if (result.IsValid)
            {
                IMongoQueryable<Member> entities = _repository.GetQueryable();
                var filterResult = filter.OnQuery(entities).WithFiltering().WithSorting().WithPagination().WithFields(m => new Member() { Id = m.Id, Name = m.Name, Phone = m.Phone }).Build(mapTo);
                return Response(ResponseStatus.Ok, filterResult);
            }
            else
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }

        public override async Task<Response> AddAsync(MemberDTO tObject)
        {
            _logger.LogInformation($"Adding {nameof(Member)}: {tObject.ToJson()}");
            ValidationResult result = _entityValidator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Insert.ToString()));

            if (!result.IsValid)
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());

            }

            if (tObject.FormFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await tObject.FormFile.CopyToAsync(memoryStream);
                    tObject.Photo = Convert.ToBase64String(memoryStream.ToArray());
                }

            }

            var entity = tObject.ToEntity();
            await _repository.AddAsync(entity);
            tObject = _mapper.Map<MemberDTO>(entity);
            return Response(ResponseStatus.Created, new { tObject.Name, tObject.Id });
        }


        public override async Task<Response> UpdateAsync(MemberDTO tObject)
        {
            _logger.LogInformation($"Updating {nameof(Member)}: {tObject.ToJson()}");
            ValidationResult result = _entityValidator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Update.ToString()));

            var entity = await _repository.FindSync(tObject.Id);
            if (entity == null)
            {
                var message = $"Key:{tObject.Id} was not found.";
                _logger.LogWarning(message);
                return Response(ResponseStatus.NotFound, message);
            }

            if (!result.IsValid)
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());
            }

            if (tObject.FormFile?.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await tObject.FormFile.CopyToAsync(memoryStream);

                    entity.Photo = $"data:image/png;base64,{Convert.ToBase64String(memoryStream.ToArray())}";
                }

            }

            entity.Name = tObject.Name;
            entity.Phone = tObject.Phone;
            entity.Role = tObject.Role;
            entity.BirthDay = tObject.BirthDay;

            await _repository.UpdateAsync(entity);
            tObject = _mapper.Map<MemberDTO>(entity);
            return Response(ResponseStatus.Ok, new { tObject.Name, tObject.Id });
        }

        public void Dispose()
        {

        }

    }
}
