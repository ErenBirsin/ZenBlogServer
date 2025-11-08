using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand, BaseResult<object>>
    {
        private readonly IRepository<About> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAboutCommandHandler(IRepository<About> repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<object>> Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id);
            if(about == null)
            {
                return BaseResult<object>.NotFound("About not found");
            }
            _repository.Delete(about);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("About Removed Successfully");
        }
    }
}
