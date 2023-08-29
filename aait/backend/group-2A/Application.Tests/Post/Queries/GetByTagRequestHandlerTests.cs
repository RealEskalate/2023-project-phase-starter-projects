using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Handlers.Queries;
using Application.Features.Post.Request.Queries;
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

namespace Application.Tests.Post.Queries
{
    public class GetByTagRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;

        public GetByTagRequestHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetByTag()
        {
            var handler = new GetByTagRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetByTagRequest() { Tag = "Tag 3" }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();

        }
    }
}
