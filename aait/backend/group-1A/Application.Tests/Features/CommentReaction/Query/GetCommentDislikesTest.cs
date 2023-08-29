using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.CommentFeature.Handlers.Commands;
using Application.Features.CommentFeature.Handlers.Queries;
using Application.Features.CommentFeature.Requests.Commands;
using Application.Features.CommentFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using Domain.Entites;
using Moq;
using Shouldly;

namespace Application.Tests.Features.CommentReactionFeature.Commands
{
    public class GetCommentDislikesQueryTest
    {            
            private readonly IMapper _mapper;
            private ReactionDTO testReaction;
            public GetCommentDislikesQueryTest()
            {

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
            var mockCommentRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new GetCommentDislikesHandler(mocCommentReactionRepository,_mapper,mockCommentRepository);
                         
            var result = await _handler.Handle(new GetCommentDislikesQuery() {CommentId = 1}, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<List<ReactionResponseDTO>>>();
        }

         [Fact]   
        public async Task GetCommentReactionWithInvalidId()
        {
            var mocCommentReactionRepository = MockCommentReactionRepository.GetCommentReactionRepository().Object;
            var mockCommentRepository = MockCommentRepository.GetPostRepository().Object;
            var _handler = new GetCommentsDislikeHandler(mocCommentReactionRepository,_mapper,mockCommentRepository);
            await Should.ThrowAsync<NotFoundException>(async () =>
               await _handler.Handle(new GetCommentDislikesQuery() { CommentId = 100}, CancellationToken.None));
        }

    }
}