using Application.Common;
using Application.Contracts;
using Application.DTO.Common;
using Application.Features.UserFeature.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeature.Handlers.Commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, CommonResponseDTO>
    {
        private readonly IUserRepository _UserRepository;

        public DeleteUserHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public async Task<CommonResponseDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var deleteResponse = new CommonResponseDTO();
            var user = await _UserRepository.Get(request.userId);
            if (user == null)
            {
                deleteResponse.Status = "Faliure";
                deleteResponse.Message = "The User doesn't exist";
                return deleteResponse;
            }
            
            var result = await _UserRepository.Delete(user!);

            deleteResponse.Status = "Success";
            deleteResponse.Message = "User is  deleted successfully";

            return deleteResponse;
        }
    }
}
