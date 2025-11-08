using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Abouts.Queries;
using ZenBlog.Application.Features.Abouts.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class GetAboutByIdQueryHandler: IRequestHandler<GetAboutByIdQuery, BaseResult<GetAboutByIdQueryResult>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutByIdQueryHandler(IRepository<About> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResult<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id);
            if(about == null)
            {
                return BaseResult<GetAboutByIdQueryResult>.NotFound("About not found");
            }

            var result = _mapper.Map<GetAboutByIdQueryResult>(about);
            return BaseResult<GetAboutByIdQueryResult>.Success(result);
        }
    }
}
