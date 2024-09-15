using AutoMapper;
using Ekkleisa.Business.Models;
using Ekklesia.Entities.Entities;

namespace Ekkleisa.Business.Mapping
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
