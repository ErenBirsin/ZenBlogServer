using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Command
{
    public record UpdateContactInfoCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string Address { get; init; }
        public string MapUrl { get; set; }
    }
}
