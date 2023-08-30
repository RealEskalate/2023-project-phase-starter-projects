using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Handlers.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using Domain.Entites;
using Moq;
using Shouldly;

namespace Application.Tests.Features.PostReactionFeature.Commands
{
    public class CreatePostReactionCommandTest
    {            
            private readonly IMapper _mapper;
            private ReactionDTO testReaction;
            public CreatePostReactionCommandTest()
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
        public async Task Valid_PostReaction_Added()
        {
            var mocPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository().Object;
            var mockPostRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new PostReactionHandler(mocPostReactionRepository,_mapper,mockPostRepository);
                         
            var result = await _handler.Handle(new PostReactionCommand() { UserId = 1,ReactionData = testReaction}, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        [Fact]
        public async Task IValid_PostReaction_Added()
        {
            var mocPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository().Object;
            var mockPostRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new PostReactionHandler(mocPostReactionRepository,_mapper,mockPostRepository);
            testReaction.ReactionType = "Like";          
            await Should.ThrowAsync<ValidationException>(async () =>
               await _handler.Handle(new PostReactionCommand() { UserId = 1,ReactionData = testReaction}, CancellationToken.None));
        }

    }
}