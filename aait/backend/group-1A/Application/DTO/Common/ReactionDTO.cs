using Application.Common;

namespace Application.DTO.Common
{
    public class ReactionDTO
    {
        public int ReactedId { get; set; }

        public ReactionEnum ReactionType { get; set; }
    }
}
