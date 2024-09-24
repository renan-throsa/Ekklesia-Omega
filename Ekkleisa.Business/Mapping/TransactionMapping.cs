using AutoMapper;
using Ekklesia.Application.Models;
using Ekklesia.Domain.Entities;

namespace Ekklesia.Application.Mapping
{
    public class TransactionMapping : Profile
    {
        public TransactionMapping()
        {
            CreateMap<Transaction, ViewTransactionModel>().ReverseMap();


            CreateMap<Transaction, SaveTransactionModel>()
               .ForMember(model => model.ResponsableName, x => x.MapFrom(y => y.Responsable.Name))
               .ForMember(model => model.ResponsableId, x => x.MapFrom(y => y.Responsable.Id))
               .ReverseMap();

            CreateMap<EditTransactionModel, Transaction>()
               .ReverseMap();
        }
    }
}
