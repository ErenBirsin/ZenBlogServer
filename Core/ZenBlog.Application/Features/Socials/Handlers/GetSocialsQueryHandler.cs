﻿using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class GetSocialsQueryHandler(IRepository<Social> _repository,IMapper _mapper): IRequestHandler<GetSocialsQuery, BaseResult<List<GetSocialsQueryResult>>>
    {
        public async Task<BaseResult<List<GetSocialsQueryResult>>> Handle(GetSocialsQuery request, CancellationToken cancellationToken)
        {
            var socials = await _repository.GetAllAsync();
            var socialsResult = _mapper.Map<List<GetSocialsQueryResult>>(socials);
            return BaseResult<List<GetSocialsQueryResult>>.Success(socialsResult);
        }
    }
}
