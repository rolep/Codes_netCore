﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using codes_netCore.Models;

namespace codes_netCore.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("codes_netCore.Models.Code", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<int>("NetworkId");

                    b.Property<string>("R");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NetworkId");

                    b.ToTable("Codes");
                });

            modelBuilder.Entity("codes_netCore.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hex");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("codes_netCore.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("codes_netCore.Models.Network", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColorId");

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("CountryId");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("codes_netCore.Models.Code", b =>
                {
                    b.HasOne("codes_netCore.Models.Country", "Country")
                        .WithMany("Codes")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codes_netCore.Models.Network", "Network")
                        .WithMany("Codes")
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("codes_netCore.Models.Network", b =>
                {
                    b.HasOne("codes_netCore.Models.Color", "Color")
                        .WithMany("Networks")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("codes_netCore.Models.Country", "Country")
                        .WithMany("Networks")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
