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
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Application.Profiles;   
using Shouldly;
using SocialMediaApp.Application.Features.Comments.Handler.Commands;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Exceptions;

namespace test.UnitTest.Comments.Handler
{
    public class CreateCommentHandlerTest
    {
        private  readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _mockRepoComment;
        private readonly Mock<IPostRepository> _mockRepoPost;
        private readonly Mock<IUserRepository> _mockRepoUser;
        private readonly CreateCommentRequestHandler _handler;
        
        private readonly CreateCommentDto _createCommentDto;
        public CreateCommentHandlerTest()
        {
            _mockRepoComment = MockRepositoryFactory.GetCommentRepository();
            _mockRepoPost = MockRepositoryFactory.GetPostRepository();
            _mockRepoUser = MockRepositoryFactory.GetUserRepository();
            _handler = new CreateCommentRequestHandler(_mockRepoComment.Object, _mapper, _mockRepoPost.Object,_mockRepoUser.Object);


            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();  
    
            _createCommentDto = new CreateCommentDto
            {
                UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                PostId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                Text = "I like the picture:)"
            };
        }


        [Fact]
        public async Task CreateComment()
        {
            // When
            

            var resultTask = _handler.Handle(new CreateCommentRequest(){ creatCommentDto = _createCommentDto}, CancellationToken.None);
            
            var result = await resultTask;
            var comments = await _mockRepoComment.Object.GetAll();

            result.ShouldBeOfType<BaseResponseClass>();

            // Then
        }
    }   

}