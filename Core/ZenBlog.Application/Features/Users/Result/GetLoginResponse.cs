namespace ZenBlog.Application.Features.Users.Result
{
    public class GetLoginResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
