using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.PostFeature.Handlers.Commands
{
    public class PostReactionHandler : IRequestHandler<PostReactionCommand, BaseResponse<int>>
    {
        private readonly IPostReactionRepository _postReactionRespository;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostReactionHandler(IPostReactionRepository postReactionRepository, IMapper mapper, IPostRepository postRepository)
        {
            _postReactionRespository = postReactionRepository;
            _mapper = mapper;
            _postRepository = postRepository;
        }        
        public async Task<BaseResponse<int>> Handle(PostReactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new ReactionValidator();
            var validationResult = await validator.ValidateAsync(request.ReactionData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var exists = await _postRepository.Exists(request.ReactionData.ReactedId);
            if (exists == false)
            {
                throw new NotFoundException("Post is not found to make the Reactions");
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
                throw new BadRequestException("Post is not found");
            }

            return new BaseResponse<int>()
            {
                Success = true,
                Message = "Reaction is made successfully",
                Value = request.ReactionData.ReactedId
            };
        }
    }
}
