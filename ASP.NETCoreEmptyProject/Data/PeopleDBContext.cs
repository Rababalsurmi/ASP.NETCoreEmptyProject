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

        public DbSet<LanguageModel> Languages { get; set; }

        //public DbSet<PeopleCityModel> PeopleCity { get; set; }

        //public DbSet<CountryCityModel> CountryCity { get; set; }

        public DbSet<PeoplLanguagesModel> PeopleLanguages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //People and City Relationship
            modelBuilder.Entity<PeopleCityModel>().HasKey(pc => new { pc.PersonId, pc.CityId });
            modelBuilder.Entity<PersonModel>()
                .HasOne<CityModel>(p => p.City)
                .WithMany(c => c.People)
                .HasForeignKey(p => p.CurrentCityId);

            //modelBuilder.Entity<PeopleCityModel>()
            //   .HasOne(pc => pc.city)
            //   .WithMany(c => c.PeopleCity)
            //   .HasForeignKey(pc => pc.CityId);

            //Country and City Relationship
            modelBuilder.Entity<CountryCityModel>().HasKey(cc => new { cc.CountryId, cc.CityId });
            modelBuilder.Entity<CityModel>()
                .HasOne<CountryModel>(city => city.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(city => city.CurrentCountryId);

            //modelBuilder.Entity<CountryCityModel>()
            //   .HasOne(cc => cc.city)
            //   .WithMany(c => c.CountryCity)
            //   .HasForeignKey(cc => cc.CityId);

            //People and Languages Relationship
            modelBuilder.Entity<PeoplLanguagesModel>().HasKey(pl => new { pl.PersonId, pl.Language });
            modelBuilder.Entity<PeoplLanguagesModel>()
              .HasOne(pl => pl.person)
              .WithMany(p => p.PeopleLanguages)
              .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PeoplLanguagesModel>()
             .HasOne(pl => pl.language)
             .WithMany(l => l.PeopleLanguages)
             .HasForeignKey(pl => pl.Language);

            //People
            modelBuilder.Entity<PersonModel>().HasKey(p => new { p.PersonId });
            modelBuilder.Entity<PersonModel>()
                .Property(p => p.PersonId)
                .HasColumnName("Id")
                .HasDefaultValue(0)
                .IsRequired();

            //Seeding People

            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "Tom", Phone = 0712345678, CurrentCityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "John", Phone = 0712345678, CurrentCityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Jonas", Phone = 0712345678, CurrentCityId = 3 });

            //modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "Tom", City = "Skövde", Phone = 0712345678 });
            //modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "John", City = "Kungälv", Phone = 0712345678 });
            //modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Jonas", City = "Göteborg", Phone = 0712345678 });

            //Seeding Countries
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 001, CountryName = "Sweden"});
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 002, CountryName = "Germany" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 003, CountryName = "Norway" });
            

            //Seeding Cities
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 1, CityName = "Stockholm" , CurrentCountryId = 001});
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 2 ,CityName = "Frankfurt", CurrentCountryId = 002 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 3, CityName = "Oslo" , CurrentCountryId = 003});

            //Seeding Languages
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Language = "English" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Language = "German" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { Language = "Norwegian" });

            //Seeding People and Cities
            //modelBuilder.Entity<PeopleCityModel>().HasData(new PeopleCityModel { PersonId = 1, CityId = 1 });
            //modelBuilder.Entity<PeopleCityModel>().HasData(new PeopleCityModel { PersonId = 2, CityId = 2 });
            //modelBuilder.Entity<PeopleCityModel>().HasData(new PeopleCityModel { PersonId = 3, CityId = 3 });

            ////Seeding Countries and Cities
            //modelBuilder.Entity<CountryCityModel>().HasData(new CountryCityModel { CountryId = 001, CityId = 1});
            //modelBuilder.Entity<CountryCityModel>().HasData(new CountryCityModel { CountryId = 002, CityId = 2 });
            //modelBuilder.Entity<CountryCityModel>().HasData(new CountryCityModel { CountryId = 003, CityId = 3 });

            //Seeding People and Languages
            modelBuilder.Entity<PeoplLanguagesModel>().HasData(new PeoplLanguagesModel { PersonId = 1, Language = "English" });
            modelBuilder.Entity<PeoplLanguagesModel>().HasData(new PeoplLanguagesModel { PersonId = 1, Language = "Norwegian" });
            modelBuilder.Entity<PeoplLanguagesModel>().HasData(new PeoplLanguagesModel { PersonId = 3, Language = "English" });
            modelBuilder.Entity<PeoplLanguagesModel>().HasData(new PeoplLanguagesModel { PersonId = 3, Language = "German" });
            modelBuilder.Entity<PeoplLanguagesModel>().HasData(new PeoplLanguagesModel { PersonId = 2, Language = "Norwegian" });

        }
    }
}
