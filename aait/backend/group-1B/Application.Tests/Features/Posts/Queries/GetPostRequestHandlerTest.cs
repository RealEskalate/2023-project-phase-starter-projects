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
    public class GetPostListCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;
        public GetPostListCommandHandlerTests()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPostTypeListTest()
        {
            var handler = new GetPostRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetPostRequest(){Id = 1}, CancellationToken.None);

            result.ShouldBeOfType<Post>();

            result.Id.ShouldBe(1);
        }
    }
}
