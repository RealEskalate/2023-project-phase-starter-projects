using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Users.Validators;
using Application.Features.Users.Requests.Commands;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SocialSync.Application.Contracts.Persistence;

namespace Application.Features.Users.Handlers.Commands
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCommand, Unit>
    {
    private readonly IUnitOfWork _unitOfWork;

        public UserDeleteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            

            var user = await _unitOfWork.UserRepository.GetAsync(request.UserDleteDto.Id);
            if (user != null){
                await _unitOfWork.UserRepository.DeleteAsync(user);


            }
            else{
                throw new Exception();
            }

            return Unit.Value;
        }
    }
}
