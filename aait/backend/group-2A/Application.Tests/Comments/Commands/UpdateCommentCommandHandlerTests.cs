using Application.Contracts.Persistance;
using Application.Features.Comment.Handlers.Commands;
using Application.Features.Comment.Requests.Commands;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Comments.Commands
{
    public class UpdateCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;

        public UpdateCommentCommandHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateCommentCommandTest()
        {
            var handler = new UpdateCommentCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateCommentCommand(), CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<Unit>>();

        }
    }
}
