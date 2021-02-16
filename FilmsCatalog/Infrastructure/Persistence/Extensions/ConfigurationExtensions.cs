using FilmsCatalog.Domain.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsCatalog.Infrastructure.Persistence.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void AddCommonConfigs<TAggregate>(this EntityTypeBuilder<TAggregate> builder)
                                                                        where TAggregate : AggregateRoot
        {
            builder.Ignore(e => e.IsNew);
        }
    }
}
