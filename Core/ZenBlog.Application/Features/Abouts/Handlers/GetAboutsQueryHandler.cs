using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Abouts.Queries;
using ZenBlog.Application.Features.Abouts.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class GetAboutsQueryHandler : IRequestHandler<GetAboutsQuery, BaseResult<List<GetAboutsQueryResult>>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutsQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResult<List<GetAboutsQueryResult>>> Handle(GetAboutsQuery request, CancellationToken cancellationToken)
        {
            var abouts = await _repository.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetAboutsQueryResult>>(abouts);
            return BaseResult<List<GetAboutsQueryResult>>.Success(mappedResult);
        }
    }
}