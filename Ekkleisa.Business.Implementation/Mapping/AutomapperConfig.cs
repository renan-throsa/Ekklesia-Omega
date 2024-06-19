using AutoMapper;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using MongoDB.Bson;

namespace Ekkleisa.Business.Implementation.Mapping
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

            CreateMap<MemberDTO, Member>()
                .ForMember(member => member.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
                .ReverseMap();


            CreateMap<TransactionDTO, Transaction>()
                .ForMember(transaction => transaction.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
                .ReverseMap();

            CreateMap<IncomeDTO, Income>().ReverseMap();
            CreateMap<ExpenseDTO, Expense>().ReverseMap();



            CreateMap<OccasionDTO, Occasion>()
                .ForMember(transaction => transaction.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
                .ReverseMap();

            CreateMap<CultDTO, Cult>().ReverseMap();
            CreateMap<SundaySchoolDTO, SundaySchool>().ReverseMap();
        }
    }
}
