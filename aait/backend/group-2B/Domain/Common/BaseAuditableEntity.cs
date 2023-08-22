namespace SocialSync.Domain.Common;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedAt;
    public DateTime LastModified;
}
