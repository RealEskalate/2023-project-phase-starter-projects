using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;

namespace SocialMediaApp.Application.Features.Users.Handler.Queries
{
    public class GetUserByNameRequestHandler:IRequestHandler<GetUsersByNameRequest, List<UserDto>>
    {
       

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByNameRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersByNameRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetByNameAsync(request.Name);
            return _mapper.Map<List<UserDto>>(users);
        }

        
    }
}