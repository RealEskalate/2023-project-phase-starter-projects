using Application.Contracts.Persistence;
using Application.DTOs.Posts;
using Application.Features.Posts.Handlers.Commands;
using Application.Features.Posts.Requests.Commands;
using Application.Profiles;
using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Responses;
using SocialSync.Application.Tests.Mocks;
using SocialSync.Application.Tests.Mocks.PostMock.PostMock;

namespace SocialSync.Application.UnitTests.Posts.Commands
{
    public class CreatePostCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreatePostDto _postDto;
        private readonly CreatePostRequestHandler _handler;

        public CreatePostCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreatePostRequestHandler(_mockUow.Object, _mapper);

            _postDto = new CreatePostDto
            {
                UserId =  3,
                Title = "end game",
                Content = "nothing"
            };
        }

        [Fact]
        public async Task Valid_Post_Added()
        {
            var result = await _handler.Handle(new CreatePostRequest() { Post = _postDto }, CancellationToken.None);

            var posts = await _mockUow.Object.PostRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            posts.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Post_Added()
        {
            var _postDto = new CreatePostDto{
                UserId =  0,
                Title = "",
                Content = ""
            };

            var result = await _handler.Handle(new  CreatePostRequest() { Post = _postDto }, CancellationToken.None);

            var posts = await _mockUow.Object.PostRepository.GetAll();
            
            posts.Count.ShouldBe(3);

            result.ShouldBeOfType<BaseCommandResponse>();            
        }
    }
}
