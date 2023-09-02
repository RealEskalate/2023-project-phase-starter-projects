using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Handlers.Queries;
using Application.Features.PostFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.PostReactionFeature.Commands
{
    public class GetPostLikesQueryTest
    {            
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

            private readonly IMapper _mapper;
            private ReactionDTO testReaction;
            public GetPostLikesQueryTest()
            {

                _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
                var mapperConfig = new MapperConfiguration(c => 
                {
                    c.AddProfile<MappingProfile>();
                });

                _mapper = mapperConfig.CreateMapper();
                testReaction = new ReactionDTO
                {
                    ReactedId = 1,
                    ReactionType = "like"
                };
            }

        [Fact]
        public async Task ValidGetLikes()
        {
            var mocPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository().Object;
            var mockPostRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new GetPostLikesHandler(_mockUnitOfWork.Object,_mapper);
                         
            var result = await _handler.Handle(new GetPostLikesQuery() {PostId = 1}, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<List<ReactionResponseDTO>>>();
        }

         [Fact]   
        public async Task GetLikesWithInValidId()
        {
            var mocPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository().Object;
            var mockPostRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new GetPostLikesHandler(_mockUnitOfWork.Object,_mapper);
            await Should.ThrowAsync<NotFoundException>(async () =>
               await _handler.Handle(new GetPostLikesQuery() { PostId = 100}, CancellationToken.None));
        }

    }
}