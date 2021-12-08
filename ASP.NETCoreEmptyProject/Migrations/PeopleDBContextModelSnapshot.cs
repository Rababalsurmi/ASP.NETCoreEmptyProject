﻿// <auto-generated />
using ASP.NETCoreEmptyProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP.NETCoreEmptyProject.Migrations
{
    [DbContext(typeof(PeopleDBContext))]
    partial class PeopleDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.CityModel", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CurrentCountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CurrentCountryId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Stockholm",
                            CurrentCountryId = 1
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Frankfurt",
                            CurrentCountryId = 2
                        },
                        new
                        {
                            CityId = 3,
                            CityName = "Oslo",
                            CurrentCountryId = 3
                        });
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.CountryCityModel", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("CountryId", "CityId");

                    b.HasIndex("CityId");

                    b.ToTable("CountryCityModel");
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.CountryModel", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Sweden"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Germany"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Norway"
                        });
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.LanguageModel", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Language = "English"
                        },
                        new
                        {
                            LanguageId = 2,
                            Language = "German"
                        },
                        new
                        {
                            LanguageId = 3,
                            Language = "Norwegian"
                        });
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.PeoplLanguagesModel", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PeopleLanguages");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 1,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 2
                        },
                        new
                        {
                            PersonId = 2,
                            LanguageId = 3
                        });
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.PeopleCityModel", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("PersonId", "CityId");

                    b.HasIndex("CityId");

                    b.ToTable("PeopleCityModel");
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.PersonModel", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(10)
                        .HasDefaultValue(0);

                    b.Property<int>("CurrentCityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Phone")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("PersonId");

                    b.HasIndex("CurrentCityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CurrentCityId = 1,
                            Name = "Tom",
                            Phone = 712345678
                        },
                        new
                        {
                            PersonId = 2,
                            CurrentCityId = 2,
                            Name = "John",
                            Phone = 712345678
                        },
                        new
                        {
                            PersonId = 3,
                            CurrentCityId = 3,
                            Name = "Jonas",
                            Phone = 712345678
                        });
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.CityModel", b =>
                {
                    b.HasOne("ASP.NETCoreEmptyProject.Models.CountryModel", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CurrentCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.CountryCityModel", b =>
                {
                    b.HasOne("ASP.NETCoreEmptyProject.Models.CityModel", "city")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.NETCoreEmptyProject.Models.CountryModel", "country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.PeoplLanguagesModel", b =>
                {
                    b.HasOne("ASP.NETCoreEmptyProject.Models.LanguageModel", "language")
                        .WithMany("PeopleLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.NETCoreEmptyProject.Models.PersonModel", "person")
                        .WithMany("PeopleLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.PeopleCityModel", b =>
                {
                    b.HasOne("ASP.NETCoreEmptyProject.Models.CityModel", "city")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.NETCoreEmptyProject.Models.PersonModel", "person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.NETCoreEmptyProject.Models.PersonModel", b =>
                {
                    b.HasOne("ASP.NETCoreEmptyProject.Models.CityModel", "City")
                        .WithMany("People")
                        .HasForeignKey("CurrentCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
