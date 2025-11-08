using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; } 
        public string SubTitle { get; set; } 
        public string Description { get; set; } 
        public string Content { get; set; } 
        public string Images { get; set; } 
    }
}
