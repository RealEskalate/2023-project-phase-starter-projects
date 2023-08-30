using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using Application.Features.CommentFeatures.Handlers.Commands;
using Application.Features.CommentFeatures.Handlers.Queries;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Exceptions;

namespace Application.Tests.Features.CommentFeatureTest.Commands
{
    public class CreateCommentHandlerTest
    {
        private readonly IMapper _mapper;
        private CommentCreateDTO testComment;
        public CreateCommentHandlerTest()
        {

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            testComment = new CommentCreateDTO()
            {
                PostId = 1,
                Content = "Test comment"
            };
        }

        [Fact]
        public async Task ValidCreateCommentTest()
        {
            var mocCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var mocPostRepository = MockPostRepository.GetPostRepository().Object;
            var handler = new CommentCreateHandler(_mapper,mocCommentRepository,mocPostRepository );

            var result = await handler.Handle(new CommentCreateCommand() {NewCommentData = testComment,userId = 1}, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<CommentResponseDTO>>();
        }

        [Fact]
        public async Task CreateCommentForNonExistentPostTest()
        {
            var mocCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var mocPostRepository = MockPostRepository.GetPostRepository().Object;
            var handler = new CommentCreateHandler(_mapper,mocCommentRepository,mocPostRepository );
            testComment.PostId = 100;

            await Should.ThrowAsync<NotFoundException>(async () =>
                await handler.Handle(new CommentCreateCommand() {NewCommentData = testComment,userId = 1}, CancellationToken.None));
        }
        [Fact]
        public async Task CreateCommentWithNoContentTest()
        {
            var mocCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var mocPostRepository = MockPostRepository.GetPostRepository().Object;
            var handler = new CommentCreateHandler(_mapper,mocCommentRepository,mocPostRepository );
            testComment.Content = "";
            
            await Should.ThrowAsync<ValidationException>(async () =>
                await handler.Handle(new CommentCreateCommand() {NewCommentData = testComment,userId = 1}, CancellationToken.None));
        }
    }
}
