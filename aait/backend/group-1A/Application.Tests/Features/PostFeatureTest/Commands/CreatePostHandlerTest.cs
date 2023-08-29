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
    public class CreatePostHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;
        public CreatePostHandlerTest()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task ValidCreatePostTest()
        {
            var handler = new CreatePostHandler(_mapper,_mockRepo.Object);

            var newPost = new PostCreateDTO(){
                Title = "New post",
                Content = "New post Content"
            };
            var result = await handler.Handle(new CreatePostCommand(){userId = 1, NewPostData = newPost}, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();
        }
    }
}