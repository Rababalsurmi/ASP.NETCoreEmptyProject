using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreEmptyProject.Models;

namespace ASP.NETCoreEmptyProject.Data
{
    public class PeopleDBContext : DbContext
    {
        public PeopleDBContext(DbContextOptions<PeopleDBContext> options) : base(options) { }

        public DbSet<PersonModel> People { get; set; }

        public DbSet<CountryModel> Country { get; set; }

        public DbSet<CityModel> City { get; set; }

        public DbSet<LanguageModel> Language { get; set; }

        public DbSet<PeopleCityModel> PeopleCity { get; set; }

        public DbSet<CountryCityModel> CountryCity { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleCityModel>().HasKey(pc => new { pc.PersonId, pc.CityName });
            modelBuilder.Entity<PeopleCityModel>()
                .HasOne(pc => pc.person)
                .WithMany(p => p.PeopleCity)
                .HasForeignKey(pc => pc.PersonId);

            modelBuilder.Entity<PeopleCityModel>()
               .HasOne(pc => pc.city)
               .WithMany(c => c.PeopleCity)
               .HasForeignKey(pc => pc.CityName);


            modelBuilder.Entity<CountryCityModel>().HasKey(cc => new { cc.CountryName, cc.CityName});
            modelBuilder.Entity<CountryCityModel>()
                .HasOne(cc => cc.country)
                .WithMany(c => c.CountryCity)
                .HasForeignKey(cc => cc.CountryName);

            modelBuilder.Entity<CountryCityModel>()
               .HasOne(cc => cc.city)
               .WithMany(c => c.CountryCity)
               .HasForeignKey(cc => cc.CityName);


            modelBuilder.Entity<PersonModel>().HasKey(p => new { p.PersonId });
            modelBuilder.Entity<PersonModel>()
                .Property(p => p.PersonId)
                .HasColumnName("Id")
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "Tom", City = "Skövde", Phone = 0712345678 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "John", City = "Kungälv", Phone = 0712345678 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Jonas", City = "Göteborg", Phone = 0712345678 });


            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryName = "Sweden"});
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryName = "Germany" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryName = "Norway" });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityName = "Stockholm" });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityName = "Frankfurt" });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityName = "Oslo" });

            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Language = "English" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Language = "German" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Language = "Norwegian" });

            modelBuilder.Entity<PeopleCityModel>().HasData(new PeopleCityModel { PersonId = 1, CityName = "Stockholm" });
            modelBuilder.Entity<PeopleCityModel>().HasData(new PeopleCityModel { PersonId = 2, CityName = "Frankfurt" });
            modelBuilder.Entity<PeopleCityModel>().HasData(new PeopleCityModel { PersonId = 3, CityName = "Oslo" });

            modelBuilder.Entity<CountryCityModel>().HasData(new CountryCityModel { CountryName = "Sweden", CityName = "Stockholm" });
            modelBuilder.Entity<CountryCityModel>().HasData(new CountryCityModel { CountryName = "Germany", CityName = "Frankfurt" });
            modelBuilder.Entity<CountryCityModel>().HasData(new CountryCityModel { CountryName = "Norway", CityName = "Oslo" });


        }
    }
}
