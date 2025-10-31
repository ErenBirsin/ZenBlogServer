using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    internal class GetReadMessagesQueryHandler(IRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetReadMessagesQuery, BaseResult<List<GetReadMessagesQueryResult>>>
    {
        public async Task<BaseResult<List<GetReadMessagesQueryResult>>> Handle(GetReadMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _repository.GetAllAsync(x=>x.IsRead == true);
            var mappedResult = _mapper.Map<List<GetReadMessagesQueryResult>>(messages);
            return BaseResult<List<GetReadMessagesQueryResult>>.Success(mappedResult);
        }
    }
}
