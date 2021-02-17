using FluentValidation;
using System.Linq;

namespace FilmsCatalog.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static bool Validate<T>(this AbstractValidator<T> validator, T instance, out string msg)
        {
            msg = "";

            var result = validator.Validate(instance);

            if (!result.IsValid)
            {
                var errorNumber = 1;
                var errors = result.Errors.ToDictionary(e => e.PropertyName + " " + errorNumber++,
                                                        e => e.ErrorMessage);

                msg = string.Join(", ", errors.Values);
            }

            return result.IsValid;
        }
    }
}
