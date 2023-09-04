using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Handlers.Queries;
using Application.Features.CommentFeatures.Requests.Queries;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace Application.Tests.Features.CommentFeatureTest.Queries
{
    public class GetCommentHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetCommentHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper(); 
        }

        [Fact]
        public async Task GetValidCommentTest()
        {
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new GetCommentQueryHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetSingleCommentQuery()
            {
             Id  = 1
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<CommentResponseDTO>>();
        }
        [Fact]
        public async Task GetInValidCommentTest()
        {
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new GetCommentQueryHandler(_mockUnitOfWork.Object, _mapper);

            await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(new GetSingleCommentQuery()
            {
             Id  = 100
            }, CancellationToken.None));
        }
    }
}
