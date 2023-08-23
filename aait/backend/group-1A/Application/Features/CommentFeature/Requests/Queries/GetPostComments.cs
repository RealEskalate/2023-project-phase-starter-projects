namespace Application.Features.CommentFeatures.Requests.Queries
{
    public class GetCommentsForPostQuery : IRequest<List<CommentDTO>>
    {
        public int PostId { get; set; }
    }
}
