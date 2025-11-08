using FluentValidation;
using ZenBlog.Application.Features.Abouts.Commands;

namespace ZenBlog.Application.Features.Abouts.Validators
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutCommand>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(2, 100).WithMessage("Title must be between 2 and 100 characters.");

            RuleFor(x => x.SubTitle)
                .NotEmpty().WithMessage("SubTitle is required.")
                .Length(2, 200).WithMessage("SubTitle must be between 2 and 200 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.Images)
                .NotEmpty().WithMessage("Images is required.");
        }
    }
}

