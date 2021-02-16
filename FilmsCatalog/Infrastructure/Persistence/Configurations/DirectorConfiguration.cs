﻿using FilmsCatalog.Domain.Entities;
using FilmsCatalog.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsCatalog.Infrastructure.Persistence.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.AddCommonConfigs();

            builder.HasIndex(x => x.Name)
                   .IsUnique();
        }
    }
}
