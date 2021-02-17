using System;

namespace FilmsCatalog.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg)
        {

        }
    }
}
