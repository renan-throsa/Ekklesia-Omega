using AutoMapper;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using MongoDB.Bson;

namespace Ekkleisa.Business.Implementation.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Member, MemberDTO>()
               .ForMember(dto => dto.Id, x => x.MapFrom(y => y.Id.ToString()))
               .ReverseMap();

            CreateMap<MemberDTO, Member>()
                .ForMember(member => member.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
                .ReverseMap();

            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dto => dto.Id, x => x.MapFrom(y => y.Id.ToString()))
                .ReverseMap();

            CreateMap<TransactionDTO, Transaction>()
                .ForMember(transaction => transaction.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
                .ReverseMap();

            CreateMap<Income, IncomeDTO>().ReverseMap();
            CreateMap<Expense, ExpenseDTO>().ReverseMap();


            CreateMap<Occasion, OccasionDTO>()
                .ForMember(dto => dto.Id, x => x.MapFrom(y => y.Id.ToString()))
                .ReverseMap();

            CreateMap<OccasionDTO, Occasion>()
                .ForMember(transaction => transaction.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
                .ReverseMap();

            CreateMap<Cult, CultDTO>().ReverseMap();
            CreateMap<SundaySchool, SundaySchoolDTO>().ReverseMap();

        }
    }
}
