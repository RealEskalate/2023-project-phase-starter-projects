using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Tag.TagName), IsUnique = true)]
public class Tag : BaseEntity
{
    public string TagName { get; set; } = string.Empty;
}