using Application.Contracts;
using Application.DTO.Common;
using Application.Features.PostFeature.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, CommonResponseDTO>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<CommonResponseDTO> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0) 
            {
                throw new Exception();
            }
            var result = await _postRepository.Delete(request.Id);

            if (result == false)
            {
                return new CommonResponseDTO
                {
                    Status = "Failure",
                    Message = "Post is not deleted successfully"
                };
            }

            return new CommonResponseDTO
            {
                Status = "Success",
                Message = "Post is  deleted successfully"
            };
        }
    }
}
