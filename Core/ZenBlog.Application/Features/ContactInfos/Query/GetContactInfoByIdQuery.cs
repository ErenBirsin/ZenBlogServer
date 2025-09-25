using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.ContactInfos.Result;

namespace ZenBlog.Application.Features.ContactInfos.Query
{
    public record GetContactInfoByIdQuery(Guid Id): IRequest<BaseResult<GetContactaInfoByIdQueryResult>>
    {
    }
}
