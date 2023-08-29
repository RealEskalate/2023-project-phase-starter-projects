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
    public class UpdateCommentHandlerTest
    {
        private readonly IMapper _mapper;
        CommentUpdateDTO testComment;
        public UpdateCommentHandlerTest()
        {

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            testComment = new CommentUpdateDTO()
            {
                Content = "Test comment"
            };
        }

        [Fact]
        public async Task UpdateCommentValidTest()
        {
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new UpdateCommentHandler(_mockRepo.Object, _mapper);

            testComment.Content = "Updated comment";
            var result = await handler.Handle(new UpdateCommentCommand()
            {
             Id  = 1,
             userId = 1,
             CommentData = testComment

            }, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<CommentResponseDTO>>();
        }

        [Fact]
        public async Task UpdateCommentWithNoContentTest()
        {
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new UpdateCommentHandler(_mockRepo.Object, _mapper);

            testComment.Content = "";
            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(new UpdateCommentCommand()
            {
             Id  = 1,
             userId = 1,
             CommentData = testComment

            }, CancellationToken.None));

        }
        [Fact]
        public async Task UpdateNonExistentCommentTest()
        {
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new UpdateCommentHandler(_mockRepo.Object, _mapper);

            testComment.Content = "Updated comment";
            await Should.ThrowAsync<NotFoundException>(async () => await handler.Handle(new UpdateCommentCommand()
            {
             Id  = 100,
             userId = 1,
             CommentData = testComment

            }, CancellationToken.None));

        }
    }
}
