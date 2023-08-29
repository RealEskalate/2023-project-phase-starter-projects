// using Application.Contracts;
// using Application.DTO.PostDTO.DTO;
// using Application.Features.PostFeature.Requests.Queries;
// using Application.Response;
// using AutoMapper;
// using MediatR;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace Application.Features.PostFeature.Handlers.Queries
// {
//     public class GetAllPostHandler : IRequestHandler<GetAllPostsQuery, BaseResponse<List<PostResponseDTO>>>
//     {
//         private readonly IPostRepository _postRepository;
//         private readonly IMapper _mapper;

//         public GetAllPostHandler(IPostRepository postRepository, IMapper mapper)
//         {
//             _postRepository = postRepository;
//             _mapper = mapper;
//         }
//         public async Task<BaseResponse<List<PostResponseDTO>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
//         {
//             var result = await _postRepository.GetAllPostsWithReaction(request.userId);
//             return new BaseResponse<List<PostResponseDTO>> {
//                 Success = true,
//                 Message = "Posts are retrieved successfully",
//                 Value = _mapper.Map<List<PostResponseDTO>>(result)
//             };
//         }
//     }
// }
