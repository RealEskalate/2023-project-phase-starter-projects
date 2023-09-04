namespace Application.DTO.UserDTO.DTO
{
    public class UserCreateDTO : IBaseUserDTO
    {
        public int Id {get; set;}
        public string? Username { get ; set ; }
        public string? Email { get ; set ; }
        public string? Password { get ; set ; }
    }
}
