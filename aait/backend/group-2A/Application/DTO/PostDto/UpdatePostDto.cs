using Application.DTO.Common;
using Domain.Entities;

namespace Application.DTO.Post;

public class UpdatePostDto: BaseDto, IPostDto
{
    public required int UserId{ get; set; }
    public required string Content{ get; set; }
    public List<string> Tags{ get; set; }
}