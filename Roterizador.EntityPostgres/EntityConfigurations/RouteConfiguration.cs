using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roterizador.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Persistence.EntityConfigurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("ROT_ROUTES");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID_ROUTE")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnName("DESCRICAO");

            builder.HasMany(e => e.Coordinates)
                .WithOne(e => e.Route)
                .HasForeignKey(e => e.RouteId);
        }
    }
}
