using AutoMapper;
using Ekkleisa.Business.Abstractions;
using Ekkleisa.Business.Models;
using Ekkleisa.Business.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using System.Net;

namespace Ekkleisa.Business.Implementation.Business
{
    public class MemberBusiness : BaseBusiness, IMemberBusiness
    {
        private readonly IMemberRepository _memberRepository;

        public MemberBusiness(IMemberRepository memberRepository, IMapper mapper) : base(mapper)
        {
            _memberRepository = memberRepository;
        }

        public OperationResultModel Browse(BaseFilterParams filterParams)
        {
            Func<IEnumerable<Member>, IEnumerable<ViewMemberModel>> mapTo = (entities) => _mapper.Map<IEnumerable<ViewMemberModel>>(entities);

            if (!ModelIsValid(new BaseFilterValidator(), filterParams))
                return Error();
           

            var filterResult = new MemberFilter(_memberRepository.GetQueryable(),filterParams)
                .WithFiltering()
                .WithSorting()
                .WithPagination()
                .WithFields(m => new Member() { Id = m.Id, Name = m.Name, Phone = m.Phone, Role = m.Role })
                .Build(mapTo);

            return Success(filterResult);

        }

        public OperationResultModel FindAll()
        {
            var entities = _memberRepository.All(m => new Member() { Id = m.Id, Name = m.Name});
            return Success(_mapper.Map<IEnumerable<SimpleViewMemberModel>>(entities));
        }

        public async Task<OperationResultModel> FindById(string id)
        {
            var entity = await _memberRepository.FindAsync(id);
            if (entity == null)
            {
                var message = $"Key:{id} not found.";
                return Error(message, HttpStatusCode.NotFound);
            }

            return Success(_mapper.Map<ViewMemberModel>(entity));
        }

        public async Task<OperationResultModel> Insert(SaveMemberModel model)
        {
            var entity = _mapper.Map<Member>(model);

            if (!EntityIsValid(new MemberValidation(model.FormFile), entity, OperationType.Insert.ToString()))
                return Error();


            if (model.FormFile?.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.FormFile.CopyToAsync(memoryStream);
                    entity.Photo = $"data:image/png;base64,{Convert.ToBase64String(memoryStream.ToArray())}";
                }

            }

            await _memberRepository.AddAsync(entity);

            return Success(entity.Id);
        }

        public async Task<OperationResultModel> Remove(string id)
        {
            var entity = await _memberRepository.FindAsync(id);

            if (entity is null)
            {
                var message = $"Key:{id} was not found.";
                return Error(message, HttpStatusCode.NotFound);
            }

            entity.Active = false;
            await _memberRepository.UpdateAsync(entity);

            return Success(entity.Id);
        }

        public async Task<OperationResultModel> Update(SaveMemberModel model)
        {
            var entity = _mapper.Map<Member>(model);

            if (!EntityIsValid(new MemberValidation(model.FormFile), entity, OperationType.Update.ToString()))
                return Error();


            if (model.FormFile?.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.FormFile.CopyToAsync(memoryStream);
                    entity.Photo = $"data:image/png;base64,{Convert.ToBase64String(memoryStream.ToArray())}";
                }                

            }
            else
            {
                var entityFomDB = await _memberRepository.FindAsync(model.Id);
                entity.Photo = entityFomDB?.Photo;
            }

            await _memberRepository.UpdateAsync(entity);

            return Success(entity.Id);
        }
    }
}
