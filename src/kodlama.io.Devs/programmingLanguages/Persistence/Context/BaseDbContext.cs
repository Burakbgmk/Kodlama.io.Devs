using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.ProgrammingParadigm).HasColumnName("ProgrammingParadigm");
                a.Property(p => p.DebutTime).HasColumnName("DebutTime");
                a.Property(p => p.CurrentVersion).HasColumnName("CurrentVersion");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.DebutTime).HasColumnName("DebutTime");
                a.Property(p => p.CurrentVersion).HasColumnName("CurrentVersion");
                a.HasOne(p => p.ProgrammingLanguage);
            });


            ProgrammingLanguage[] programmingLanguagesSeeds =
            {
                new(1,"C#","A very powerful language for backend and game development","Object Oriented",new DateTime(2000,1,1),"9.0"),
                new(2,"Pyhton","Super user friendly and general purpose","Object Oriented",new DateTime(1990,1,1),"3.9.4")
            };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesSeeds);

            Technology[] technologiesSeeds =
            {
                new(1,1,".NET","A well designed C# framework for backend developers",new DateTime(2022,1,1),"7.0"),
                new(2,2,"Pandas","Powerful data analysis framework",new DateTime(2008,1,11),"1.4.4")
            };
            modelBuilder.Entity<Technology>().HasData(technologiesSeeds);

        }

    }
}
