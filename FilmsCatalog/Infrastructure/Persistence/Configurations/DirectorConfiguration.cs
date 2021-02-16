using FilmsCatalog.Domain.Entities;
using FilmsCatalog.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace FilmsCatalog.Infrastructure.Persistence.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.AddCommonConfigs();

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            var directors = new List<Director>
            {
                new Director
                {
                    Id = 1,
                    Name = "Alec Sulkin",
                    IsNew = true
                },
                new Director
                {
                    Id = 2,
                    Name = "Andrew Sullivan",
                    IsNew = true
                },
                new Director
                {
                    Id = 3,
                    Name = "Victor Salva",
                    IsNew = true
                },
                new Director
                {
                    Id = 4,
                    Name = "Elie Samaha",
                    IsNew = true
                }
            };

            for (int i = 5; i <= 20; i++)
            {
                directors.Add(new Director
                {
                    Id = i,
                    Name = $"Director {i}",
                    IsNew = true
                });
            }

            builder.HasData(directors);
        }
    }
}
