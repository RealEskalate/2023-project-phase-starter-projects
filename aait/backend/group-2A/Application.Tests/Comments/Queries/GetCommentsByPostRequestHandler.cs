using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.Comment.Requests.Queries;
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

namespace Application.Tests.Comments.Queries
{
    public class GetCommentsByPostRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;

        public GetCommentsByPostRequestHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCommentByPostIdTest()
        {
            var handler = new GetCommentsByPostIdRequestHandler(_mockRepo.Object, _mapper);
            var temp = new GetCommentsByPostIdRequest();
            temp.PostId = 1;

            var result = await handler.Handle(temp, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<List<CommentDto>>>();

            result.Value.Count.ShouldBe(3);

        }

    }
}
