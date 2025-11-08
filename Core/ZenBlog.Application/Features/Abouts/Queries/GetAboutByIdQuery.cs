using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Abouts.Result;

namespace ZenBlog.Application.Features.Abouts.Queries
{
    public record GetAboutByIdQuery(Guid Id) : IRequest<BaseResult<GetAboutByIdQueryResult>>;
}
