﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roterizador.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Persistence.EntityConfigurations
{
    public class CoordinateConfiguration : IEntityTypeConfiguration<Coordinate>
    {
        public void Configure(EntityTypeBuilder<Coordinate> builder)
        {
            builder.ToTable("ROT_COORDINATES");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID_COORDINATE")
                .IsRequired();
        }
    }
}
