using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Features.UserFeature.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeature.Handlers.Queries
{
    public class GetAllUserHandler : IRequestHandler<GetAllUsersQuery, List<UserResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<UserResponseDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetAllUsers();

            return _mapper.Map<List<UserResponseDTO>>(result);
        }
    }
}
