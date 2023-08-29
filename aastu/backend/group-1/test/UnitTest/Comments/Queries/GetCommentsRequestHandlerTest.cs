using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.UnitTest.Mocks;
using AutoMapper;
using Moq;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Features.Comments.Handler.Queries;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.Profiles;   
using Shouldly;

namespace test.UnitTest.Comments.Queries
{
    public class GetCommentsRequestHandlerTest
    {
        private  readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _mockRepo;

            public GetCommentsRequestHandlerTest()
            {
            _mockRepo = MockRepositoryFactory.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();  
            }


        [Fact]
        public async Task GetCommentListTest()
        {
            // Given
            var handler = new GetCommentListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCommentListRequest(), CancellationToken.None);
            
            result.ShouldBeOfType<List<CommentDto>>();
            result.Count.ShouldBe(0);
        }
    }
}