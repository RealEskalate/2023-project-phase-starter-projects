using Application.DTO.PostDTO.DTO;
using FluentValidation;


namespace Application.DTO.PostDTO.validations
{
    public class PostCreateValidation : AbstractValidator<PostCreateDTO>
    {
        public PostCreateValidation()
        {
            Include(new CommonPostValidation());
        }
    }
}
