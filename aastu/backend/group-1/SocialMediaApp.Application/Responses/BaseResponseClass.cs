namespace SocialMediaApp.Application.Responses;

public class BaseResponseClass
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    public List<string> Errors { get; set; }
}
