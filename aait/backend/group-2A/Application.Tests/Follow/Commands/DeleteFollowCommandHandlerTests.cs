using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Request.Command;
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

namespace Application.Tests.Follow.Commands
{
    public class DeleteFollowCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly FollowDto _followDto;
        public DeleteFollowCommandHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _followDto = new FollowDto
            {
                FollowerId = 1,
                FollowedId = 3,
            };

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteFollowCommandTest()
        {
            var handler = new DeleteFollowCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteFollowCommand() { follow = _followDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<Unit>>();

        }
    }
}
