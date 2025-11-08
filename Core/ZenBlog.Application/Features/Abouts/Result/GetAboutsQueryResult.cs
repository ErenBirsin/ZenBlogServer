using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Abouts.Result
{
    public class GetAboutsQueryResult : BaseDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
    }
}
