using AutoMapper;
using Ekklesia.Application.Models;
using Ekklesia.Domain.Entities;

namespace Ekklesia.Application.Mapping
{
    public class MemberMapping : Profile
    {
        public MemberMapping()
        {
            CreateMap<Member,SimpleViewMemberModel>().ReverseMap();

            CreateMap<Member,ViewMemberModel>().ReverseMap();

            CreateMap<SaveMemberModel, Member>()
               .ReverseMap();
        }
    }
}
