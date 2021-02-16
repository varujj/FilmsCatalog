namespace FilmsCatalog.Domain.Abstract
{
    public abstract class AggregateRoot
    {
        public int Id { get; set; }
        public bool IsNew { get; set; }
    }
}
