using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Abouts.Commands
{
    public record RemoveAboutCommand(Guid Id) : IRequest<BaseResult<object>>;
}
