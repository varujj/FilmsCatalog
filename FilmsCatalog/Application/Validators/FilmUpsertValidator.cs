using FilmsCatalog.Application.Dtos;
using FluentValidation;
using System;

namespace FilmsCatalog.Application.Validators
{
    public class FilmUpsertValidator : AbstractValidator<FilmDto>
    {
        public FilmUpsertValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Имя должно быть заполнено")
                .MinimumLength(5).WithMessage("Минимальная длина имени 5 символов")
                .MaximumLength(100).WithMessage("Максимальная длина имени 100 символов");

            RuleFor(f => f.Description)
                 .NotEmpty().WithMessage("Описание обязательное")
                 .MaximumLength(500).WithMessage("Максимальная длина описания 500 символов");

            RuleFor(f => f.Year)
                .GreaterThan(1500).WithMessage("Год должен быть выше 1500")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Год не может быть выше текущего");

            RuleFor(f => f.DirectorId)
                .NotEmpty().WithMessage("Выбор режиссера обязателен");

            RuleFor(f => f.Poster)
                .Must(poster => FileValidator.ValidateImage(poster))
                .When(f => f.Poster != null)
                .WithMessage("Выбранный файл не валиден");
        }
    }
}
