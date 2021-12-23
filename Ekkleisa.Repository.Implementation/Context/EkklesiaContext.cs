using Ekkleisa.Repository.Implementation.Mapping;
using Ekklesia.Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ekkleisa.Repository.Implementation.Context
{
    public class EkklesiaContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        private readonly string _connectionString;

        public EkklesiaContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EkklesiaConnection");
            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connection = new SqlConnection(_connectionString);
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.ApplyConfiguration(new MemberMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());
            modelBuilder.ApplyConfiguration(new ExpenseMapping());
            modelBuilder.ApplyConfiguration(new IncomeMapping());
        }
    }
}
