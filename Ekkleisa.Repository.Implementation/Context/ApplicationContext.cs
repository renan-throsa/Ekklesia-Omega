using Ekkleisa.Repository.Implementation.Mapping;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Exceptions;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Ekkleisa.Repository.Implementation.Context
{
    public class ApplicationContext
    {
        private readonly IConfiguration Configuration;
        private readonly string _connectionString;
        private readonly MongoClientSettings _settings;
        private readonly string _nameDB;        

        private IMongoDatabase _dataBase;
        public IMongoDatabase DataBase
        {
            get { return _dataBase ?? (_dataBase = Cliente.GetDatabase(_nameDB)); }
        }

        private IMongoClient _cliente;

        public IMongoClient Cliente
        {
            get { return _cliente ??= new MongoClient(_settings); }
        }

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetSection("ApplicationContext:ConnectionString").Value;
            _settings = MongoClientSettings.FromUrl(new MongoUrl(_connectionString));
            _nameDB = Configuration.GetSection("ApplicationContext:DatabaseName").Value;
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
            BsonClassMap.RegisterClassMap<BaseEntity>(cm => MongoMapping.BaseEntity(cm));
            BsonClassMap.RegisterClassMap<Member>(cm => MongoMapping.Member(cm));
            BsonClassMap.RegisterClassMap<Transaction>(cm => MongoMapping.Transaction(cm));
            BsonClassMap.RegisterClassMap<Expense>(cm => MongoMapping.Expense(cm));
            BsonClassMap.RegisterClassMap<Income>(cm => MongoMapping.Income(cm));
            //BsonClassMap.RegisterClassMap<Follow>(cm => MongoMapping.Follow(cm));
            //BsonClassMap.RegisterClassMap<Like>(cm => MongoMapping.Like(cm));

        }
    }
}
