using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FilmsCatalog.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}