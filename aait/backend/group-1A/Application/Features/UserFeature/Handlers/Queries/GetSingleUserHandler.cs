using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Exceptions;
using Application.Features.UserFeature.Requests.Queries;
using AutoMapper;
using MediatR;


namespace Application.Features.UserFeature.Handlers.Queries
{
    public class GetSingleUserHandler : IRequestHandler<GetSingleUserQuery, UserResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> Handle(GetSingleUserQuery request, CancellationToken cancellationToken)
        {
            if (request.userId <= 0)
            {
                throw new BadRequestException("Id is not correct");
            }
            var result = await _unitOfWork.UserRepository.Get(request.userId);

            if (result == null)
            {
                throw new NotFoundException("User not found");
            }

            var User = _mapper.Map<UserResponseDTO>(result);
            return User;
        }
    }
}
