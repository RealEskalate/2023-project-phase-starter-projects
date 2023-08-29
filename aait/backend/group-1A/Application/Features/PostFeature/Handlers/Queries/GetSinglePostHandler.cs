// using Application.Contracts;
// using Application.DTO.PostDTO.DTO;
// using Application.Exceptions;
// using Application.Features.PostFeature.Requests.Queries;
// using Application.Response;
// using AutoMapper;
// using MediatR;


// namespace Application.Features.PostFeature.Handlers.Queries
// {
//     public class GetSinglePostHandler : IRequestHandler<GetSinglePostQuery, BaseResponse<PostResponseDTO>>
//     {
//         private readonly IPostRepository _postRepository;
//         private readonly IMapper _mapper;

//         public GetSinglePostHandler(IPostRepository postRepository, IMapper mapper)
//         {
//             _postRepository = postRepository;
//             _mapper = mapper;
//         }
//         public async Task<BaseResponse<PostResponseDTO>> Handle(GetSinglePostQuery request, CancellationToken cancellationToken)
//         {
//             var result = await _postRepository.Get(request.Id);
//             if (result == null)
//             {
//                 throw new NotFoundException("Post is not found");
//             }

//             var post = _mapper.Map<PostResponseDTO>(result);
//             post.Like = result.PostReactions.Where(x => x.Like == true).Count();
//             post.Dislike = result.PostReactions.Where(x => x.Like == false).Count();
            
//             return new BaseResponse<PostResponseDTO>{
//                 Success = true,
//                 Message = "Post is retrieved successfully",
//                 Value = post
//             };
            
//         }
//     }
// }
