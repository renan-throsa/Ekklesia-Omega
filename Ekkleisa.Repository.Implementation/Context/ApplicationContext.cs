using Ekkleisa.Repository.Implementation.Mapping;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Exceptions;
using Ekklesia.Entities.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Ekkleisa.Repository.Implementation.Context
{
    public class ApplicationContext
    {
        private static bool _MongoMapped = false;

        private readonly DataBaseSettings _baseSettings;

        private IMongoDatabase _dataBase;
        public IMongoDatabase DataBase
        {
            get { return _dataBase ?? (_dataBase = Client.GetDatabase(_baseSettings.Database)); }
        }

        private IMongoClient _client;

        public IMongoClient Client
        {
            get { return _client ??= new MongoClient(MongoClientSettings.FromUrl(new MongoUrl(_baseSettings.ConnectionString))); }
        }

        public ApplicationContext(IOptions<DataBaseSettings> dataBaseSettings)
        {
            _baseSettings = dataBaseSettings.Value;
            if (DataBase == null)
                throw new MongoConnectionFailedException("Não foi possível conectar ao banco de dados.");

            if (!_MongoMapped)
            {
                BsonClassMap.RegisterClassMap<BaseEntity>(cm => MongoMapping.BaseEntity(cm));
                BsonClassMap.RegisterClassMap<Member>(cm => MongoMapping.Member(cm));
                BsonClassMap.RegisterClassMap<Transaction>(cm => MongoMapping.Transaction(cm));
                BsonClassMap.RegisterClassMap<Expense>(cm => MongoMapping.Expense(cm));
                BsonClassMap.RegisterClassMap<Income>(cm => MongoMapping.Income(cm));
                BsonClassMap.RegisterClassMap<Occasion>(cm => MongoMapping.Occasion(cm));
                BsonClassMap.RegisterClassMap<Cult>(cm => MongoMapping.Cult(cm));
                BsonClassMap.RegisterClassMap<SundaySchool>(cm => MongoMapping.SundaySchool(cm));

            }

        }
        
    }
}
