using AutoMapper;
using Ekklesia.Application.Models;
using Ekklesia.Domain.Entities;
using MongoDB.Bson;

namespace Ekklesia.Application.Mapping
{
    public class OccasionMapping: Profile
    {
        public OccasionMapping()
        {
            CreateMap<ViewOccasionModel, Occasion>()
              .ForMember(transaction => transaction.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
              .ReverseMap();

            CreateMap<ViewOccasionMemberModel, Member>().ReverseMap();
            CreateMap<ViewCultModel, Cult>().ReverseMap();
            CreateMap<ViewSundaySchoolModel, SundaySchool>().ReverseMap();


            CreateMap<SaveOccasionModel, Occasion>()
              .ForMember(transaction => transaction.Id, x => x.MapFrom(y => y.Id == null ? ObjectId.Empty : new ObjectId(y.Id)))
              .ReverseMap();

            CreateMap<SaveOccasionMemberModel, Member>().ReverseMap();
            CreateMap<SaveCultModel, Cult>().ReverseMap();
            CreateMap<SaveSundaySchoolModel, SundaySchool>().ReverseMap();
        }
    }
}
