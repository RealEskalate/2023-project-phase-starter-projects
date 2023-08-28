using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Features.PostFeature.Handlers.Queries;
using Application.Features.PostFeature.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.PostFeatureTest.Queries
{
    public class GetPostHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;
        public GetPostHandlerTest()
        {
            _mockRepo = MockPostRepository.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task ValidGetPostTest()
        {
            var handler = new GetSinglePostHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetSinglePostQuery(){userId = 1, Id = 1}, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();
        }
    }
}