using Application.DTO.PostDTO.DTO;
using FluentValidation;

namespace Application.DTO.PostDTO.validations
{
    public class PostUpdateValidation : AbstractValidator<PostUpdateDTO> 
    {
        public PostUpdateValidation()
        {
            Include(new CommonPostValidation());
        }
    }
}
