using Application.Contracts;
using Application.DTO.Common;
using Application.Features.PostFeature.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class PostReactionHandler : IRequestHandler<PostReactionCommand, CommonResponseDTO>
    {
        private readonly IPostReactionRepository _postReactionRespository;
        private readonly IMapper _mapper;

        public PostReactionHandler(IPostReactionRepository postReactionRepository, IMapper mapper)
        {
            _postReactionRespository = postReactionRepository;
            _mapper = mapper;
        }
        public async Task<CommonResponseDTO> Handle(PostReactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new ReactionValidator();
            var validationResult = await validator.ValidateAsync(request.ReactionData);

            if (!validationResult.IsValid)
            {
                throw new Exception();
            }

            var postReaction = _mapper.Map<PostReaction>(request.ReactionData);

            var result = await _postReactionRespository.Add(postReaction);
            if (result != null)
            {
                return new CommonResponseDTO()
                {
                    Status = "Success",
                    Message = "Post is reacted successfully"
                };
            }
            else
            {
                return new CommonResponseDTO()
                {
                    Status = "Failure",
                    Message = "Post is not reacted successfully"
                };
            }
        }
    }
}
