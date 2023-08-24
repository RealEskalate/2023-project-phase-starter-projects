using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
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
    public class PostReactionHandler : IRequestHandler<PostReactionCommand, BaseResponse<string>>
    {
        private readonly IPostReactionRepository _postReactionRespository;
        private readonly IMapper _mapper;

        public PostReactionHandler(IPostReactionRepository postReactionRepository, IMapper mapper)
        {
            _postReactionRespository = postReactionRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<string>> Handle(PostReactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new ReactionValidator();
            var validationResult = await validator.ValidateAsync(request.ReactionData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var postReaction = _mapper.Map<PostReaction>(request.ReactionData);
            


            if (request.ReactionData.ReactionType == "like")
            {
                postReaction.Like = true;
            }
            else
            {
                postReaction.Dislike = true;
            }

            postReaction.PostId = request.ReactionData.ReactedId;



            var result = await _postReactionRespository.MakeReaction(request.UserId, postReaction);
            if (result == null)
            {
                throw new BadRequestException("Post is not found"
                );
            }
            
            return new BaseResponse<string>()
            {
                Success = true,
                Message = "Reaction is made successfully"
            };
        }
    }
}
