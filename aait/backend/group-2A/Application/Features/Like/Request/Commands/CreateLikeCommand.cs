public class CreateLikeCommand : IRequest<uint>
{
    public int PostId { get; set; }
    public int UserId { get; set; }
}