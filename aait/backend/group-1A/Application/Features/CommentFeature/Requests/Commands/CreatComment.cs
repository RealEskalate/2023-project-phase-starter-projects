namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentCreateCommand : IRequest<int>
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
