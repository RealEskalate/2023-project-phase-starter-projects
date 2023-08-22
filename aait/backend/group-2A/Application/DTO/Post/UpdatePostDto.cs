using Application.DTO.Common;
using Domain.Entities;

namespace Application.DTO.Post;

public class UpdatePostDto: BaseDto, IPostDto
{
    public int UserId{ get; set; }
    public string Content{ get; set; }
    public List<Tag> Tags{ get; set; }
}