using Application.Contracts.Persistence;
using Application.DTOs.Posts;
using Application.Features.Posts.Handlers.Queries;
using Application.Features.Posts.Requests.Queries;
using Application.Profiles;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Posts.Queries
{
    public class GetPostListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;
        public GetPostListRequestHandlerTests()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPostListTest()
        {
            var handler = new GetAllPostsRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetAllPostsRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<PostContentDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
