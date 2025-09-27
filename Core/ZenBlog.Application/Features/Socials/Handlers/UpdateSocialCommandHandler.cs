using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class UpdateSocialCommandHandler(IRepository<Social> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateSocialCommand, BaseResult<object>>
    {
   
        public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var social = await repository.GetByIdAsync(request.Id);
            if(social == null)
            {
                return BaseResult<object>.NotFound("Social not found");
            }
            mapper.Map(request, social);
             repository.Update(social);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Social Updated Successfully");

        }
    }
}
