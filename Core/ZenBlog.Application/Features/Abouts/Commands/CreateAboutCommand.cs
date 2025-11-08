using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Abouts.Commands
{
    public record CreateAboutCommand : IRequest<BaseResult<object>>
    {
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string Description { get; init; }
        public string Content { get; init; }
        public string Images { get; init; }
    }
}
