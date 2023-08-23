namespace Application.Features.CommentFeatures.Requests.Queries
{
    public class GetCommentQuery : IRequest<CommentDTO>
    {
        public int CommentId { get; set; }
    }
}
