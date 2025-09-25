using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Command;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
    {
        private readonly IRepository<ContactInfo> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactCommandHandler(IRepository<ContactInfo> repository,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
           var contactInfo = await _repository.GetByIdAsync(request.Id);
            if(contactInfo is null)
            {
                return BaseResult<object>.Fail("Contact info not found");
            }
            _mapper.Map(request, contactInfo);
            _repository.Update(contactInfo);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Contact Info Updated");
        }
    }
}
