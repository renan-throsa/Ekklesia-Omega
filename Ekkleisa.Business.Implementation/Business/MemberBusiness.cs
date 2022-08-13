using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Ekkleisa.Business.Implementation.Business
{
    public class MemberBusiness : BusinessCrud<Member, MemberDTO>, IMemberBusiness, IDisposable
    {
        private readonly IMemberRepository _memberRepository;

        public MemberBusiness(IMemberRepository memberRepository, IMapper mapper, MemberValidation validations, ILogger<MemberBusiness> logger) :
            base(memberRepository, mapper, validations, logger)
        {
            this._memberRepository = memberRepository;
        }

        public IEnumerable<Member> FilterMembers(MemberFilter filter)
        {
            return this._memberRepository.Browse(filter);
        }

        public FilterResult FilterGrid(GridFilter filter)
        {
            var memberFilter = new MemberFilter();
            var members = FilterMembers(memberFilter);
            var filterResult = new FilterResult();
            return filterResult;
        }

        public GridFilter GetFilter()
        {
            throw new NotImplementedException();
        }

        public void SaveFilter(GridFilter filter)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

    }
}
