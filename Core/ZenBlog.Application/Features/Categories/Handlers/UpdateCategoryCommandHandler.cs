// Update the handler to use UpdateCategoryCommand
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            repository.Update(category);
            var response = await unitOfWork.SaveChangesAsync();

            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Category couldn't be updated");
        }
    }
}