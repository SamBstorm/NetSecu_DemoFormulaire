using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetSecu_DemoFormulaire.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Models.Domain.Configurations
{
    public class JeuxConfig : IEntityTypeConfiguration<Jeux>
    {
        public void Configure(EntityTypeBuilder<Jeux> builder)
        {
            builder.ToTable(nameof(Jeux));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nom)
                .IsRequired()
                .HasColumnType("NVARCHAR(75)");

            builder.Property(x => x.Editeur)
                .IsRequired()
                .HasColumnType("NVARCHAR(75)");

            builder.Property(x => x.AnneeSortie)
                .IsRequired()
                .HasColumnType("INTEGER");

            builder.Property(x => x.DateAjout)
                .IsRequired()
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Createur)
                .WithMany(x => x.Jeux)
                .IsRequired()
                .HasForeignKey(x => x.CreateurId);
        }
    }
}
