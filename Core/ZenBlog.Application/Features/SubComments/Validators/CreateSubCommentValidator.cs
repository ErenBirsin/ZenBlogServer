using FluentValidation;
using ZenBlog.Application.Features.SubComments.Commands;

namespace ZenBlog.Application.Features.SubComments.Validators
{
    public class CreateSubCommentValidator : AbstractValidator<CreateSubCommentCommand>
    {
        public CreateSubCommentValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("User is required.");
            RuleFor(x=>x.CommentId).NotEmpty().WithMessage("Comment is required.");
            RuleFor(x=>x.Body).NotEmpty().WithMessage("Message body is required.")
                .MaximumLength(200).WithMessage("Comment body must not exceed 200 characters.");
        }
    }
}
