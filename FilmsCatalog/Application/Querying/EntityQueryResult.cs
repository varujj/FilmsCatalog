using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmsCatalog.Application.Querying
{
    public class EntityQueryResult<TEntity>
    {
        public List<TEntity> Data { get; set; }
        public int Count { get; set; }

        public EntityQueryResult<TResult> ConvertTo<TResult>(Func<TEntity, TResult> projection)
        {
            return new EntityQueryResult<TResult>
            {
                Count = Count,
                Data = Data.Select(projection).ToList()
            };
        }
    }
}
