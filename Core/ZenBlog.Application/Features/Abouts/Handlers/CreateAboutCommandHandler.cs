using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class CreateAboutCommandHandler(IRepository<About> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = _mapper.Map<About>(request);
            await _repository.CreateAsync(about);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(about);    
        }
    }
}
