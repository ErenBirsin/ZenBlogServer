using AutoMapper;
using ZenBlog.Application.Features.Blogs.Results;

namespace ZenBlog.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogMappingProfile, GetBlogsQueryResult>().ReverseMap();
        }
    }
}
