using Ekklesia.Entities.Entities;
using MongoDB.Bson.Serialization;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    internal static class MongoMapping
    {
        internal static BsonClassMap<BaseEntity> BaseEntity(BsonClassMap<BaseEntity> cm)
        {
            cm.AutoMap();
            cm.MapMember(c => c.Id).SetElementName("id").SetIgnoreIfDefault(true);
            cm.SetIgnoreExtraElements(true);
            cm.SetIgnoreExtraElementsIsInherited(true);
            return cm;
        }

        internal static BsonClassMap<Member> Member(BsonClassMap<Member> cm)
        {
            cm.AutoMap();
            return cm;
        }

        internal static BsonClassMap<Transaction> Transaction(BsonClassMap<Transaction> cm)
        {
            cm.AutoMap();            
            return cm;
        }

        internal static BsonClassMap<Expense> Expense(BsonClassMap<Expense> cm)
        {
            cm.AutoMap();            
            return cm;
        }

        internal static BsonClassMap<Income> Income(BsonClassMap<Income> cm)
        {
            cm.AutoMap();
            return cm;
        }

    }
}
