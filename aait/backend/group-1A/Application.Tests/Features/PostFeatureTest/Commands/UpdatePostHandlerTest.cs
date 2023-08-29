using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Features.PostFeature.Handlers.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.PostFeatureTest.Commands
{
    public class UpdatePostHandlerTest
    {
            private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;
        public UpdatePostHandlerTest()
        {
             _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();   
        }

        [Fact]
        public async Task UpdatePostValidTest()
        {
            var handler = new UpdatePostHandler(_mockRepo.Object,_mapper);

            var updatedPost = new PostUpdateDTO(){
                Title = "new updated Data",
                Content = "new Updated Data content"
            };
            var result = await handler.Handle(new UpdatePostCommand(){Id = 1, userId = 1, PostUpdateData = updatedPost},CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();
            
        }
    }
}