namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
