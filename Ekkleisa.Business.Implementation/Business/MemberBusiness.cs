using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Validations;
using System;

namespace Ekkleisa.Business.Implementation.Business
{
    public class MemberBusiness : BusinessCrud<Member, MemberDTO>, IMemberBusiness, IDisposable
    {
        public MemberBusiness(IMemberRepository memberRepository, IMapper mapper, MemberValidation validations) : base(memberRepository, mapper, validations)
        {
        }

        public void Dispose()
        {

        }
    }
}
