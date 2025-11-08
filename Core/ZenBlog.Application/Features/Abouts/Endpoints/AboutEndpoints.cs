using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Application.Features.Abouts.Queries;

namespace ZenBlog.Application.Features.Abouts.Endpoints
{
    public static class AboutEndpoints
    {
        public static void RegisterAboutEndpoints(this IEndpointRouteBuilder app)
        {
            var abouts = app.MapGroup("/abouts").WithTags("Abouts");

            abouts.MapGet("", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAboutsQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            abouts.MapGet("{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAboutByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            abouts.MapPost("", async (CreateAboutCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            abouts.MapPut("", async (UpdateAboutCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            abouts.MapDelete("{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new RemoveAboutCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();
        }
    }
}

