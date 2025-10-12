using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Contracts.Persistence
{
    public interface IJwtService
    {
        Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result);
    }
}
