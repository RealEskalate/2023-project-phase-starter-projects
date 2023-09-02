using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.CommentReactionFeature.Handlers.Queries;
using Application.Features.CommentReactionFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.CommentReactionFeature.Commands
{
    public class GetCommentDislikesQueryTest
    {            
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

            private readonly IMapper _mapper;
            private ReactionDTO testReaction;
            public GetCommentDislikesQueryTest()
            {
                _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();


                var mapperConfig = new MapperConfiguration(c => 
                {
                    c.AddProfile<MappingProfile>();
                });

                _mapper = mapperConfig.CreateMapper();
               
                

                testReaction = new ReactionDTO
                {
                    ReactedId = 1,
                    ReactionType = "like"
                };
            }

        [Fact]
        public async Task Valid_CommentReaction_Added()
        {
            var mocCommentReactionRepository = MockCommentReactionRepository.GetCommentReactionRepository().Object;
            var mockCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var _handler = new GetCommentsDislikeHandler(_mapper,_mockUnitOfWork.Object);
                         
            var result = await _handler.Handle(new GetCommentsDislikeQuery() {CommentId = 1}, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<List<ReactionResponseDTO>>>();
        }

         [Fact]   
        public async Task GetCommentReactionWithInvalidId()
        {
            var mocCommentReactionRepository = MockCommentReactionRepository.GetCommentReactionRepository().Object;
            var mockCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var _handler = new GetCommentsDislikeHandler(_mapper,_mockUnitOfWork.Object);
            await Should.ThrowAsync<NotFoundException>(async () =>
               await _handler.Handle(new GetCommentsDislikeQuery() { CommentId = 100}, CancellationToken.None));
        }

    }
}

