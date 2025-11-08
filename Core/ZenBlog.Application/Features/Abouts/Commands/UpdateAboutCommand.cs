using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Abouts.Commands
{
    public record UpdateAboutCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string Description { get; init; }
        public string Content { get; init; }
        public string Images { get; init; }
    }
}
