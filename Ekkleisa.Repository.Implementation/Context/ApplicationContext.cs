using Ekkleisa.Repository.Implementation.Mapping;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Exceptions;
using Ekklesia.Entities.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Ekkleisa.Repository.Implementation.Context
{
    public class ApplicationContext
    {
        private readonly DataBaseSettings _baseSettings;
        private static bool _MongoMapped = false;

        private IMongoDatabase _dataBase;
        public IMongoDatabase DataBase
        {
            get { return _dataBase ?? (_dataBase = Cliente.GetDatabase(_baseSettings.DatabaseName)); }
        }

        private IMongoClient _cliente;

        public IMongoClient Cliente
        {
            get { return _cliente ??= new MongoClient(MongoClientSettings.FromUrl(new MongoUrl(_baseSettings.ConnectionString))); }
        }

        public ApplicationContext(IOptions<DataBaseSettings> dataBaseSettings)
        {
            _baseSettings = dataBaseSettings.Value;
            RegisterMongoMap();
            Conectar();
        }

        private void Conectar()
        {
            if (DataBase == null)
                throw new MongoConnectionFailedException("Não foi possível conectar ao banco de dados.");
            ConventionPack pack = new ConventionPack
            {
                new CamelCaseElementNameConvention()
            };
            ConventionRegistry.Register("camelCase", pack, _ => true);
        }

        private void RegisterMongoMap()
        {
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
