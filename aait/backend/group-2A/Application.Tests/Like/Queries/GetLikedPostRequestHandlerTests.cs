using Application.Contracts.Persistance;
using Application.DTO.Like;
using Application.DTO.Post;
using Application.Features.Like.Handlers.Query;
using Application.Features.Like.Request.Queries;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Like.Queries
{
    public class GetLikedPostRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        public GetLikedPostRequestHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLikedPost()
        {
            var handler = new GetLikedPostRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLikedPostRequest() { Id = 2}, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();

        }
    }
}
