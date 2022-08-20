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

        public MemberBusiness(IMemberRepository memberRepository, IMapper mapper, MemberValidation memberValidations, ILogger<MemberBusiness> logger) :
            base(memberRepository, mapper, memberValidations, logger)
        {
            this._memberRepository = memberRepository;
        }      

        public void Dispose()
        {

        }

    }
}
