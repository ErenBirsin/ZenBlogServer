namespace ZenBlog.Application.Features.Messages.Result
{
    public class GetUnreadMessagesQueryResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool IsRead { get; set; } 
    }
}
