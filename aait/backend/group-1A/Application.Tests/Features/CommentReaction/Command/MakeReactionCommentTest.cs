using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.CommentFeature.Handlers.Commands;
using Application.Features.CommentFeature.Requests.Commands;
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
    public class CreateCommentReactionCommandTest
    {            
            private readonly IMapper _mapper;
            private ReactionDTO testReaction;
            public CreateCommentReactionCommandTest()
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
            var mockCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var _handler = new CommentReactionHandler(mocCommentReactionRepository,_mapper,mockCommentRepository);
                         
            var result = await _handler.Handle(new CommentReactionCommand() { UserId = 1,ReactionData = testReaction}, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        [Fact]
        public async Task IValid_CommentReaction_Added()
        {
            var mocCommentReactionRepository = MockCommentReactionRepository.GetCommentReactionRepository().Object;
            var mockCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var _handler = new CommentReactionHandler(mocCommentReactionRepository,_mapper,mockCommentRepository);
            testReaction.ReactionType = "Like";          
            await Should.ThrowAsync<ValidationException>(async () =>
               await _handler.Handle(new CommentReactionCommand() { UserId = 1,ReactionData = testReaction}, CancellationToken.None));
        }

    }
}