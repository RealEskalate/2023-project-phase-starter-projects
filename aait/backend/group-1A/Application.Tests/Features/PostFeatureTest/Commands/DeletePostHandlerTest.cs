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
    public class DeletePostHandlerTest
    {
         private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;

        public DeletePostHandlerTest()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeletePostValidTest()
        {
            var handler = new DeletePostHandler(_mockRepo.Object);

            var result = await handler.Handle(new DeletePostCommand(){userId = 1, Id = 1}, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();

        }
    }
}