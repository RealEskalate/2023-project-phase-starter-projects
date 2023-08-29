using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMediaApp.Domain;
using SocialMediaApp.Application.Persistence.Contracts;
using Moq;

namespace test.UnitTest.Mocks;

public static class MockRepositoryFactory
{
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = new List<Comment>
            {
               new Comment
               {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    PostId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Text = "I like it :)" 
               },

               new Comment
               {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    PostId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Text = "Wow amazing :)" 
               }

            };

            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(comments);

            mockRepo.Setup(r => r.Add(It.IsAny<Comment>())).ReturnsAsync((Comment comment) => {
                comments.Add(comment);
                return comment;
            });


            return mockRepo;

        }

        public static Mock<IPostRepository> GetPostRepository()
        {
            
            var posts = new List<Post>
            {
                new Post
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6"),
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc7"),
                    Title = "Gamming Pc",
                    Content = "High performance, have a graphic card"
                },
                new Post
                {
                  Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc5"),
                  UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                  Title = "Desktop Pc",
                  Content = "low performance, have no  graphic card",
                }
            };

            var mockRepo = new Mock<IPostRepository>();

                mockRepo.Setup(r => r.GetAll()).ReturnsAsync(posts);
                mockRepo.Setup(r => r.GetPosts(Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"))).ReturnsAsync(posts);
                mockRepo.Setup(r => r.GetPostDetails(Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"), Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc5"))).ReturnsAsync(posts[1]);
                mockRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post post) => {
                    posts.Add(post);
                    return post;
                });

                mockRepo.Setup(r => r.Delete(It.IsAny<Post>()));

                return mockRepo;

        }




         public static Mock<IUserRepository> GetUserRepository()
        {
            /*p    public string Name { get; set; }
    public string email { get; set; }
    public string password { get; set; }*/
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Name = "Jima Dube",
                    email = "jimd@gmail.com",
                    password = "High123@",
                },
                new User
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6"),
                    Name = "xBebe",
                    email = "bebe@gmail.com",
                    password = "bebe123#",
                }
            };

            var mockRepo = new Mock<IUserRepository>();

                mockRepo.Setup(r => r.GetAll()).ReturnsAsync(() => users);

                mockRepo.Setup(r => r.Add(It.IsAny<User>())).Callback((User user) => users.Add(user));
                mockRepo.Setup(r => r.Exists(It.IsAny<Guid>())).ReturnsAsync((Guid userId) =>{
                    var user = users.Where(u => u.Id == userId);

                    return user.Any();
                });

                mockRepo.Setup(r => r.Update(It.IsAny<User>()));
                
                mockRepo.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(new User());
                return mockRepo;

        }



        public static Mock<INotificationRepository> GetNotificationRepository()
        {
            
            var notifications = new List<Notification>
            {
                new Notification
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc9"),
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Content = "Gamming Pc",
                    IsRead = false,
                },
                new Notification
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc9"),
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc3"),
                    Content = "Gamming Pc",
                    IsRead = false,
                }
            };

            var mockRepo = new Mock<INotificationRepository>();

                mockRepo.Setup(r => r.GetNotifications(It.IsAny<Guid>())).ReturnsAsync((Guid userId) => {
                    // null if not found
                    var result =  notifications.Where(n => n.UserId == userId).ToList();
                    if (result == null)
                    {
                        return null;
                    }
                    return result;
                    
                    });

                mockRepo.Setup(r => r.Add(It.IsAny<Notification>())).ReturnsAsync((Notification notification) => {
                    notifications.Add(notification);
                    return notification;
                });
                


                return mockRepo;

        }
}
