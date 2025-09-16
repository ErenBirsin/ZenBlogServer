using MediatR;
using ZenBlog.Application.Features.Users.Commands;

namespace ZenBlog.API.Endpoints.Registration
{
    public static class UserEndpoints
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder builder)
        {
            var user = builder.MapGroup("/users").WithTags("Users");

            user.MapPost("register", async (IMediator mediator, CreateUserCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
