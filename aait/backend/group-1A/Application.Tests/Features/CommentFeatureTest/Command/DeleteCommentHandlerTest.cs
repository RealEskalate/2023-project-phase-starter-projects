using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Handlers.Commands;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace Application.Tests.Features.CommentFeatureTest.Commands
{
    public class DeleteCommentHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _mockRepo;
        public DeleteCommentHandlerTest()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteCommentValidTest()
        {
           var mocCommentRepository  = MockCommentRepository.GetCommentRepository().Object;
            var handler = new CommentDeleteHandler(mocCommentRepository);

            var result = await handler.Handle(new CommentDeleteCommand() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<int>>();
        }
        [Fact]
        public async Task DeleteCommentWithInValidIdTest()
        {
           var mocCommentRepository  = MockCommentRepository.GetCommentRepository().Object;
            var handler = new CommentDeleteHandler(mocCommentRepository);
                            
            await Should.ThrowAsync<NotFoundException>(async () =>
                await handler.Handle(new CommentDeleteCommand(), CancellationToken.None));
        }
    }
}
