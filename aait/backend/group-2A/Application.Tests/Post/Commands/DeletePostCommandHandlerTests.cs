using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Handlers.Command;
using Application.Features.Post.Request.Commands;
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

namespace Application.Tests.Post.Commands
{
    public class DeletePostCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;

        public DeletePostCommandHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeletePostCommandTest()
        {
            var handler = new DeletePostCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeletePostCommand() { Id = 1, UserId = 2}, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<Unit>>();

        }
    }
}
