using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, BaseResult<object>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAboutCommandHandler(IRepository<About> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResult<object>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id);
            if(about == null)
            {
                return BaseResult<object>.NotFound("About not found");
            }
            about = _mapper.Map(request, about);
            _repository.Update(about);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("About Updated Successfully");
        }
    }
}
