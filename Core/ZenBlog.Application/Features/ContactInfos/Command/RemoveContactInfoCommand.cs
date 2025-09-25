using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Command
{
    public record RemoveContactInfoCommand(Guid Id): IRequest<BaseResult<object>>
    {

    }
}
