using Application.DTO.PostDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.PostFeature.Requests.Queries
{
    public class GetPostsByTagQuery : IRequest<BaseResponse<List<PostResponseDTO>>>
    {
        public string TagName {get; set;} = string.Empty;
    }
}