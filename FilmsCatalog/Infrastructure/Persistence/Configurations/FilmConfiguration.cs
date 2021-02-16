using FilmsCatalog.Domain.Entities;
using FilmsCatalog.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsCatalog.Infrastructure.Persistence.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.AddCommonConfigs();
        }
    }
}
