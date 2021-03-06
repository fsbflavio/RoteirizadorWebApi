﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Roterizador.EntityPostgres;

namespace Roterizador.EntityPostgres.Migrations
{
    [DbContext(typeof(RoterizadorContext))]
    partial class RoterizadorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Roterizador.Domain.Model.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_COORDINATE")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("Latitude")
                        .HasColumnName("LATITUDE")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnName("LONGITUDE")
                        .HasColumnType("real");

                    b.Property<int>("RouteId")
                        .HasColumnName("ID_ROUTE")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("ROT_COORDINATES");
                });

            modelBuilder.Entity("Roterizador.Domain.Model.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_ROUTE")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ROT_ROUTES");
                });

            modelBuilder.Entity("Roterizador.Domain.Model.Coordinate", b =>
                {
                    b.HasOne("Roterizador.Domain.Model.Route", "Route")
                        .WithMany("Coordinates")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
