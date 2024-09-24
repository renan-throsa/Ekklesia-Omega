using AutoMapper;
using Ekkleisa.Business.Models;
using Ekklesia.Entities.Entities;

namespace Ekkleisa.Business.Mapping
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
