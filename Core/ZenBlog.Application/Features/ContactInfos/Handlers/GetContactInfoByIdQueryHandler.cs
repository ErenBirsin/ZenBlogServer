using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.ContactInfos.Query;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class GetContactInfoByIdQueryHandler(IRepository<ContactInfo> _repository, IMapper _mapper)
    : IRequestHandler<GetContactInfoByIdQuery, BaseResult<GetContactaInfoByIdQueryResult>>
    {
        public async Task<BaseResult<GetContactaInfoByIdQueryResult>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var contactInfo = await _repository.GetByIdAsync(request.Id);
            if (contactInfo == null)
            {
                return BaseResult<GetContactaInfoByIdQueryResult>.NotFound("Contact info not found.");
            }

            var result = _mapper.Map<GetContactaInfoByIdQueryResult>(contactInfo);
            return BaseResult<GetContactaInfoByIdQueryResult>.Success(result);
        }
    }
}
