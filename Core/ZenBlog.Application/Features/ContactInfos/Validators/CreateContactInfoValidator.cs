using FluentValidation;
using ZenBlog.Application.Features.ContactInfos.Command;

namespace ZenBlog.Application.Features.ContactInfos.Validators
{
    public class CreateContactInfoValidator : AbstractValidator<CreateContactInfoCommand>
    {
        public CreateContactInfoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.MapUrl)
                .NotEmpty().WithMessage("Map URL is required.");
        }
    }
}
