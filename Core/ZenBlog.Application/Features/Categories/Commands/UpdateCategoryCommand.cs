using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands;

public record UpdateCategoryCommand(Guid id,string categoryName) : IRequest<BaseResult<bool>>;
