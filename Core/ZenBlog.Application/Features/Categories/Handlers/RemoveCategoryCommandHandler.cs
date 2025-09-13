using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return BaseResult<bool>.NotFound("Category Not Found");
            }

            _repository.Delete(category);
            var response = await _unitOfWork.SaveChangesAsync();

            return response
                ? BaseResult<bool>.Success(response)
                : BaseResult<bool>.Fail("Category couldn't be deleted");
        }
    }
}
