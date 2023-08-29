using AutoMapper;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();
        #endregion User

        #region Post
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, PostListDto>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
        #endregion Post

        #region Comment
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        #endregion Comment

        #region Like
        CreateMap<Like, LikeDto>().ReverseMap();
        CreateMap<Like, CreateLikeDto>().ReverseMap();
        #endregion Like

        #region Follow
        CreateMap<Follow, FollowDto>().ReverseMap();
        CreateMap<Follow, CreateFollowDto>().ReverseMap();
        #endregion Follow

        #region Notification
        CreateMap<Notification, NotificationDto>().ReverseMap();
        CreateMap<Notification, CreateNotificationDto>().ReverseMap();
        #endregion Notification
    }
}
