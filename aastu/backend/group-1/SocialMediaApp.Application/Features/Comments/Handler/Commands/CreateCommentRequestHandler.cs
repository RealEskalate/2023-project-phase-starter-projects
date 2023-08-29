using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Comments.Validator;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Handler.Commands;

public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, BaseResponseClass>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    private IMapper _mapper;
    public CreateCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper, IPostRepository postRepository, IUserRepository userRepository )
    {
        this._commentRepository = commentRepository;
        this._mapper = mapper;
        _postRepository = postRepository;
        this._userRepository = userRepository;
    }
    public async Task<BaseResponseClass> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentDtoValidator(_postRepository,_userRepository);
        var validationResult = await validator.ValidateAsync(request.creatCommentDto, cancellationToken);
        var response = new BaseResponseClass();
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var comment = _mapper.Map<Comment>(request.creatCommentDto);
            comment = await _commentRepository.Add(comment);
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = comment.Id;
        }
        
        return response;
    }
}
