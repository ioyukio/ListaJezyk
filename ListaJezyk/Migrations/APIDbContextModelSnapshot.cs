﻿// <auto-generated />
using ListaJezyk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ListaJezyk.Migrations
{
    [DbContext(typeof(APIDbContext))]
    partial class APIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ListaJezyk.Models.Jezyk", b =>
                {
                    b.Property<int>("JezykId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataRozpoczecia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("JezykNazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KategoriaId");

                    b.Property<string>("Ocena")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("JezykId");

                    b.ToTable("Jezyki");
                });

            modelBuilder.Entity("ListaJezyk.Models.Kategoria", b =>
                {
                    b.Property<int>("KategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KategoriaNazwa")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KategoriaId");

                    b.ToTable("Kategorie");
                });
#pragma warning restore 612, 618
        }
    }
}
