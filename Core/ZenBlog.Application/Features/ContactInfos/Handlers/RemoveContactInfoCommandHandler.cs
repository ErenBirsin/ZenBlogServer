using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Command;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contacInfo = await _repository.GetByIdAsync(request.Id);
            if(contacInfo == null)
            {
                return BaseResult<object>.Fail("Contact info not found");
            }
            _repository.Delete(contacInfo);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Contact Info Removed");
        }
    }
}
