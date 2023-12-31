﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetSecu_DemoFormulaire.Models.Domain;

#nullable disable

namespace NetSecu_DemoFormulaire.Models.Domain.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    partial class SampleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NetSecu_DemoFormulaire.Models.Entities.Jeux", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<int>("AnneeSortie")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CreateurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAjout")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Editeur")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(75)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(75)");

                    b.HasKey("Id");

                    b.HasIndex("CreateurId");

                    b.ToTable("Jeux", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fcd0fbd4-7cc8-4128-8678-b3989f993245"),
                            AnneeSortie = 1985,
                            CreateurId = new Guid("9b2abfba-2451-44d1-9f92-c34e0d6b7413"),
                            DateAjout = new DateTime(2023, 10, 6, 12, 15, 14, 130, DateTimeKind.Local).AddTicks(2762),
                            Editeur = "Nintendo",
                            Nom = "Super Mario Bros."
                        });
                });

            modelBuilder.Entity("NetSecu_DemoFormulaire.Models.Entities.Utilisateur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(384)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(75)");

                    b.Property<byte[]>("Passwd")
                        .IsRequired()
                        .HasColumnType("BINARY(64)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(75)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Utilisateur", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b2abfba-2451-44d1-9f92-c34e0d6b7413"),
                            Email = "admin@tftic.be",
                            Nom = "Admin",
                            Passwd = new byte[] { 151, 182, 117, 90, 55, 44, 163, 172, 117, 79, 4, 131, 65, 174, 132, 14, 218, 225, 31, 177, 170, 205, 65, 145, 193, 45, 196, 240, 240, 224, 71, 113, 163, 173, 49, 14, 250, 197, 33, 112, 38, 87, 146, 30, 225, 254, 188, 249, 178, 194, 130, 181, 205, 144, 131, 48, 131, 74, 171, 253, 85, 168, 89, 55 },
                            Prenom = "Admin"
                        });
                });

            modelBuilder.Entity("NetSecu_DemoFormulaire.Models.Entities.Jeux", b =>
                {
                    b.HasOne("NetSecu_DemoFormulaire.Models.Entities.Utilisateur", "Createur")
                        .WithMany("Jeux")
                        .HasForeignKey("CreateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Createur");
                });

            modelBuilder.Entity("NetSecu_DemoFormulaire.Models.Entities.Utilisateur", b =>
                {
                    b.Navigation("Jeux");
                });
#pragma warning restore 612, 618
        }
    }
}
