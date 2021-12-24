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
        public DbSet<Occasion> Occasions { get; set; }
        public DbSet<Report> Reports { get; set; }

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

            modelBuilder.ApplyConfiguration(new OccasionMapping());
            modelBuilder.ApplyConfiguration(new AtypicalMapping());
            modelBuilder.ApplyConfiguration(new BaptismMapping());
            modelBuilder.ApplyConfiguration(new CellMapping());
            modelBuilder.ApplyConfiguration(new CultMapping());
            modelBuilder.ApplyConfiguration(new ReunionMapping());
            modelBuilder.ApplyConfiguration(new SundaySchoolMapping());
            modelBuilder.ApplyConfiguration(new OccasionMemberMapping());

            
            modelBuilder.ApplyConfiguration(new ReportMapping());
            modelBuilder.ApplyConfiguration(new BiblicalReportMpping());
            modelBuilder.ApplyConfiguration(new CellReportMapping());
            modelBuilder.ApplyConfiguration(new GroupReportMapping());

        }
    }
}
