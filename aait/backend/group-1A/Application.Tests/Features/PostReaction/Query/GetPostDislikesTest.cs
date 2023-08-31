using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Handlers.Commands;
using Application.Features.PostFeature.Handlers.Queries;
using Application.Features.PostFeature.Requests.Commands;
using Application.Features.PostFeature.Requests.Queries;
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
    public class GetPostDislikesQueryTest
    {            
            private readonly IMapper _mapper;
            private ReactionDTO testReaction;
            public GetPostDislikesQueryTest()
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
            var _handler = new GetPostDislikesHandler(mocPostReactionRepository,_mapper,mockPostRepository);
                         
            var result = await _handler.Handle(new GetPostDislikesQuery() {PostId = 1}, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<List<ReactionResponseDTO>>>();
        }

         [Fact]   
        public async Task GetPostReactionWithInvalidId()
        {
            var mocPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository().Object;
            var mockPostRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new GetPostDislikesHandler(mocPostReactionRepository,_mapper,mockPostRepository);
            await Should.ThrowAsync<NotFoundException>(async () =>
               await _handler.Handle(new GetPostDislikesQuery() { PostId = 100}, CancellationToken.None));
        }

    }
}