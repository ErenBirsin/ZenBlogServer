using Microsoft.AspNetCore.Identity;

namespace ZenBlog.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
        public virtual IList<Comment> Comments { get; set; } // Bu son 3 property ' de 1' e çok ilişki kurmuş olduk .
        public virtual IList<SubComment> SubComments { get; set; }
    }
}
