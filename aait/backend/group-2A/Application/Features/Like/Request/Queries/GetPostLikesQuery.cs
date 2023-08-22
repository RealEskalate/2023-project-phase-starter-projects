public class GetPostLikesQuery : IRequest<List<Like>>
{
    public int PostId { get; set; }
}