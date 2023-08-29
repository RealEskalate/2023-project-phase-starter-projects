namespace SocialSync.Application.DTOs.PostDtos;

public class CreatePostDto
{
    public int UserId { get; set; }
    public required string Content { get; set; }
}
