namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentUpdateCommand : IRequest
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
