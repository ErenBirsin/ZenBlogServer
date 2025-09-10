using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands;

public record CreateCategoryCommand(string CategoryName) : IRequest<BaseResult<bool>>; // record ile değerler bir kere set edilsin bir daha set edilemesin.

